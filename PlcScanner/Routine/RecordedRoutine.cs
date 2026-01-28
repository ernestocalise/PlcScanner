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
    public class RecordedRoutine : BaseRoutine
    {
        private readonly List<TagChange> _events;
        private readonly Dictionary<NodeId, BaseDataVariableState> _nodes;
        private int _index;

        public RecordedRoutine(string name, IEnumerable<TagChange> events, XMLOpcNodeManager nodeManager)
        {
            this.SetName(name);
            _events = events.OrderBy(e => e.Time).ToList();
            _nodes = nodeManager.variables;
            _index = 0;
        }
        protected override void ExecuteInternal(TimeSpan localTime, ServerSystemContext context)
        {
            while (_index < _events.Count && localTime >= _events[_index].Time)
            {
                ApplyEvent(_events[_index], context);
                _index++;
            }
            if (_index == _events.Count)
                this.Stop();
        }
        private void ApplyEvent(TagChange change, ServerSystemContext context)
        {
            var nodeID = NodeId.Parse(change.NodeId);
            if (!_nodes.TryGetValue(nodeID, out var variable))
                return;

            variable.Value = ConvertValue(change.Value, variable.DataType);
            variable.Timestamp = DateTime.UtcNow;
            variable.StatusCode = StatusCodes.Good;
            variable.ClearChangeMasks(context, false);
            
        }
        private object ConvertValue(string value, NodeId dataType) { 
            if(dataType == DataTypeIds.Boolean)
                return Convert.ToBoolean(value);
            if(dataType == DataTypeIds.Double)
                return Convert.ToDouble(value, CultureInfo.InvariantCulture);
            if(dataType == DataTypeIds.Int32)
                return Convert.ToInt32(value);
            return value;
        }
    }
}
