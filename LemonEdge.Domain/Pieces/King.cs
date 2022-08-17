namespace LemonEdge.Domain.Pieces
{
    public class King : ChessPiece
    {
        public King() : base(new List<MovementType[]>
            {
                new []{ MovementType.PositiveHorizontal, MovementType.PositiveVertical },
                new []{ MovementType.NegativeHorizontal, MovementType.PositiveVertical },
                new []{ MovementType.PositiveHorizontal, MovementType.NegativeVertical },
                new []{ MovementType.NegativeHorizontal, MovementType.NegativeVertical },
                new []{ MovementType.PositiveHorizontal},
                new []{ MovementType.NegativeHorizontal},
                new []{ MovementType.PositiveVertical},
                new []{ MovementType.NegativeVertical}
            }, 1, "King")
        {
        }
    }
}
