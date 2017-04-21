using System;
using System.Collections.Generic;

namespace LogicProgrammingCSharp
{
    public class Fact
    {
        public Fact(params string[] args)
        {
            //first argument is the functor
            if (args.Length < 2)
                throw new Exception("You need to have a name and at least 1 argument");
            Functor = args[0];
            ChildrenList = new List<string>();
            for (var i = 1; i < args.Length; i++)
                ChildrenList.Add(args[i]);
        }

        public string Functor { get; private set; }
        public List<string> ChildrenList { get; private set; }
    }
}