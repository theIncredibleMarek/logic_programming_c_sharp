namespace LogicProgrammingCSharp
{
    public class Query : Fact
    {
        public Query(params string[] args) : base(args)
        {
            IsMissingArgs = false;
            FindMissingArguments();
        }

        public int[] MissingArgs { get; private set; }

        public bool IsMissingArgs { get; private set; }

        private void FindMissingArguments()
        {
            MissingArgs = new int[ChildrenList.Count];
            for (var i = 0; i < ChildrenList.Count; i++)
                if (Utils.IsUppercase(ChildrenList[i]))
                {
                    MissingArgs[i] = 1;
                    IsMissingArgs = true;
                }
                else
                {
                    MissingArgs[i] = 0;
                }
        }
    }
}