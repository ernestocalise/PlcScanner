using Krypton.Toolkit.Suite.Extended.TreeGridView;
using Newtonsoft.Json.Linq;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;
using Opc.Ua.Server;
using PlcScanner.Dialogs;
using PlcScanner.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace PlcScanner
{
    public class MapperManager
    {
        public string Name;
        private OpcUaClient _client;
        private bool _active;
        public OpcTag ClientMapping;
        private List<ClientTag> _clientTags = new List<ClientTag>();
        public DataTable dtClientTags = new DataTable();
        public DataTable dtRoutines = new DataTable();
        private ApplicationInstance _serverApplicationInstance;
        private OpcUaSimulationServer _server;
        private List<TagChange> _RoutineRegistering = new List<TagChange>();
        private Stopwatch _swRoutineRecorder;
        private readonly Action<OpcTag> _callbackUpdateTreeview;
        private System.Threading.Timer _tmrRoutineUpdates;
        public bool IsActive()
        {
            return _active;
        }
        public MapperManager(string _name, PlcConfiguration config, Action<OpcTag> callbackUpdateTreeview)
        {
            this.Name = _name;
            this._client = new OpcUaClient(config);
            this._server = new OpcUaSimulationServer(_name);
            _callbackUpdateTreeview = callbackUpdateTreeview;
        }
        public void SetActive(bool active)
        {
            _active = active;
        }
        public PlcConfiguration GetClientConfiguration()
        {
            return _client.GetPlcConfiguration();
        }
        #region Client
        public bool HasSubscriptionActive()
        {
            if (_client.IsConnected() || _server.IsRunning)
                return true;
            return false;
        }
        public bool IsClientConected()
        {
            if (_client == null)
                return false;
            if (!_client.IsConnected())
                return false;
            return true;
        }
        public bool ConnectOrDisconnectClient()
        {
            if (!_client.IsConnected())
            {
                if (_client.Connect())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (_client.Disconnect())
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public void LoadMapping()
        {
            string MappingPath = Path.Combine(Helper.GetPath(PathType.Client, Name), "Mapping.xml");
            if (!File.Exists(MappingPath))
            {
                _client._log.WriteError("Mapping not found! Unable to load client tags");
                return;
            }
            XmlDocument mapping = new XmlDocument();
            mapping.Load(MappingPath);
            var root = new OpcTag(mapping.DocumentElement.Name, "", "Folder", "");
            foreach (XmlNode children in mapping.DocumentElement.ChildNodes)
            {
                OpcTag nodes = createMapping(children);
                root.Childrens.Add(nodes);
            }
            ClientMapping = root;
        }
        private OpcTag createMapping(XmlNode xmlNode)
        {
            string tagName = xmlNode.Attributes?["Name"]?.Value ?? "";
            string tagNode = xmlNode.Attributes?["NodeId"]?.Value ?? "";
            string tagType = xmlNode.Attributes?["DataType"]?.Value ?? "Folder";
            string tagValue = xmlNode.Attributes?["Value"]?.Value ?? "";

            var tag = new OpcTag(tagName, tagNode, tagType, tagValue);
            foreach (XmlNode child in xmlNode.ChildNodes)
                tag.Childrens.Add(createMapping(child));

            return tag;
        }
        public void SubscribeTags()
        {
            var frmSubs = new dialogSubscription(ClientMapping);
            if (frmSubs.ShowDialog() == DialogResult.OK)
            {
                foreach (var val in frmSubs.Mapping)
                {
                    SubscribeTagOnMapping(ClientMapping, val.Key, val.Value);
                }
            }
        }
        private OpcTag SubscribeTagOnMapping(OpcTag tag, string nodeId, bool subscriptionStatus)
        {
            OpcTag output = null;
            if (tag.NodeId == nodeId)
            {
                if (subscriptionStatus != (tag.SubscriptionID != string.Empty) && tag.DataType != "Folder" && !string.IsNullOrEmpty(tag.NodeId))
                {
                    if (subscriptionStatus)
                        tag.SubscriptionID = _client.CreateSubscription(new List<string> { tag.NodeId }, 1000, NotificationEventHandler);
                    else
                    {
                        _client.RemoveSubscription(tag.SubscriptionID);
                        tag.SubscriptionID = string.Empty;
                    }
                }
                output = tag;
            }
            else
            {
                foreach (OpcTag children in tag.Childrens)
                {
                    if (output == null)
                        output = SubscribeTagOnMapping(children, nodeId, subscriptionStatus);
                }
            }
            return output;
        }
        public bool LoadClientTags()
        {
            LoadMapping();
            _clientTags.Clear();
            string MappingPath = Path.Combine(Helper.GetPath(PathType.Client, Name), "Mapping.xml");
            if (!File.Exists(MappingPath))
            {
                _client._log.WriteError("Mapping not found! Unable to load client tags");
                return false;
            }
            else
            {
                XDocument mapping = XDocument.Load(new StreamReader(MappingPath));
                var count = mapping.DescendantNodes().Count();

                foreach (XElement node in mapping.DescendantNodes())
                {
                    ClientTag _tag = null;
                    if (node.Name == "Folder")
                    {
                        _tag = new ClientTag
                        {
                            Name = node.Attribute("Name")?.Value ?? "",
                            NodeId = node.Attribute("NodeId")?.Value ?? "",
                            DataType = "Folder",
                            Value = ""
                        };
                    }
                    else if (node.Name == "Variable")
                    {
                        _tag = new ClientTag
                        {
                            Name = node.Attribute("Name")?.Value ?? "",
                            NodeId = node.Attribute("NodeId")?.Value ?? "",
                            DataType = node.Attribute("DataType")?.Value ?? "",
                            Value = ""
                        };
                    }
                    if (_tag != null)
                        _clientTags.Add(_tag);
                }
            }

            return true;
        }
        public void GetClientTags()
        {
            if (_clientTags.Count <= 0)
                LoadClientTags();

            dtClientTags = new DataTable();
            dtClientTags.Columns.Add("Name");
            dtClientTags.Columns.Add("NodeId");
            dtClientTags.Columns.Add("Type");
            dtClientTags.Columns.Add("Value");

            if (_clientTags.Count <= 0)
                return;
            foreach (var tag in _clientTags)
            {
                var row = dtClientTags.NewRow();
                row[0] = tag.Name;
                row[1] = tag.NodeId;
                row[2] = tag.DataType;
                row[3] = tag.Value;
                dtClientTags.Rows.Add(row);
            }

        }
        public void RunClientDiscovery()
        {
            _client.RunDiscovery();
        }
        public void ClientReadValue(string nodeID)
        {
            var result = _client.ReadValue(nodeID);
            var tag = FindAndUpdateTagOnMapping(ClientMapping, nodeID, result.Key, result.Value.ToString("dd-MM-yyyy HH:mm:ss.fff"));
            _callbackUpdateTreeview(tag);
        }
        public bool ClientWriteValue(string nodeID, string value)
        {
            return _client.WriteValue(nodeID, value);
        }
        private OpcTag FindTagOnMapping(OpcTag tag, string nodeId)
        {
            OpcTag output = null;
            if (tag.NodeId == nodeId)
            {
                output = tag;
            }
            else
            {
                foreach (OpcTag children in tag.Childrens)
                {
                    if (output == null)
                        output = FindTagOnMapping(children, nodeId);
                }
            }
            return output;
        }
        public OpcTag FindAndUpdateTagOnMapping(OpcTag tag, string nodeId, string value, string serverTimestamp)
        {
            OpcTag output = null;
            if (tag.NodeId == nodeId)
            {
                tag.Value = value;
                tag.Timestamp = serverTimestamp;
                tag.Status = "Good";
                output = tag;
            }
            else
            {
                foreach (OpcTag children in tag.Childrens)
                {
                    if (output == null)
                        output = FindAndUpdateTagOnMapping(children, nodeId, value, serverTimestamp);
                }
            }
            return output;
        }
        private void NotificationEventHandler(Opc.Ua.Client.MonitoredItem item, MonitoredItemNotificationEventArgs e)
        {
            foreach (var value in item.DequeueValues())
            {
                string oldValue = FindTagOnMapping(ClientMapping, item.StartNodeId.ToString())?.Value ?? "null";
                string tagName = _clientTags.First(ct => ct.NodeId == item.StartNodeId).Name;
                var tag = FindAndUpdateTagOnMapping(ClientMapping, item.StartNodeId.ToString(), value.Value.ToString(), value.ServerTimestamp.ToString("dd-MM-yyyy HH:mm:ss.fff"));
                if (IsActive())
                {
                    _callbackUpdateTreeview(tag);
                }
                if (_swRoutineRecorder != null && _swRoutineRecorder.IsRunning)
                {

                    TagChange change = new TagChange
                    {
                        NodeId = item.StartNodeId.ToString(),
                        Time = _swRoutineRecorder.Elapsed,
                        Name = tagName,
                        OldValue = oldValue,
                        Value = value.Value.ToString()
                    };

                    _RoutineRegistering.Add(change);

                }
            }
        }
        public void SubscibeAllTags()
        {

            foreach (var tag in _clientTags)
            {
                if (tag.DataType != "Folder" && !string.IsNullOrEmpty(tag.NodeId))
                {
                    List<string> nodeIds = new List<string>
                    {
                        tag.NodeId
                    };
                    _client.CreateSubscription(nodeIds, 1000, NotificationEventHandler);
                }
            }
        }
        public string GetStopwatchTimeElapsed()
        {
            if (_swRoutineRecorder == null || !_swRoutineRecorder.IsRunning)
                return "00:00:00";
            return $"{_swRoutineRecorder.Elapsed.Hours.ToString().PadLeft(2, '0')}:{_swRoutineRecorder.Elapsed.Minutes.ToString().PadLeft(2, '0')}:{_swRoutineRecorder.Elapsed.Seconds.ToString().PadLeft(2, '0')}";

        }
        public void RoutineRecordingStart()
        {
            _RoutineRegistering = new List<TagChange>();
            _swRoutineRecorder = new Stopwatch();
            _swRoutineRecorder.Start();
        }
        public bool IsRoutineRecordingRunning()
        {
            if (_swRoutineRecorder != null && _swRoutineRecorder.IsRunning)
            {
                return true;
            }
            return false;
        }
        public void RoutineRecordingEnd()
        {
            _swRoutineRecorder.Stop();
            string filename = string.Concat("Routine_",
                DateTime.Now.Year, "_",
                DateTime.Now.Month.ToString().PadLeft(2, '0'), "_",
                DateTime.Now.Day.ToString().PadLeft(2, '0'), "_",
                DateTime.Now.Hour.ToString().PadLeft(2, '0'), "_",
                DateTime.Now.Minute.ToString().PadLeft(2, '0'), "_",
                DateTime.Now.Second.ToString().PadLeft(2, '0'));
            string FilePath = Path.Combine(Helper.GetPath(PathType.Routines, this.Name), $"{filename}.json");
            int i = 1;
            while (File.Exists(FilePath))
            {
                FilePath = Path.Combine(Helper.GetPath(PathType.Routines, this.Name), $"{filename}_{i}.json");
                i++;
            }
            StreamWriter sw = new StreamWriter(FilePath);
            var txt = Newtonsoft.Json.JsonConvert.SerializeObject(_RoutineRegistering);
            sw.Write(txt);
            sw.Close();
            sw.Dispose();
            MessageBox.Show($"Routine saved as [{Path.GetFileNameWithoutExtension(FilePath)}]");
        }
        public void OpenRoutineEditor()
        {
            var frmEditor = new frmRoutineEditor(this.Name, this._clientTags);
            frmEditor.ShowDialog();
        }
        #endregion

        #region Server
        public async Task<bool> LaunchServer()
        {
            if (_server.IsRunning)
            {
                _server.StopAllRoutines();
                _server.Stop();
                _serverApplicationInstance.Stop();
                return false;
            }

            var config = _server.GetConfiguration(this.Name).Result;
            _serverApplicationInstance = new ApplicationInstance
            {
                ApplicationName = this.Name,
                ApplicationType = ApplicationType.Server,
                ApplicationConfiguration = config
            };
            try
            {
                bool haveCert = _serverApplicationInstance.CheckApplicationInstanceCertificates(true).Result;
                if (!haveCert)
                    _server.GetLogger().WriteError("No certificate created!");
                await _serverApplicationInstance.Start(_server);
                _server.GetLogger().WriteInfo("Server Started successfully");
            }
            catch (AggregateException agex)
            {
                string exString = "";
                foreach (Exception ex in agex.InnerExceptions)
                    exString += $"[{ex.Message}]";
                _server.GetLogger().WriteError($"Unable to launch server!. Error [{agex}]");
            }
            catch (Exception ex)
            {
                _server.GetLogger().WriteError($"Unable to launch server!. Error [{ex.Message}]");
                return false;
            }
            InitializeDTRoutine();

            return true;
        }
        public bool IsServerConnected()
        {
            if (_server == null)
                return false;
            if (!_server.IsRunning)
                return false;
            return true;
        }
        public void InitializeDTRoutine()
        {
            dtRoutines = new DataTable();
            dtRoutines.Columns.Add("Name");
            dtRoutines.Columns.Add("Tyoe");
            dtRoutines.Columns.Add("Status");
            dtRoutines.Columns.Add("Started At");
            dtRoutines.Columns.Add("Finished At");
            _tmrRoutineUpdates = new System.Threading.Timer(
            TimerCallback,
            null,
            TimeSpan.Zero,           // start immediately
            TimeSpan.FromSeconds(5)  // repeat every 5 seconds
        );
        }
        public void ReloadServerConfiguration()
        {
            _server.SetOpcServerConfiguration(new OpcServerConfiguration(this.Name));
        }
        public void AddRoutine(string RoutineName)
        {
            string name = Guid.NewGuid().ToString();
            _server.AddRoutine(
                Path.Combine(Helper.GetPath(PathType.Routines, this.Name), RoutineName),
                name);
            var baseRoutine = _server.GetRoutineByName(name);
            var dtRow = dtRoutines.NewRow();
            dtRow[0] = baseRoutine.Name;
            dtRow[1] = RoutineName;
            dtRow[2] = baseRoutine.GetRoutineStatus();
            dtRow[3] = baseRoutine.DateStarted == DateTime.MinValue ? "Not Started" : baseRoutine.DateStarted.ToString("dd:MM:yyyy HH:mm:ss.FFF");
            dtRow[4] = baseRoutine.DateEnded == DateTime.MinValue ? "Not Started" : baseRoutine.DateEnded.ToString("dd:MM:yyyy HH:mm:ss.FFF");
            dtRoutines.Rows.Add(dtRow);
        }
        public void StartRoutine(string RoutineName)
        {
            _server.StartRoutineByName(RoutineName);
        }
        public void PauseOrResumeRoutine(string RoutineName)
        {
            var routine = _server.GetRoutineByName(RoutineName);
            if (routine != null)
            {
                if (routine.IsPaused)
                    routine.Resume();
                else
                    routine.Pause();
            }
        }
        public void StopRoutine(string RoutineName)
        {
            var routine = _server.GetRoutineByName(RoutineName);
            if (routine != null)
            {
                routine.Stop();
            }
        }
        private void TimerCallback(object state)
        {
            try
            {
                foreach (DataRow row in dtRoutines.Rows)
                {
                    var baseRoutine = _server.GetRoutineByName(row[0].ToString());
                    row[2] = baseRoutine.GetRoutineStatus();
                    row[3] = baseRoutine.DateStarted == DateTime.MinValue ? "Not Started" : baseRoutine.DateStarted.ToString("dd:MM:yyyy HH:mm:ss.FFF");
                    row[4] = baseRoutine.DateEnded == DateTime.MinValue ? "Not Started" : baseRoutine.DateEnded.ToString("dd:MM:yyyy HH:mm:ss.FFF");
                }
            }
            catch
            {

            }
        }
        #endregion
    }
}
