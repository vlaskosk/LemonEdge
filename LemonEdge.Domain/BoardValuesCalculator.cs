using LemonEdge.Domain.Pieces;

namespace LemonEdge.Domain
{
    public class BoardValuesCalculator
    {
        private readonly IChessPieceValuesCalculator _chessPieceValuesCalculator;

        public BoardValuesCalculator(IChessPieceValuesCalculator chessPieceValuesCalculator)
        {
            _chessPieceValuesCalculator = chessPieceValuesCalculator;
        }

        public Dictionary<ChessPiece, int> GetValuesCount(List<ChessPiece> chessPieces, Board board, int valuesLength)
        {
            var result = new Dictionary<ChessPiece, int>();
            foreach (var piece in chessPieces)
            {
                for (int y = 0; y < board.Values.GetLength(0); y++)
                {
                    for (int x = 0; x < board.Values.GetLength(1); x++)
                    {
                        if (board.ForbiddenValues.Contains(board.Values[y,x]) ||
                            board.NonStartValues.Contains(board.Values[y,x]))
                        {
                            continue;
                        }

                        var startingPosition = (x, y);
                        var countForStartingPosition = _chessPieceValuesCalculator.GetChessPieceValuesCount(piece, board, valuesLength, startingPosition);
                        if(!result.ContainsKey(piece))
                        {
                            result.Add(piece, countForStartingPosition);
                        }
                        else
                        {
                            result[piece] += countForStartingPosition;
                        }
                    }
                }
            }
            return result;
        }
    }
}
