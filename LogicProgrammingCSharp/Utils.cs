using System.Linq;

namespace LogicProgrammingCSharp
{
    public class Utils
    {
        public static bool IsUppercase(string input)
        {
            return input.All(t => !char.IsLetter(t) || char.IsUpper(t));
        }
    }
}