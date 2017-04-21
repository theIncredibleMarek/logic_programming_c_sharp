using System;

namespace LogicProgrammingCSharp
{
    public class RulePart
    {
        public RulePart(string operation, Query query)
        {
            Operation = operation;
            Query = query;
            if ((query == null) && !operation.ToLower().Equals("and") && !operation.ToLower().Equals("or"))
                throw new Exception("You need to specify AND or OR");
        }

        public Query Query { get; private set; }
        public string Operation { get; private set; }
    }
}