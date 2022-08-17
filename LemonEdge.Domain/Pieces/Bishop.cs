namespace LemonEdge.Domain.Pieces
{
    public class Bishop : ChessPiece
    {
        public Bishop(int minBoardDimension) : base(new List<MovementType[]>
            {
                new []{ MovementType.PositiveHorizontal, MovementType.PositiveVertical },
                new []{ MovementType.NegativeHorizontal, MovementType.PositiveVertical },
                new []{ MovementType.PositiveHorizontal, MovementType.NegativeVertical },
                new []{ MovementType.NegativeHorizontal, MovementType.NegativeVertical }
            }, minBoardDimension, "Bishop")
        {
        }
    }
}
