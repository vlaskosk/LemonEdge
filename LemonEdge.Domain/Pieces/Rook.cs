namespace LemonEdge.Domain.Pieces
{
    public class Rook : ChessPiece
    {
        public Rook(int maxBoardDimension): base(new List<MovementType[]>
            {
                new []{ MovementType.PositiveHorizontal},
                new []{ MovementType.NegativeHorizontal},
                new []{ MovementType.PositiveVertical},
                new []{ MovementType.NegativeVertical}
            }, maxBoardDimension, "Rook")
        {
        }
    }
}
