using Krypton.Toolkit.Suite.Extended.TreeGridView;
using Opc.Ua;
using Opc.Ua.Client;
using PlcScanner.Dialogs;
using PlcScanner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static Opc.Ua.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PlcScanner
{
    public partial class frmMain : Form
    {
        private LogHandler _log;
        private List<MapperManager> _mappers = new List<MapperManager>();
        private readonly int TWCLIENT_CELL_NODEID = 0;
        private readonly int TWCLIENT_CELL_NAME = 1;
        private readonly int TWCLIENT_CELL_VALUE = 2;
        private readonly int TWCLIENT_CELL_TIMESTAMP = 3;
        private readonly int TWCLIENT_CELL_STATUS = 4;
        private readonly int TWCLIENT_CELL_SUBSCRIBED = 5;
        public static Action<Image, string, string, string, string> AddToHistorian;
        public frmMain()
        {
            Utils.SetTraceMask(Utils.TraceMasks.All);
            AddToHistorian = addToHistorian;
            InitializeComponent();
            tcClientServer.Visible = false;
            _log = new LogHandler(LogType.Application, (int)LogLevel.Debug);
            _log.WriteInfo("Application Launched");
            LoadConfigurations();
            EnableOpcUaFileLogging();
        }

        void EnableOpcUaFileLogging()
        {
            string logDir = Helper.GetPath(PathType.Base);
            string logFile = Path.Combine(logDir, "OpcUa.log");

            Directory.CreateDirectory(logDir);

            Utils.SetTraceLog(logFile, deleteExisting: true);
            Utils.SetTraceMask(Utils.TraceMasks.All);
            Utils.SetTraceOutput(TraceOutput.DebugAndFile);

            Utils.Trace("=== OPC UA TRACE STARTED ===");
        }

        private void addToHistorian(Image logImage, string ProjectName, string ProjectType, string Message, string Timestamp)
        {
            gwHistorian.Rows.Add(
                logImage,
                ProjectName,
                ProjectType,
                Message,
                Timestamp
           );
        }

        private void gwHistorian_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn col in gwHistorian.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (gwHistorian.Columns.IndexOf(col) == 1)
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                else
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            }
        }

        #region Configuration
        private void LoadConfigurations()
        {
            try
            {
                tcClientServer.Visible = false;
                DisableAllMappers();
                RemoveUnsubscribedMapper();
                string FolderPath = Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments), "PlcScanner");
                string[] directories = Directory.GetDirectories(FolderPath);
                foreach (string dir in directories)
                {
                    string str = Path.GetFileName(dir);
                    if (str == "MAIN" || IsConfigurationLoaded(str))
                        continue;
                    if (!lstConfigurations.Items.Contains(str))
                    {
                        if (File.Exists(Path.Combine(dir, "Configuration.xml")))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(PlcConfiguration));
                            using (StreamReader sr = new StreamReader(Path.Combine(dir, "Configuration.xml")))
                            {
                                PlcConfiguration config = (PlcConfiguration)serializer.Deserialize(sr);
                                MapperManager mapper = new MapperManager(str, config, UpdateTreeViewNode);
                                _mappers.Add(mapper);
                                sr.Close();
                                sr.Dispose();
                            }
                            lstConfigurations.Items.Add(str);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _log.WriteError($"Unable to load configuration! Error: [{ex.Message}]");
            }
        }
        private bool IsConfigurationLoaded(string ConfigurationName)
        {
            if (_mappers.Count <= 0)
                return false;
            if (_mappers.Any(mapper => mapper.Name == ConfigurationName))
                return true;
            return false;
        }
        private void EnableMapper(string MapperName)
        {
            try
            {
                DisableAllMappers();
                var mapper = _mappers.Find(m => m.Name == MapperName);
                if (mapper != null)
                {
                    mapper.SetActive(true);
                    tabClientConnectChanged(mapper.IsClientConected());
                    tabServerConnectChanged(mapper.IsServerConnected());
                }
            }
            catch (Exception ex)
            {
                _log.WriteError($"Unable to enable selected configuration! Error: [{ex.Message}]");
            }
        }
        private MapperManager GetActiveMapper()
        {
            if (_mappers.Any(map => map.IsActive()))
                return _mappers.First(map => map.IsActive());
            return null;
        }
        private void DisableAllMappers()
        {
            foreach (var mapper in _mappers)
            {
                mapper.SetActive(false);
            }
        }
        private void RemoveUnsubscribedMapper()
        {
            int i = 0;
            while (i < _mappers.Count)
            {
                if (!_mappers[i].HasSubscriptionActive())
                {
                    _mappers[i] = null;
                    _mappers.RemoveAt(i);
                    lstConfigurations.Items.RemoveAt(i);
                }
                else
                    i++;
            }
        }

        private void launchDialogConfig(frmClientConfiguration dialog, bool isCopy = false)
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    if (!dialog.plcConfig.Store(isCopy))
                        launchDialogConfig(dialog, isCopy);
                    else
                        LoadConfigurations();
                }
                catch (Exception ex)
                {
                    _log.WriteError($"Unable to save configuration! [{ex.Message}]");
                    MessageBox.Show("Unable to save configuration!");
                    launchDialogConfig(dialog, isCopy);
                }
            }
        }

        private void CreateConfiguration()
        {
            frmClientConfiguration dialogConfig = new frmClientConfiguration();
            launchDialogConfig(dialogConfig);
        }

        private void EditConfiguration()
        {
            MapperManager mapper = GetActiveMapper();
            if (mapper != null)
            {
                frmClientConfiguration dialogConfig = new frmClientConfiguration(GetActiveMapper().GetClientConfiguration());
                launchDialogConfig(dialogConfig);
            }
        }
        private void CopyConfiguration()
        {
            MapperManager mapper = GetActiveMapper();
            if (mapper != null)
            {
                var conf = (PlcConfiguration)mapper.GetClientConfiguration().Clone();
                frmClientConfiguration dialogConfig = new frmClientConfiguration(conf);
                dialogConfig.setConfigurationName($"Copy of {conf.OldConfigurationName}");
                launchDialogConfig(dialogConfig, true);
            }
        }
        private void DeleteConfiguration()
        {
            MapperManager mapper = GetActiveMapper();
            if (mapper != null)
            {
                if (mapper.HasSubscriptionActive())
                {
                    MessageBox.Show("This project is active! stop both client and server and retry.", "PlcScanner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show(
                    $"Are you sure you wanna delete Configuration [{mapper.Name}] ?",
                    "PlcScanner",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    try
                    {
                        string FolderPath = Helper.GetPath(PathType.ProjectFolder, mapper.Name);
                        Directory.Delete(FolderPath, true);
                        LoadConfigurations();
                    }
                    catch (Exception ex)
                    {
                        _log.WriteError($"Unable to complete elimination! Error: [{ex.Message}]");
                        MessageBox.Show("Unable to complete elimination!");
                    }

                }
            }
        }

        #region Events

        private void lstConfigurations_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index < 0)
                return;
            string text = lstConfigurations.Items[e.Index].ToString();
            Image icon = Properties.Resources.IconProject;
            int iconSize = 24;
            int padding = 4;

            Rectangle IconRect = new Rectangle(
                e.Bounds.Left + padding,
                e.Bounds.Top + (e.Bounds.Height - iconSize) / 2,
                iconSize,
                iconSize);
            Rectangle textRect = new Rectangle(
                IconRect.Right + padding,
                e.Bounds.Top,
                e.Bounds.Width - iconSize - padding,
                e.Bounds.Height);

            e.Graphics.DrawImage(icon, IconRect);

            TextRenderer.DrawText(e.Graphics,
                text,
                e.Font,
                textRect,
                e.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

            e.DrawFocusRectangle();

        }
        private void lstConfigurations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstConfigurations.SelectedIndex != -1)
            {
                tcClientServer.Visible = true;
                MapperManager mapper = GetActiveMapper();
                if (mapper == null || mapper.Name != lstConfigurations.SelectedItem.ToString())
                {
                    EnableMapper(lstConfigurations.SelectedItem.ToString());
                    tsConfigurationBtnCopy.Enabled = true;
                    tsConfigurationBtnEdit.Enabled = true;
                    tsConfigurationBtnDelete.Enabled = true;
                    GetActiveMapper().GetClientTags();
                    loadGWClientNodes();
                }
            }
            else
            {
                tsConfigurationBtnCopy.Enabled = false;
                tsConfigurationBtnEdit.Enabled = false;
                tsConfigurationBtnDelete.Enabled = false;
                DisableAllMappers();
                tcClientServer.Visible = false;
            }

        }
        private void lstConfigurations_MouseDown(object sender, MouseEventArgs e)
        {
            var index = lstConfigurations.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                if (lstConfigurations.SelectedIndex != index)
                    lstConfigurations.SelectedIndex = index;
                createConfigurationToolStripMenuItem.Visible = false;
                copyConfigurationToolStripMenuItem.Visible = true;
                editConfigurationToolStripMenuItem.Visible = true;
                deleteConfigurationToolStripMenuItem.Visible = true;
            }
            else
            {
                createConfigurationToolStripMenuItem.Visible = true;
                copyConfigurationToolStripMenuItem.Visible = false;
                editConfigurationToolStripMenuItem.Visible = false;
                deleteConfigurationToolStripMenuItem.Visible = false;
            }
            if (e.Button != MouseButtons.Right) return;
            ctxListConfigutations.Show(Cursor.Position);
            ctxListConfigutations.Visible = true;
        }
        private void creaNuovaConfigurazioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateConfiguration();
        }
        private void createConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateConfiguration();
        }
        private void tsConfigurationBtnAdd_Click(object sender, EventArgs e)
        {
            CreateConfiguration();
        }
        private void btnEditClientConfiguration_Click(object sender, EventArgs e)
        {
            EditConfiguration();
        }
        private void editConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditConfiguration();
        }
        private void tsConfigurationBtnEdit_Click(object sender, EventArgs e)
        {
            EditConfiguration();
        }
        private void realoadConfigurationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadConfigurations();
        }
        private void tsConfigurationBtnRefresh_Click(object sender, EventArgs e)
        {
            LoadConfigurations();
        }
        private void copyConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyConfiguration();
        }
        private void tsConfigurationBtnCopy_Click(object sender, EventArgs e)
        {
            CopyConfiguration();
        }
        private void deleteConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteConfiguration();
        }
        private void tsConfigurationBtnDelete_Click(object sender, EventArgs e)
        {
            DeleteConfiguration();
        }
        #endregion

        #endregion

        #region Client
        private void CreateTreeView()
        {
            var mapper = GetActiveMapper();
            if (mapper != null)
            {
                try
                {
                    twClientNodes.GridNodes.Clear();
                    var rootNode = twClientNodes.GridNodes.Add(mapper.ClientMapping.Name);
                    foreach (OpcTag tag in mapper.ClientMapping.Childrens)
                    {
                        createTreeGridChildren(tag, ref rootNode);
                    }
                }
                catch
                {
                    _log.WriteWarning("Unable to create Client nodes treeview!");
                }
            }
            twClientNodes.ExpandAll();
        }
        private void createTreeGridChildren(OpcTag tag, ref KryptonTreeGridNodeRow parent)
        {
            var child = parent.Nodes.Add(tag.NodeId);
            child.Cells[TWCLIENT_CELL_NAME].Value = tag.Name;
            child.Cells[TWCLIENT_CELL_VALUE].Value = tag.Value;
            child.Cells[TWCLIENT_CELL_TIMESTAMP].Value = tag.Timestamp;
            child.Cells[TWCLIENT_CELL_STATUS].Value = tag.Status;
            child.Cells[TWCLIENT_CELL_SUBSCRIBED].Value = tag.IsSubscribed();
            if (tag.Childrens.Count > 0)
                foreach (var children in tag.Childrens)
                    createTreeGridChildren(children, ref child);
        }
        private void UpdateTreeViewNode(OpcTag tag)
        {
            FindAndUpdateNode(tag, twClientNodes.GridNodes.First());
        }
        private void FindAndUpdateNode(OpcTag tag, KryptonTreeGridNodeRow row)
        {
            try
            {
                if (row.Cells[TWCLIENT_CELL_NODEID].Value.ToString() == tag.NodeId)
                {
                    row.Cells[TWCLIENT_CELL_VALUE].Value = tag.Value;
                    row.Cells[TWCLIENT_CELL_TIMESTAMP].Value = tag.Timestamp;
                    row.Cells[TWCLIENT_CELL_STATUS].Value = tag.Status;
                    row.Cells[TWCLIENT_CELL_SUBSCRIBED].Value = (tag.SubscriptionID != string.Empty);
                }
                else
                {
                    foreach (KryptonTreeGridNodeRow children in row.Nodes)
                        FindAndUpdateNode(tag, children);
                }
            }
            catch (Exception ex)
            {
                _log.WriteError("Unable to update node on Treeview!");
            }
        }
        private void tabClientConnectChanged(bool clientIsConnected)
        {
            if (clientIsConnected)
            {
                lblClientStatus.Text = "Connected";
                lblClientStatus.ForeColor = Color.Green;
                btnRunClientDiscovery.Enabled = true;
                btnRegisterRoutine.Enabled = true;
                readSyncronouslyToolStripMenuItem.Enabled = true;
                writeSyncronouslyToolStripMenuItem.Enabled = true;
                btnClientConnect.Text = "Disconnect";
            }
            else
            {
                lblClientStatus.Text = "Disconnected";
                lblClientStatus.ForeColor = Color.Red;
                btnRunClientDiscovery.Enabled = false;
                btnRegisterRoutine.Enabled = false;
                btnClientConnect.Text = "Connect";
                readSyncronouslyToolStripMenuItem.Enabled = false;
                writeSyncronouslyToolStripMenuItem.Enabled = false;
            }
        }
        private void loadGWClientNodes()
        {
            var mapper = GetActiveMapper();
            if (mapper != null)
            {
                CreateTreeView();
                try
                {
                    dgRoutines.DataSource = GetActiveMapper().dtRoutines;
                }
                catch
                {
                    _log.WriteWarning("Unable to create server routine table!");
                }
            }
        }

        #region Events
        private void btnClientConnect_Click(object sender, EventArgs e)
        {
            MapperManager mapper = GetActiveMapper();
            if (mapper != null)
                tabClientConnectChanged(mapper.ConnectOrDisconnectClient());
        }
        private void btnRunClientDiscovery_Click(object sender, EventArgs e)
        {
            var mapper = GetActiveMapper();
            if (mapper != null)
            {
                if (mapper.IsClientConected())
                {
                    mapper.RunClientDiscovery();
                    mapper.GetClientTags();
                    loadGWClientNodes();
                }
            }
        }
        private void btnExploreRoutines_Click(object sender, EventArgs e)
        {
            var mapper = GetActiveMapper();
            if (mapper != null)
            {
                mapper.OpenRoutineEditor();
            }
        }
        private void btnRegisterRoutine_Click(object sender, EventArgs e)
        {
            MapperManager mapper = GetActiveMapper();
            if (mapper != null)
            {
                if (mapper.IsRoutineRecordingRunning())
                    mapper.RoutineRecordingEnd();
                else
                    mapper.RoutineRecordingStart();
            }
        }
        private void tmrRoutine_Tick(object sender, EventArgs e)
        {
            var mapper = GetActiveMapper();
            if (mapper != null)
            {
                lblRoutineLenght.Text = mapper.GetStopwatchTimeElapsed();
            }
        }
        private void btnSubscibeTags_Click(object sender, EventArgs e)
        {
            var mapper = GetActiveMapper();
            if (mapper != null)
            {
                mapper.SubscribeTags();
                CreateTreeView();
            }
        }


        private void readSyncronouslyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var _mapper = GetActiveMapper();
            if (_mapper != null)
            {
                if (twClientNodes.SelectedRows.Count <= 0)
                    return;
                foreach (DataGridViewRow row in twClientNodes.SelectedRows)
                {
                    _mapper.ClientReadValue(row.Cells[TWCLIENT_CELL_NODEID].Value.ToString());
                }
            }
        }
        private void writeSyncronouslyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var _mapper = GetActiveMapper();
            if (_mapper != null)
            {
                if (twClientNodes.SelectedRows.Count <= 0)
                    return;
                foreach (DataGridViewRow dgRow in twClientNodes.SelectedRows)
                {
                    if (!string.IsNullOrEmpty(dgRow.Cells[TWCLIENT_CELL_NODEID].Value.ToString()))
                    {
                        frmWriteSynchro dialog = new frmWriteSynchro(dgRow.Cells[TWCLIENT_CELL_NODEID].Value.ToString(), dgRow.Cells[TWCLIENT_CELL_VALUE].Value.ToString());
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            _mapper.ClientWriteValue(dialog.GetTag(), dialog.GetValue());
                        }
                    }
                }
            }
        }
        #endregion
        #endregion

        #region Server
        private void btnStartSimulationServer_Click(object sender, EventArgs e)
        {
            var mapper = GetActiveMapper();
            if (mapper != null)
            {
                var serverStarting = mapper.LaunchServer().Result;
                tabServerConnectChanged(serverStarting);
                loadGWClientNodes();
            }
        }
        private void btnAddRoutine_Click(object sender, EventArgs e)
        {
            var mapper = GetActiveMapper();
            if (mapper != null)
            {
                var dlg = new dialogSelectRoutine(mapper.Name);
                if (dlg.ShowDialog() == DialogResult.OK)
                    mapper.AddRoutine(dlg.SelectedRoutine); 
            }

        }
        private void dgRoutines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgRoutines.Columns[0].ContextMenuStrip = ctxRoutineTables;
                dgRoutines.Columns[1].ContextMenuStrip = ctxRoutineTables;
                dgRoutines.Columns[2].ContextMenuStrip = ctxRoutineTables;
                dgRoutines.Columns[3].ContextMenuStrip = ctxRoutineTables;
            }

            catch
            {

            }
        }
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgRoutines.SelectedRows.Count > 0)
            {
                string name = dgRoutines.SelectedRows[0].Cells[0].Value.ToString();
                var mapper = GetActiveMapper();
                if (mapper != null)
                {
                    mapper.StartRoutine(name);
                }
            }
        }
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgRoutines.SelectedRows.Count > 0)
            {
                string name = dgRoutines.SelectedRows[0].Cells[0].Value.ToString();
                var mapper = GetActiveMapper();
                if (mapper != null)
                {
                    mapper.PauseOrResumeRoutine(name);
                }
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgRoutines.SelectedRows.Count > 0)
            {
                string name = dgRoutines.SelectedRows[0].Cells[0].Value.ToString();
                var mapper = GetActiveMapper();
                if (mapper != null)
                {
                    mapper.StopRoutine(name);
                }
            }
        }
        private void tabServerConnectChanged(bool serverIsConnected)
        {
            if (serverIsConnected)
            {
                lblServerStatus.Text = "Connected";
                lblServerStatus.ForeColor = Color.Green;
                btnAddRoutine.Enabled = true;
                btnStartSimulationServer.Text = "Stop Server";
                startToolStripMenuItem.Enabled = true;
                pauseToolStripMenuItem.Enabled = true;
                stopToolStripMenuItem.Enabled = true;
            }
            else
            {
                lblServerStatus.Text = "Disconnected";
                lblServerStatus.ForeColor = Color.Red;
                btnAddRoutine.Enabled = false;
                btnStartSimulationServer.Text = "Start Server";
                startToolStripMenuItem.Enabled = false;
                pauseToolStripMenuItem.Enabled = false;
                stopToolStripMenuItem.Enabled = false;
            }
        }
        private void btnEditServerConfiguration_Click(object sender, EventArgs e)
        {
            var mapper = GetActiveMapper();
            if (mapper != null)
            {
                var frmConfig = new frmServerConfiguration(mapper.Name);
                if (frmConfig.ShowDialog() == DialogResult.OK)
                {
                    frmConfig.GetConfiguration().Store();
                    mapper.ReloadServerConfiguration();
                }
            }
        }
        #endregion


        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void importaConfigurazioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Plc Scanner Configuration File |*.PLSCFX";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ZipFile.ExtractToDirectory(ofd.FileName, Helper.GetPath(PathType.MAIN));
            }
        }

        private void esportaConfigurazioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Plc Scanner Configuration File |*.PLSCFX";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ZipFile.CreateFromDirectory(Helper.GetPath(PathType.ProjectFolder, GetActiveMapper().Name), sfd.FileName);
            }
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
