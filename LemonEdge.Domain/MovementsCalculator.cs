using LemonEdge.Domain.Pieces;

namespace LemonEdge.Domain
{
    public class MovementsCalculator : IMovementsCalculator
    {
        private readonly ISingleMovementGenerator _singleMovementGenerator;

        public MovementsCalculator(ISingleMovementGenerator singleMovementGenerator)
        {
            _singleMovementGenerator = singleMovementGenerator;
        }

        public List<(int x, int y)> GetNextPossibleMoves(ChessPiece chessPiece, Board board, (int x, int y) currentPosition)
        {
            var result = new List<(int x, int y)>();
            foreach (var possibleMove in chessPiece.AllSingleMoves)
            {
                for (int singleMoveRepeat = 1; singleMoveRepeat <= chessPiece.MaxNumberOfSingleMovements; singleMoveRepeat++)
                {
                    (int x, int y) newPosition = _singleMovementGenerator.GetMove(currentPosition, possibleMove, singleMoveRepeat);

                    if (newPosition.x < 0 || newPosition.y < 0 || newPosition.y >= board.Values.GetLength(0) || newPosition.x >= board.Values.GetLength(1))
                    {
                        //outside board
                        continue;
                    }

                    if (board.ForbiddenValues.Contains(board.Values[newPosition.y,newPosition.x]))
                    {
                        //value is not allowed
                        continue;
                    }
                    result.Add(newPosition);
                }
            }
            return result;
        }

        
    }
}
