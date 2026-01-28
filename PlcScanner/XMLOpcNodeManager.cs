using Opc.Ua;
using Opc.Ua.Server;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace PlcScanner
{
    public class XMLOpcNodeManager : CustomNodeManager2
    {
        private ushort _ns = 0;
        public Dictionary<NodeId, BaseDataVariableState> variables = new Dictionary<NodeId, BaseDataVariableState>();
        private LogHandler _log;
        public string Name { get; set; }
        public XMLOpcNodeManager(IServerInternal server, ApplicationConfiguration config, string name) : base(server, config, "http://simulator/opcua/xml")
        {
            SystemContext.NodeIdFactory = this;
            Name = name;
        }
        public void SetLogger(LogHandler lh)
        {
            this._log = lh;
        }
        public override void CreateAddressSpace(IDictionary<NodeId, IList<IReference>> externalReferences)
        {
            _ns = NamespaceIndex;

            var FilePath = Path.Combine(Helper.GetPath(PathType.Client, this.Name), "Mapping.xml");
            var xml = XDocument.Load(FilePath);
            _log.WriteDebug("Creating Object Folder");
            if (!externalReferences.TryGetValue(
            ObjectIds.ObjectsFolder,
            out IList<IReference> references))
            {
                _log.WriteDebug("Object Folder Not Found!");
                externalReferences[ObjectIds.ObjectsFolder] = references =
                    new List<IReference>();
            }

            var rootFolder = CreateFolder(null, "PLC", references);
            BuildRecursively(rootFolder, xml.Root.Element("Folder"));

        }
        public void BuildRecursively(NodeState parent, XElement element)
        {
            foreach (var folder in element.Elements("Folder"))
            {
                var f = CreateFolder(parent, folder.Attribute("Name").Value);
                _log.WriteDebug($"Created Folder [{folder.Attribute("Name").Value}]");
                BuildRecursively(f, folder);
            }
            foreach (var variable in element.Elements("Variable"))
            {
                var vname = variable.Attribute("Name").Value;
                var vtype = ParseType(variable.Attribute("DataType").Value);

                int valueRank = ValueRanks.Scalar;
                uint[] arrayDimension = null;
                if(variable.Attribute("ValueRank") != null)
                {
                    valueRank = int.Parse(variable.Attribute("ValueRank").Value);
                }
                if (variable.Attribute("ArrayDimension") != null)
                {
                    arrayDimension = variable.Attribute("ArrayDimension").Value.Split(',').Select(v => uint.Parse(v.Trim())).ToArray();
                }
                    CreateVariable(
                    parent,
                    vname,
                    vtype,
                    valueRank,
                    arrayDimension
                    );
                _log.WriteDebug($"Created Variable [{variable.Attribute("Name").Value}]");
            }
        }
        private NodeId ParseType(string type)
        {
            switch (type)
            {
                case "Double":
                    return DataTypeIds.Double;
                case "Boolean":
                    return DataTypeIds.Boolean;
                case "Int32":
                    return DataTypeIds.Int32;
                default:
                    return DataTypeIds.String;
            }
        }
        private object GetDefaultValue(NodeId type, int valueRank, uint[] arrayDimension)
        {
            if (valueRank == ValueRanks.Scalar)
                return GetDefaultScalar(type);

            // 🔹 ARRAY
            int length = 0;

            if (arrayDimension != null && arrayDimension.Length > 0)
                length = (int)arrayDimension[0];

            if (length <= 0)
                return Array.Empty<object>();

            // Tipi primitivi
            if (type == DataTypeIds.Boolean) return new bool[length];

            if (type == DataTypeIds.SByte) return new sbyte[length];
            if (type == DataTypeIds.Byte) return new byte[length];

            if (type == DataTypeIds.Int16) return new short[length];
            if (type == DataTypeIds.UInt16) return new ushort[length];

            if (type == DataTypeIds.Int32) return new int[length];
            if (type == DataTypeIds.UInt32) return new uint[length];

            if (type == DataTypeIds.Int64) return new long[length];
            if (type == DataTypeIds.UInt64) return new ulong[length];

            if (type == DataTypeIds.Float) return new float[length];
            if (type == DataTypeIds.Double) return new double[length];

            if (type == DataTypeIds.String) return new string[length];

            if (type == DataTypeIds.DateTime) return new DateTime[length];

            if (type == DataTypeIds.Guid) return new Guid[length];

            if (type == DataTypeIds.ByteString) return new byte[length][];

            if (type == DataTypeIds.XmlElement) return new string[length];

            if (type == DataTypeIds.NodeId) return new NodeId[length];

            if (type == DataTypeIds.ExpandedNodeId) return new ExpandedNodeId[length];

            if (type == DataTypeIds.StatusCode) return new StatusCode[length];

            if (type == DataTypeIds.QualifiedName) return new QualifiedName[length];

            if (type == DataTypeIds.LocalizedText) return new LocalizedText[length];

            return new Variant[length];
        }
        private object GetDefaultScalar(NodeId type)
        {
            if (type == DataTypeIds.Boolean) return false;

            if (type == DataTypeIds.SByte) return (sbyte)0;
            if (type == DataTypeIds.Byte) return (byte)0;

            if (type == DataTypeIds.Int16) return (short)0;
            if (type == DataTypeIds.UInt16) return (ushort)0;

            if (type == DataTypeIds.Int32) return 0;
            if (type == DataTypeIds.UInt32) return (uint)0;

            if (type == DataTypeIds.Int64) return (long)0;
            if (type == DataTypeIds.UInt64) return (ulong)0;

            if (type == DataTypeIds.Float) return 0f;
            if (type == DataTypeIds.Double) return 0d;

            if (type == DataTypeIds.String) return string.Empty;

            if (type == DataTypeIds.DateTime) return DateTime.UtcNow;

            if (type == DataTypeIds.Guid) return Guid.Empty;

            if (type == DataTypeIds.ByteString) return Array.Empty<byte>();

            if (type == DataTypeIds.XmlElement) return string.Empty;

            if (type == DataTypeIds.NodeId) return NodeId.Null;

            if (type == DataTypeIds.ExpandedNodeId) return ExpandedNodeId.Null;

            if (type == DataTypeIds.StatusCode) return StatusCodes.Good;

            if (type == DataTypeIds.QualifiedName) return QualifiedName.Null;

            if (type == DataTypeIds.LocalizedText) return LocalizedText.Null;

            // Enumeration → Int32
            return Variant.Null;
        }
        public FolderState CreateFolder(NodeState parent, string name, IList<IReference> rootReferences = null)
        {

            string identifier = (parent == null || parent?.NodeId.IdType == IdType.Numeric) ? $"Objects.{name}" : $"{parent?.NodeId.Identifier.ToString() ?? "Objects"}.{name}";
            var folder = new FolderState(parent)
            {
                BrowseName = new QualifiedName(name, NamespaceIndex),
                DisplayName = name,
                NodeId = new NodeId(identifier, NamespaceIndex)
            };
            if (parent == null)
            {
                _log.WriteDebug($"parent null [{identifier}]");
                rootReferences.Add(new NodeStateReference(
                    ReferenceTypeIds.Organizes,
                    false,
                    folder.NodeId));
            }
            parent?.AddChild(folder);
            AddPredefinedNode(SystemContext, folder);
            _log.WriteDebug($"Created Folder [{identifier}]");
            return folder;
        }
        public BaseDataVariableState CreateVariable(NodeState parent, string name, NodeId dataType, int valueRank, uint[] arrayDimension)
        {
            var nodeId = new NodeId($"{parent.NodeId.Identifier.ToString()}.{name}", NamespaceIndex);
            var variable = new BaseDataVariableState(parent)
            {
                BrowseName = new QualifiedName(name, _ns),
                DisplayName = name,
                NodeId = nodeId,
                DataType = dataType,
                ValueRank = valueRank,
                ArrayDimensions = arrayDimension,
                AccessLevel = AccessLevels.CurrentReadOrWrite,
                UserAccessLevel = AccessLevels.CurrentReadOrWrite,
                StatusCode = StatusCodes.Good,
                Timestamp = DateTime.UtcNow,
                Value = GetDefaultValue(dataType, valueRank, arrayDimension)
            };
            variable.OnSimpleWriteValue = OnVariableWrite;
            parent.AddChild(variable);
            AddPredefinedNode(SystemContext, variable);
            variables[nodeId] = variable;
            _log.WriteDebug($"Created Variable [{parent.NodeId.Identifier.ToString()}.{name}]");
            return variable;
        }


        ServiceResult OnVariableWrite(ISystemContext context, NodeState node, ref object value)
        {
            if (node is BaseDataVariableState variable)
            {
                var oldValue = variable.Value;

                // Detect changes
                if (!Equals(oldValue, value))
                {
                    string sessionIdentifier = "Anonymous";
                    try
                    {
                        if (context is ServerSystemContext)
                        {
                            sessionIdentifier = ((ServerSystemContext)context).UserIdentity.DisplayName;
                        } else
                        {
                            _log.WriteError($"Unable to retrive Session Identifier from system context, System Context is not ServerSystemContext., falling back to Anonymous");
                        }
                    } catch (Exception ex) { 
                        _log.WriteError($"Unable to retrive Session Identifier from system context, [{ex.Message}] falling back to Anonymous");
                    }
                    _log.WriteInfo($"User [{sessionIdentifier}] change value of node [{node.NodeId}] from [{oldValue}] -> [{value}]");
                }

                // Commit
                variable.Value = value;
            }
            return ServiceResult.Good;
        }
    }
}
