using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlcScanner.Models
{
    public class TagChange
    {
        public string NodeId { get; set; }
        public string Name { get; set; }
        public string OldValue { get; set; }
        public string Value { get; set; }
        public TimeSpan Time { get; set; }
    }
}
