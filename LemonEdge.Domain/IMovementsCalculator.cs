using LemonEdge.Domain.Pieces;

namespace LemonEdge.Domain
{
    public interface IMovementsCalculator
    {
        List<(int x, int y)> GetNextPossibleMoves(ChessPiece chessPiece, Board board, (int x, int y) currentPosition);
    }
}