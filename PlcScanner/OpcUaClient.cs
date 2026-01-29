using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;
using PlcScanner.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace PlcScanner
{
    public class OpcUaClient
    {
        protected ApplicationConfiguration _config;
        private PlcConfiguration _plcConfig;
        public LogHandler _log;
        private ISession _session;
        private SessionReconnectHandler _reconnectHandler;
        private bool _reconnecting;
        public OpcUaClient(PlcConfiguration config)
        {
            _log = new LogHandler(LogType.Client, config.LogLevel, config.ConfigurationName);
            _plcConfig = config;
            try
            {
                _config = new ApplicationConfiguration
                {
                    ApplicationName = "PlcScanner",
                    ApplicationType = ApplicationType.Client,
                    SecurityConfiguration = new SecurityConfiguration
                    {
                        AutoAcceptUntrustedCertificates = true,
                        ApplicationCertificate = new CertificateIdentifier
                        {
                            StorePath = config.CertificateStorePath,
                            StoreType = config.CertificateStoreType,
                            SubjectName = config.CertificateSubjectName
                        }
                    },
                    TransportConfigurations = new TransportConfigurationCollection(),
                    TransportQuotas = new TransportQuotas { OperationTimeout = 15000 },
                    ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 60000 }
                };
                _config.Validate(ApplicationType.Client);
            }
            catch (Exception ex)
            {
                _log.WriteCritical($"Unable to validate the connection! Error: [{ex.Message}]");
            }
        }
        public PlcConfiguration GetPlcConfiguration()
        {
            return _plcConfig;
        }
        public bool IsConnected()
        {
            if (_session == null)
                return false;
            if (!_session.Connected)
                return false;
            if (_reconnecting)
                return false;
            return true;
        }
        private void Session_KeepAlive(ISession session, KeepAliveEventArgs e)
        {
            if (ServiceResult.IsBad(e.Status))
            {
                if (!_reconnecting)
                {
                    _reconnecting = true;

                    _reconnectHandler = new SessionReconnectHandler();
                    _reconnectHandler.BeginReconnect(
                        session,
                        5000,
                        Client_ReconnectComplete);
                }
            }
        }
        private void Client_ReconnectComplete(object sender, EventArgs e)
        {
            if (!ReferenceEquals(sender, _reconnectHandler))
                return;

            _session = _reconnectHandler.Session;
            _reconnectHandler.Dispose();
            _reconnectHandler = null;
            _reconnecting = false;

        }

        public List<EndpointDescription> GetEndpointDescriptions()
        {
            try
            {
                DiscoveryClient _dClient = DiscoveryClient.Create(new Uri(_plcConfig.EndpointUrl));

                List<EndpointDescription> endpointList = _dClient.GetEndpoints(null).ToList();

                _dClient.Close();
                _dClient.Dispose();
                return endpointList.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to discover endpoints for [{_plcConfig.EndpointUrl}]. Error [{ex.Message}]");
            }
        }
        public void SessionClosed(object sender, EventArgs e)
        {
            _log.WriteInfo($"Session has been closed! [{e.ToString()}]");
        }
        private string GetDataTypeName(VariableNode node)
        {
            if (node?.DataType == null)
                return null;
            try
            {
                var dataTypeNode = _session.ReadNode(node.DataType);
                return dataTypeNode?.DisplayName?.Text;
            }
            catch
            {
                return node.DataType.ToString();
            }
        }
        public void RunDiscovery()
        {
            OpcNode rootNode = BrowseNodeRecursively(_plcConfig.DiscoveryNodeId);
            XElement RootNodeXML = GenerateXml(rootNode);
            XElement ParentNode = new XElement("OpcUaModel");
            ParentNode.Add(RootNodeXML);
            XDocument XmlDocument = new XDocument(ParentNode);
            XmlDocument.Save(System.IO.Path.Combine(Helper.GetPath(PathType.Client, _plcConfig.ConfigurationName), "Mapping.xml")); ;
        }

        private IEnumerable<ReferenceDescription> GetAllReferences(BrowseResultCollection results)
        {
            var references = new List<ReferenceDescription>();
            if (results == null || results.Count == 0)
                return references;

            var result = results[0];
            references.AddRange(result.References);

            while (result.ContinuationPoint != null && result.ContinuationPoint.Length > 0)
            {
                _session.BrowseNext(null,
                                    false,
                                    new ByteStringCollection { result.ContinuationPoint },
                                    out BrowseResultCollection nextResults,
                                    out _);
                result = nextResults[0];
                references.AddRange(result.References);
            }
            return references;
        }
        public OpcNode BrowseNodeRecursively(NodeId nodeId)
        {
            var node = _session.ReadNode(nodeId);

            var opcNode = new OpcNode
            {
                Name = node.DisplayName.Text,
                NodeId = node.NodeId.ToString(),
                NodeClass = node.NodeClass,
            };

            if (node is VariableNode variable)
            {
                opcNode.DataType = GetDataTypeName(variable);

                opcNode.ValueRank = variable.ValueRank;

                if (variable.ValueRank >= ValueRanks.OneDimension)
                {
                    opcNode.ArrayDimensions = variable.ArrayDimensions;
                }
            }

            BrowseDescription browseDescription = new BrowseDescription
            {
                NodeId = nodeId,
                BrowseDirection = BrowseDirection.Forward,
                ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences,
                IncludeSubtypes = true,
                NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable),
                ResultMask = (uint)BrowseResultMask.All
            };


            _session.Browse(null,
                            null,
                            0,
                            new BrowseDescriptionCollection { browseDescription },
                            out BrowseResultCollection results,
                            out DiagnosticInfoCollection diagnosticInfos);
            foreach (var reference in GetAllReferences(results))
            {
                var childNodeId = ExpandedNodeId.ToNodeId(reference.NodeId, _session.NamespaceUris);
                opcNode.Children.Add(BrowseNodeRecursively(childNodeId));
            }
            if (opcNode.Children.Count > 0 &&
                opcNode.ValueRank != ValueRanks.OneDimension)
            {
                opcNode.DataType = "Folder";
            }
            return opcNode;
        }
        public XElement GenerateXml(OpcNode node)
        {

            XElement element = node.NodeClass == NodeClass.Variable ?
                                new XElement("Variable",
                                    new XAttribute("Name", node.Name),
                                    new XAttribute("NodeId", node.NodeId),
                                    new XAttribute("DataType", node.DataType))
                                : new XElement("Folder",
                                    new XAttribute("Name", node.Name),
                                    new XAttribute("NodeId", node.NodeId));

            foreach (var child in node.Children)
                element.Add(GenerateXml(child));

            return element;
        }
        public bool Connect()
        {
            try
            {
                EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(_config);
                List<EndpointDescription> endpointCollection = GetEndpointDescriptions();
                EndpointDescription endpointDescription = endpointCollection.FirstOrDefault(ed => ed.SecurityMode == _plcConfig.SecurityMode);
                if (endpointConfiguration == null && _plcConfig.SecurityMode != MessageSecurityMode.None)
                {
                    endpointDescription = endpointCollection.FirstOrDefault(ed => ed.SecurityMode == MessageSecurityMode.None);
                    if (endpointDescription != null)
                    {
                        _log.WriteInfo($"MessageSecurityMode requested [{_plcConfig.SecurityMode}] not supported by Plc. MessageSecurityMode [{MessageSecurityMode.None}] enabled instead.");
                    }
                }

                if (endpointDescription == null)
                {
                    _log.WriteError($"Unable to find an endpoint with securityMode [{_plcConfig.SecurityMode}] or [{MessageSecurityMode.None}] ");
                    throw new Exception($"Unable to find an endpoint with securityMode [{_plcConfig.SecurityMode}] or [{MessageSecurityMode.None}] ");
                }
                var configuredEndpoint = new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);

                if (endpointDescription.SecurityMode != MessageSecurityMode.None)
                {
                    _config.SecurityConfiguration.AddAppCertToTrustedStore = true;
                    CertificateIdentifier sc = new CertificateIdentifier(endpointDescription.ServerCertificate);
                    _config.SecurityConfiguration.TrustedPeerCertificates.TrustedCertificates.Add(sc);
                    _config.SecurityConfiguration.TrustedIssuerCertificates.TrustedCertificates.Add(sc);
                }
                try
                {
                    Session session = Session.Create(
                        _config,
                        configuredEndpoint,
                        false,
                        false,
                        _config.ApplicationName,
                        (uint)_plcConfig.ClientTimeout,
                        new UserIdentity(),
                        new List<string>()
                    ).Result;

                    if (session != null && session.Connected)
                    {
                        _session = session;
                        _session.SessionClosing += SessionClosed;
                        _session.KeepAlive += Session_KeepAlive;
                        _log.WriteInfo($"Session created successfully!");
                        return true;
                    }
                    return false;
                }
                catch (AggregateException agEx)
                {
                    foreach (var ex in agEx.InnerExceptions)
                    {
                        _log.WriteError($"Unable to open session: Error [{ex.GetType()}][{ex.Message}]");
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                _log.WriteError($"Unable to Connect! Error [{ex.Message}]");
                return false;
            }

        }
        public bool Disconnect()
        {
            if (_session == null)
                return true;

            if (!_session.Connected)
                return true;
            try
            {
                _session.Close();
                _session.Dispose();
            }
            catch (AggregateException agEx)
            {
                foreach (var ex in agEx.InnerExceptions)
                {
                    _log.WriteError($"Unable to close and dispose session! Error [{ex.Message}]");
                }
                return false;
            }
            catch (Exception ex)
            {
                _log.WriteError($"Unable to close and dispose session! Error [{ex.Message}]");
                return false;
            }
            return true;
        }
        public void RemoveSubscription(string subscriptionId, string nodeId)
        {
            if (_session == null || !_session.Connected)
            {
                _log.WriteError("Session is not connected!");
                return;
            }
            if (_session.SubscriptionCount == 0)
            {
                _log.WriteError($"No subscription is active! Unable to remove subscription [{subscriptionId}]");
                return;
            }
            try
            {
                var comparableNodeId = new NodeId(nodeId);
                var subscriptionFound = _session.Subscriptions.First(item => item.Id == uint.Parse(subscriptionId));
                var itemFound = subscriptionFound.MonitoredItems.First(item => item.StartNodeId == comparableNodeId);
                subscriptionFound.RemoveItem(itemFound);
                if(subscriptionFound.MonitoredItems.Count() <= 0)
                {
                    subscriptionFound.Delete(true);
                    _session.RemoveSubscription(subscriptionFound);
                }
            }
            catch (Exception ex)
            {
                _log.WriteError($"Unable to remove subscription. Error [{ex.Message}]");
            }
        }
        public Dictionary<string, string> SubscribeTags(
            List<OpcTag> tags,
            int publishingInterval,
            MonitoredItemNotificationEventHandler callback)
        {
            if (_session == null || !_session.Connected)
            {
                _log.WriteError("Session is not connected!");
                return null;
            }

            var nodeIdToSubscription = new Dictionary<string, string>();

            const int chunkSize = 100;
            var tagChunks = tags
                .Select((tag, index) => new { tag, index })
                .GroupBy(x => x.index / chunkSize)
                .Select(g => g.Select(x => x.tag).ToList())
                .ToList();

            foreach (var chunk in tagChunks)
            {
                var subscription = _session.Subscriptions?
                    .FirstOrDefault(s => s.MonitoredItems.Count() + chunk.Count <= 100);

                bool isNewSubscription = false;

                if (subscription == null)
                {
                    subscription = new Subscription(_session.DefaultSubscription)
                    {
                        PublishingInterval = publishingInterval,
                        KeepAliveCount = 10,
                        LifetimeCount = 20,
                        PublishingEnabled = true
                    };
                    isNewSubscription = true;
                }

                var monitoredItems = new List<MonitoredItem>();

                foreach (var tag in chunk)
                {
                    var monitoredItem = new MonitoredItem(subscription.DefaultItem)
                    {
                        DisplayName = tag.Name,
                        StartNodeId = tag.NodeId,
                        SamplingInterval = 50,
                        QueueSize = 50,
                        DiscardOldest = true
                    };

                    monitoredItem.Notification += callback;
                    monitoredItems.Add(monitoredItem);
                }

                subscription.AddItems(monitoredItems);

                if (isNewSubscription)
                {
                    _session.AddSubscription(subscription);
                    subscription.Create();
                    subscription = _session.Subscriptions.Last();
                }
                foreach(var tag in chunk)
                {
                    nodeIdToSubscription[tag.NodeId] = subscription.Id.ToString();
                }

            }

            return nodeIdToSubscription;
        }
        public KeyValuePair<string, DateTime> ReadValue(string nodeId)
        {
            string responseValue = string.Empty;
            DateTime responseTimestamp = DateTime.MinValue;
            try
            {
                if (_session == null)
                    return new KeyValuePair<string, DateTime>(responseValue, responseTimestamp);
                if (!_session.Connected)
                    return new KeyValuePair<string, DateTime>(responseValue, responseTimestamp);
                var value = _session.ReadValue(nodeId);
                if (value != null && StatusCode.IsGood(value.StatusCode))
                {
                    responseValue = value.ToString();
                    responseTimestamp = value.ServerTimestamp;
                }
            } catch (Exception ex)
            {
                _log.WriteError($"Unable to read tag [{nodeId}] - Error: [{ex.Message}]");
            }
            return new KeyValuePair<string, DateTime>(responseValue, responseTimestamp);
        }
        public bool WriteValue(string address, string value)
        {
            try
            {
                NodeId nodeId = new NodeId(address);

                WriteValue val = new WriteValue();
                val.Value = _session.ReadValue(nodeId);
                val.NodeId = nodeId;
                val.AttributeId = Attributes.Value;
                val.Value.Value = CastValue(val.Value, value);
                val.Value.StatusCode = StatusCodes.Good;
                val.Value.ServerTimestamp = DateTime.MinValue;
                val.Value.SourceTimestamp = DateTime.MinValue;

                WriteValueCollection coll = new WriteValueCollection
                {
                    val
                };

                _session.Write(null, coll, out StatusCodeCollection result, out DiagnosticInfoCollection diagnosticInfos);

                ClientBase.ValidateResponse(result, coll);
                ClientBase.ValidateDiagnosticInfos(diagnosticInfos, coll);

                if (StatusCode.IsBad(result[0]))
                {
                    _log.WriteError($"Unable to write on NodeId [{address}] value [{value}]");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                _log.WriteError($"Unable to write on NodeId [{address}] value [{value}], Error: [{ex.Message}]");
                return false;
            }
        }
        private object CastValue(DataValue input, object output)
        {
            if (input?.WrappedValue.TypeInfo == null)
                return output;

            var typeInfo = input.WrappedValue.TypeInfo;

            // 🔹 ARRAY (1D)
            if (typeInfo.ValueRank == ValueRanks.OneDimension)
            {
                // L'array deve già essere del tipo corretto
                return CastArray(typeInfo.BuiltInType, output);
            }

            // 🔹 SCALARE
            if (typeInfo.ValueRank == ValueRanks.Scalar)
            {
                return CastScalar(typeInfo.BuiltInType, output);
            }

            // Fallback
            return output;
        }
        private object CastScalar(BuiltInType type, object value)
        {
            if (value == null)
                return null;

            switch (type)
            {
                case BuiltInType.Boolean:
                    return Convert.ToBoolean(value);

                case BuiltInType.SByte:
                    return Convert.ToSByte(value);

                case BuiltInType.Byte:
                    return Convert.ToByte(value);

                case BuiltInType.Int16:
                    return Convert.ToInt16(value);

                case BuiltInType.UInt16:
                    return Convert.ToUInt16(value);

                case BuiltInType.Int32:
                    return Convert.ToInt32(value);

                case BuiltInType.UInt32:
                    return Convert.ToUInt32(value);

                case BuiltInType.Int64:
                    return Convert.ToInt64(value);

                case BuiltInType.UInt64:
                    return Convert.ToUInt64(value);

                case BuiltInType.Float:
                    return Convert.ToSingle(value);

                case BuiltInType.Double:
                    return Convert.ToDouble(value);

                case BuiltInType.String:
                    return Convert.ToString(value);

                case BuiltInType.DateTime:
                    return Convert.ToDateTime(value);

                case BuiltInType.Guid:
                    return value is Guid g ? g : Guid.Parse(value.ToString());

                case BuiltInType.ByteString:
                    return value as byte[] ?? Convert.FromBase64String(value.ToString());

                case BuiltInType.XmlElement:
                    return value.ToString();

                case BuiltInType.NodeId:
                    return value is NodeId nid ? nid : NodeId.Parse(value.ToString());

                case BuiltInType.ExpandedNodeId:
                    return value is ExpandedNodeId enid ? enid : ExpandedNodeId.Parse(value.ToString());

                case BuiltInType.StatusCode:
                    return value is StatusCode sc ? sc : new StatusCode(Convert.ToUInt32(value));

                case BuiltInType.QualifiedName:
                    return value is QualifiedName qn
                        ? qn
                        : QualifiedName.Parse(value.ToString());

                case BuiltInType.LocalizedText:
                    return value is LocalizedText lt
                        ? lt
                        : new LocalizedText(value.ToString());

                case BuiltInType.Variant:
                    return value is Variant v ? v : new Variant(value);

                case BuiltInType.Enumeration:
                    return Convert.ToInt32(value);

                default:
                    return value;
            }
        }
        private object CastArray(BuiltInType type, object value)
        {
            if (value == null)
                return null;

            // Se è già un array corretto
            if (value.GetType().IsArray)
                return value;

            // Se arriva come stringa (es. "1,2,3")
            if (value is string s)
            {
                var tokens = s.Split(',');
                tokens.ToList().RemoveAll(v => string.IsNullOrEmpty(v));
                return CastArrayFromStrings(type, tokens);
            }

            return value;
        }
        private object CastArrayFromStrings(BuiltInType type, string[] values)
        {
            switch (type)
            {
                case BuiltInType.Boolean:
                    return values.Select(v => Convert.ToBoolean(v)).ToArray();

                case BuiltInType.SByte:
                    return values.Select(v => Convert.ToSByte(v)).ToArray();

                case BuiltInType.Byte:
                    return values.Select(v => Convert.ToByte(v)).ToArray();

                case BuiltInType.Int16:
                    return values.Select(v => Convert.ToInt16(v)).ToArray();

                case BuiltInType.UInt16:
                    return values.Select(v => Convert.ToUInt16(v)).ToArray();

                case BuiltInType.Int32:
                    return values.Select(v => Convert.ToInt32(v)).ToArray();

                case BuiltInType.UInt32:
                    return values.Select(v => Convert.ToUInt32(v)).ToArray();

                case BuiltInType.Int64:
                    return values.Select(v => Convert.ToInt64(v)).ToArray();

                case BuiltInType.UInt64:
                    return values.Select(v => Convert.ToUInt64(v)).ToArray();

                case BuiltInType.Float:
                    return values.Select(v => Convert.ToSingle(v)).ToArray();

                case BuiltInType.Double:
                    return values.Select(v => Convert.ToDouble(v)).ToArray();

                case BuiltInType.DateTime:
                    return values.Select(v => Convert.ToDateTime(v)).ToArray();

                case BuiltInType.Guid:
                    return values.Select(v => Guid.Parse(v)).ToArray();

                case BuiltInType.String:
                    return values;

                default:
                    return values;
            }
        }
    }
    public class OpcNode
    {
        public string Name { get; set; }
        public string NodeId { get; set; }
        public NodeClass NodeClass { get; set; }
        public string DataType { get; set; }
        public int ValueRank { get; set; } = ValueRanks.Scalar;
        public IList<uint> ArrayDimensions { get; set; }
        public List<OpcNode> Children { get; set; } = new List<OpcNode>();
    }
}
