using LemonEdge.Domain.Pieces;

namespace LemonEdge.Domain
{
    public class ChessPieceValuesCalculator : IChessPieceValuesCalculator
    {
        private readonly IMovementsCalculator _movementsCalculator;

        public ChessPieceValuesCalculator(IMovementsCalculator movementsCalculator)
        {
            _movementsCalculator = movementsCalculator;
        }

        public int GetChessPieceValuesCount(ChessPiece chessPiece, Board board, int valuesLength, (int x, int y) startingPosition)
        {
            if(valuesLength == 1)
            {
                return 1;
            }
            var valuesCount = GetValues(chessPiece, board, startingPosition, 2, valuesLength);
            return valuesCount;
        }

        private int GetValues(ChessPiece chessPiece,
            Board board,
            (int x, int y) currentPosition,
            int moveCount,
            int valuesLength)
        {
            var possibleMoves = _movementsCalculator.GetNextPossibleMoves(chessPiece, board, currentPosition);
            if (moveCount == valuesLength)
            {
                return possibleMoves.Count;
            }
            if (possibleMoves.Count > 0)
            {
                var newMoveCount = moveCount + 1;
                var totalValuesCount = 0;
                foreach (var nextMove in possibleMoves)
                {
                    var valuesCount = GetValues(chessPiece, board, nextMove, newMoveCount, valuesLength);
                    totalValuesCount += valuesCount;
                }
                return totalValuesCount;

            }
            return 0;
        }
    }
}
