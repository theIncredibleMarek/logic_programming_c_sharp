using System.Collections.Generic;
using System.Linq;

namespace LogicProgrammingCSharp
{
    public class SmartTransistor
    {
        private readonly List<Fact> _facts;

        public SmartTransistor()
        {
            _facts = new List<Fact>();
        }

        public void AddFact(Fact newFact)
        {
            _facts.Add(newFact);
        }

        public string Query(Query query)
        {
            //if I am not missing arguments, I just get the whole list of result that are possible and return the first matching item
            if (!query.IsMissingArgs) return IsInFacts(query).ToString();
            //I must return a string that maps the missing args to their value in the first item returned by the method
            var resultList = FindMissingArgs(query);
            var resultString = "";
            //if there's no result, return false
            if (resultList.Count == 0) return "false";
            //if i have multiple results, the only one I return is the first one
            var firstResult = resultList[0];
            for (var i = 0; i < query.MissingArgs.Length; i++)
                if (query.MissingArgs[i] == 1)
                    resultString += query.ChildrenList[i] + ": " + firstResult.ChildrenList[i] + ' ';
            return resultString;
        }

        private bool IsInFacts(Query query)
        {
            //select only facts that have the same functors and same number of arguments
            var resultingFacts =
                _facts.Where(
                    f => f.Functor.Equals(query.Functor) &&
                         f.ChildrenList.Count.Equals(query.ChildrenList.Count)
                );

            //iterate through the resulting facts - if they are found according to the children 
            //list and missing arguments add the results to the return list
            foreach (var fact in resultingFacts)
            {
                var factExists = true;
                //find out if for below can be written as:
                //var matchingFact = !fact.ChildrenList.Where((t, i) => !t.Equals(query.ChildrenList[i])).Any();

                //iterate through the children of the fact and compare to the children list from args
                for (var i = 0; i < fact.ChildrenList.Count; i++)
                {
                    //if the children are the same then move to next child
                    if (fact.ChildrenList[i].Equals(query.ChildrenList[i])) continue;
                    //if the children are not the same I can exit the loop and move to the next fact
                    factExists = false;
                    break;
                }
                if (factExists)
                    return true;
            }
            return false;
        }

        private List<Fact> FindMissingArgs(Query query)
        {
            var resultList = new List<Fact>();
            //select only facts that have the same functors and same number of arguments
            var resultingFacts =
                _facts.Where(
                    f => f.Functor.Equals(query.Functor) &&
                         f.ChildrenList.Count.Equals(query.ChildrenList.Count)
                );

            //loop through each fact to find out if it fits the query
            foreach (var fact in resultingFacts)
            {
                var addToResult = true;
                //loop through the missing arguments - same length as args in the query - and if the arguments match add to result list
                for (var i = 0; i < query.MissingArgs.Length; i++)
                {
                    var queryArg = query.ChildrenList[i];
                    var factArg = fact.ChildrenList[i];
                    //if the argument is missing(value 1) then go to next argument
                    if (query.MissingArgs[i] == 1) continue;
                    //if the argument is not missing but is the same as the query argument go to next argument
                    if (queryArg.Equals(factArg)) continue;
                    //if the argument is not missing and is not the same as the query we move to next fact
                    addToResult = false;
                    break;
                }
                if (addToResult)
                    resultList.Add(fact);
            }
            return resultList;
        }

        public void AddRule(Rule rule)
        {
            //I am sure that my rule will look like this RULE_FUNCTOR(ARGS),FUNCTOR(ARGS),AND/OR,FUNCTOR(ARGS),AND/OR,...
            //I will use the rule to generate new facts, PROLOG works in similar fashion, because rules are not possible to be added at runtime

        }
    }
}