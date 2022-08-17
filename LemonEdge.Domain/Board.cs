namespace LemonEdge.Domain
{
    public class Board
    {
        public Board(string[,] values, List<string> forbiddenValues, List<string> nonStartValues)
        {
            Values = values;
            ForbiddenValues = forbiddenValues;
            NonStartValues = nonStartValues;
        }

        public string[,] Values { get; }

        public List<string> ForbiddenValues { get; }

        public List<string> NonStartValues { get; }
    }
}
