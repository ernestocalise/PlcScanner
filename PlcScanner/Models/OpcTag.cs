using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PlcScanner.Models
{
    public class OpcTag
    {
        public string Name { get; set; }
        public string NodeId { get; set; }
        public string DataType { get; set; }
        public string Value { get; set; }
        public string Timestamp { get; set; }
        public string Status { get; set; }
        public string SubscriptionID { get; set; }
        public List<OpcTag> Childrens { get; set; }

        public bool IsSubscribed() { return this.SubscriptionID != string.Empty;  }

        public OpcTag(string name, string nodeid, string datatype, string value)
        {
            this.Name = name;
            this.NodeId = nodeid;
            this.DataType = datatype;
            this.Value = value;
            this.Timestamp = "Never";
            this.Status = "Disconnected";
            this.SubscriptionID = string.Empty;
            Childrens = new List<OpcTag>();
        }
    }
}
