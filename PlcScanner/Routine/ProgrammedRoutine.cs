using Opc.Ua;
using Opc.Ua.Server;
using PlcScanner.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlcScanner.Routine
{
    public class ProgrammedRoutine : BaseRoutine
    {
        private readonly List<ProgrammedRoutineStep> _routineSteps;
        private readonly Dictionary<NodeId, BaseDataVariableState> _nodes;

        public ProgrammedRoutine(string name, IEnumerable<ProgrammedRoutineStep> steps, XMLOpcNodeManager nodeManager)
        {
            this.SetName(name);
            _routineSteps = steps.ToList();
            _nodes = nodeManager.variables;
        }

        private bool CheckConditions(List<TagCondition> conditions)
        {
            foreach (var condition in conditions)
            {
                BaseDataVariableState variable;
                if(condition.Type != (TagConditionType.BeforeTime | TagConditionType.AfterTime))
                {
                    var nodeID = NodeId.Parse(condition.NodeId);
                    if (!_nodes.TryGetValue(nodeID, out variable))
                    return false;
                } else
                {
                    _nodes.TryGetValue(new NodeId(), out variable);
                }


                    switch (condition.Type)
                    {
                        case TagConditionType.Equals:
                            if (variable.Value != ConvertValue(condition.Argument, variable.DataType))
                                return false;
                            break;
                        case TagConditionType.NotEquals:
                            if (variable.Value == ConvertValue(condition.Argument, variable.DataType))
                                return false;
                            break;
                        case TagConditionType.BiggerThan:
                            if (!IsBiggerThan(variable.Value, condition.Argument))
                                return false;
                            break;
                        case TagConditionType.LowerThan:
                            if (IsBiggerThan(variable.Value, condition.Argument))
                                return false;
                            break;
                        case TagConditionType.BeforeTime:
                            if (DateTime.Now.TimeOfDay > TimeSpan.Parse(condition.Argument))
                                return false;
                            break;
                        case TagConditionType.AfterTime:
                            if (DateTime.Now.TimeOfDay < TimeSpan.Parse(condition.Argument))
                                return false;
                            break;
                        case TagConditionType.StartsWith:
                            if (!variable.Value.ToString().StartsWith(condition.Argument))
                                return false;
                            break;
                        case TagConditionType.EndsWith:
                            if (!variable.Value.ToString().EndsWith(condition.Argument))
                                return false;
                            break;
                        case TagConditionType.Contains:
                            if (!variable.Value.ToString().Contains(condition.Argument))
                                return false;
                            break;
                        case TagConditionType.DoesNotContains:
                            if (variable.Value.ToString().Contains(condition.Argument))
                                return false;
                            break;
                        case TagConditionType.CountEquals:
                            if ((int)variable.ArrayDimensions[0] == int.Parse(condition.Argument))
                                return false;
                            break;
                        case TagConditionType.CountBiggerThan:
                            if ((int)variable.ArrayDimensions[0] > int.Parse(condition.Argument))
                                return false;
                            break;
                        case TagConditionType.CountLowerThan:
                            if ((int)variable.ArrayDimensions[0] < int.Parse(condition.Argument))
                                return false;
                            break;
                    }
            }
            return true;
        }
        private bool IsValidNodeId(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            try
            {
                var nodeId = NodeId.Parse(str);
                return nodeId != null; // se il parsing riesce, è valido
            }
            catch
            {
                return false; // parsing fallito → non valido
            }
        }
        private string GetValueFromNodeId(string str)
        {
            var nodeID = NodeId.Parse(str);
            if (!_nodes.TryGetValue(nodeID, out var variable))
                return null;
            return variable.Value.ToString();
        }
        private string CalculateIncrement(string nID, string val)
        {
            string currentValue = GetValueFromNodeId(nID);
            double result = double.Parse(currentValue) + double.Parse(val);
            return result.ToString();
        }
        private string CalculateDecrement(string nID, string val)
        {
            string currentValue = GetValueFromNodeId(nID);
            double result = double.Parse(currentValue) - double.Parse(val);
            return result.ToString();
        }
        private void RunActions(List<TagAction> actions, ServerSystemContext context)
        {
            foreach(TagAction action in actions)
            {
                string value = IsValidNodeId(action.Value) ? GetValueFromNodeId(action.Value) : action.Value;

                switch (action.Type)
                {
                    case TagActionType.Write:
                        ApplyEvent(action.NodeId, value, context);
                        break;
                    case TagActionType.Increment:
                        ApplyEvent(action.NodeId, CalculateIncrement(action.NodeId, value), context);
                        break;
                    case TagActionType.Decrement:
                        ApplyEvent(action.NodeId, CalculateDecrement(action.NodeId, value), context);
                        break;
                }
            }
        }
        protected override void ExecuteInternal(TimeSpan localTime, ServerSystemContext context)
        {
            foreach (ProgrammedRoutineStep step in _routineSteps)
            {
                if(step.ExecutionCount < step.MaxExecutions || step.MaxExecutions == int.MaxValue)
                {
                    if (CheckConditions(step.Conditions))
                    {
                        RunActions(step.Actions, context);
                        step.ExecutionCount += 1;
                    }
                }
            }
        }
        
        private bool IsNumeric(object value)
        {
            double val2;

            if (double.TryParse(value.ToString(), out val2))
                value = val2;
            return value is sbyte || value is byte ||
                   value is short || value is ushort ||
                   value is int || value is uint ||
                   value is long || value is ulong ||
                   value is float || value is double ||
                   value is decimal;
        }
        private bool IsBiggerThan(object value1, object value2)
        {
            if (value1 == null || value2 == null)
                return false;

            // Numeri → converto tutto in double
            if (IsNumeric(value1) && IsNumeric(value2))
                return Convert.ToDouble(value1) > Convert.ToDouble(value2);

            // DateTime
            if (value1 is DateTime dt1 && value2 is DateTime dt2)
                return dt1 > dt2;

            // Boolean → false < true
            if (value1 is bool b1 && value2 is bool b2)
                return b1 && !b2;

            // String → confronto lessicografico
            if (value1 is string s1 && value2 is string s2)
                return string.Compare(s1, s2, StringComparison.Ordinal) > 0;

            throw new InvalidOperationException("Type not supported for comparison");
        }
        private void ApplyEvent(string nodeId, string evValue, ServerSystemContext context)
        {
            var nodeID = NodeId.Parse(nodeId);
            if (!_nodes.TryGetValue(nodeID, out var variable))
                return;

            variable.Value = ConvertValue(evValue, variable.DataType);
            variable.Timestamp = DateTime.UtcNow;
            variable.StatusCode = StatusCodes.Good;
            variable.ClearChangeMasks(context, false);

        }
        private object ConvertValue(string value, NodeId dataType)
        {
            if (value == null)
                return null;

            if (dataType == DataTypeIds.Boolean)
                return Convert.ToBoolean(value);

            if (dataType == DataTypeIds.SByte)
                return Convert.ToSByte(value);

            if (dataType == DataTypeIds.Int16)
                return Convert.ToInt16(value);

            if (dataType == DataTypeIds.Int32)
                return Convert.ToInt32(value);

            if (dataType == DataTypeIds.Int64)
                return Convert.ToInt64(value);

            if (dataType == DataTypeIds.Byte)
                return Convert.ToByte(value);

            if (dataType == DataTypeIds.UInt16)
                return Convert.ToUInt16(value);

            if (dataType == DataTypeIds.UInt32)
                return Convert.ToUInt32(value);

            if (dataType == DataTypeIds.UInt64)
                return Convert.ToUInt64(value);

            if (dataType == DataTypeIds.Float)
                return Convert.ToSingle(value, CultureInfo.InvariantCulture);

            if (dataType == DataTypeIds.Double)
                return Convert.ToDouble(value, CultureInfo.InvariantCulture);

            if (dataType == DataTypeIds.String)
                return value;

            if (dataType == DataTypeIds.DateTime)
                return DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);

            if (dataType == DataTypeIds.Guid)
                return Guid.Parse(value);

            if (dataType == DataTypeIds.ByteString)
                return Convert.FromBase64String(value);

            if (dataType == DataTypeIds.XmlElement)
                return value;

            if (dataType == DataTypeIds.NodeId)
                return NodeId.Parse(value);

            if (dataType == DataTypeIds.ExpandedNodeId)
                return ExpandedNodeId.Parse(value);

            if (dataType == DataTypeIds.StatusCode)
                return new StatusCode(Convert.ToUInt32(value));

            if (dataType == DataTypeIds.QualifiedName)
                return QualifiedName.Parse(value);

            if (dataType == DataTypeIds.LocalizedText)
                return new LocalizedText(value);

            if (dataType == DataTypeIds.Enumeration)
                return Convert.ToInt32(value);

            return value;
        }

    }
}
