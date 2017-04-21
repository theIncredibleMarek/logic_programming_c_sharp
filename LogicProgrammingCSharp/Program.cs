using System;

namespace LogicProgrammingCSharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var f1 = new Fact("father", "a", "b", "c");
                var f2 = new Fact("father", "a", "b");
                var f3 = new Fact("father", "a", "a");
                var f4 = new Fact("father", "z", "a");
                var f5 = new Fact("father", "b", "c");
                var f6 = new Fact("father", "b", "a");

                var q1 = new Query("father", "b");
                var q2 = new Query("father", "a", "XX");
                var q3 = new Query("father", "Example", "a");
                var q4 = new Query("father", "XX", "XX", "XX", "XX");

                var r1 = new Rule(new RulePart(null, new Query("grandfather", "A", "B")),
                    new RulePart(null, new Query("father", "A", "C")),
                    new RulePart("and", null),
                    new RulePart(null, new Query("father", "C", "B")));


                //the actual Prolog implementation
                var computer = new SmartTransistor();

                computer.AddFact(f1);
                computer.AddFact(f2);
                computer.AddFact(f3);
                computer.AddFact(f4);
                computer.AddFact(f5);
                computer.AddFact(f6);

                var result = computer.Query(q1);
                Console.WriteLine(result);
                result = computer.Query(q2);
                Console.WriteLine(result);
                result = computer.Query(q3);
                Console.WriteLine(result);
                result = computer.Query(q4);
                Console.WriteLine(result);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}