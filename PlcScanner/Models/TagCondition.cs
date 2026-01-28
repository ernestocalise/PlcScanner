using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlcScanner.Models
{
    public class TagCondition
    {
        public string NodeId { get; set; } = string.Empty;
        public TagConditionType Type { get; set; } = TagConditionType.Equals;
        public string Argument { get; set; } = string.Empty;
    }
    public enum TagConditionType
    {
        Equals = 0,
        NotEquals = 1,
        BiggerThan = 2,
        LowerThan = 3,
        CountEquals = 4,
        CountLowerThan = 5,
        CountBiggerThan = 6,
        StartsWith = 7,
        EndsWith = 8,
        Contains = 9,
        DoesNotContains = 10,
        BeforeTime = 11,
        AfterTime = 12
    }
    public enum TagActionType
    {
        Write = 0,
        Increment = 1,
        Decrement = 2,
        Sleep = 3,
        EmptyArray = 4,
    }
    public class TagAction
    {
        public string NodeId { get; set; } = string.Empty;
        public TagActionType Type { get; set; } = TagActionType.Write;
        public string Value { get; set; } = string.Empty;
    }

    public class ProgrammedRoutineStep
    {
        public string Name { get; set; } = string.Empty;
        public List<TagCondition> Conditions { get; set; } = new List<TagCondition>();
        public List<TagAction> Actions { get; set; } = new List<TagAction>();
        public int ExecutionCount { get; set; } = 0;
        public int MaxExecutions { get; set; } = int.MaxValue;
    }
}
