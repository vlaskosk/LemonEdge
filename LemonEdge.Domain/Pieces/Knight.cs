namespace LemonEdge.Domain.Pieces
{
    public class Knight : ChessPiece
    {
        public Knight() : base(new List<MovementType[]>
        {
            new[]{ MovementType.PositiveHorizontal, MovementType.PositiveHorizontal, MovementType.PositiveVertical },
            new[]{ MovementType.PositiveHorizontal, MovementType.PositiveHorizontal, MovementType.NegativeVertical },
            new[]{ MovementType.NegativeHorizontal, MovementType.NegativeHorizontal, MovementType.PositiveVertical },
            new[]{ MovementType.NegativeHorizontal, MovementType.NegativeHorizontal, MovementType.NegativeVertical },
            new[]{ MovementType.PositiveVertical, MovementType.PositiveVertical, MovementType.PositiveHorizontal },
            new[]{ MovementType.PositiveVertical, MovementType.PositiveVertical, MovementType.NegativeHorizontal },
            new[]{ MovementType.NegativeVertical, MovementType.NegativeVertical, MovementType.PositiveHorizontal },
            new[]{ MovementType.NegativeVertical, MovementType.NegativeVertical, MovementType.NegativeHorizontal }
        }, 1, "Knight")
        {
        }
    }
}
