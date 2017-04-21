using System;
using System.Collections.Generic;

namespace LogicProgrammingCSharp
{
    public class Rule
    {
        public Rule(params RulePart[] args)
        {
            //first and second params must be queries, and next ones will be operation and query alternating
            if (args[0].Query == null)
                throw new Exception("You need to name your rule");
            if (args[1].Query == null)
                throw new Exception("Second argument must be a fact or a query");
            if (args.Length%2 != 0)
                throw new Exception("You need more arguments");
            for (var i = 2; i < args.Length; i++)
                if (i%2 == 0)
                {
                    if (string.IsNullOrEmpty(args[i].Operation))
                        throw new Exception("You need to alternate operation and query");
                }
                else
                {
                    if (args[i].Query == null)
                        throw new Exception("You need to alternate operation and query");
                }
            //checks are done so I just write them into the variables for use in outside queries
            RuleName = args[0].Query;
            RuleParts = new List<RulePart>();
            for (var i = 1; i < args.Length; i++)
                RuleParts.Add(args[i]);
        }

        public Query RuleName { get; private set; }
        public List<RulePart> RuleParts { get; private set; }
    }
}