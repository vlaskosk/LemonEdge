namespace LemonEdge.Domain.Pieces
{
    public abstract class ChessPiece
    {
        protected ChessPiece(List<MovementType[]> allSingleMoves, int maxNumberOfSingleMovements, string name)
        {
            AllSingleMoves = allSingleMoves;
            MaxNumberOfSingleMovements = maxNumberOfSingleMovements;
            Name = name;
        }

        public string Name { get; }

        public List<MovementType[]> AllSingleMoves { get; }

        public int MaxNumberOfSingleMovements { get; }
    }
}
