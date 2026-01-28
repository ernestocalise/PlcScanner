using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlcScanner.Models
{
    public class ClientTag
    {
        public string Name { get; set; }
        public string NodeId { get; set; }
        public string DataType { get; set; }
        public string Value { get; set; }
    }
}
