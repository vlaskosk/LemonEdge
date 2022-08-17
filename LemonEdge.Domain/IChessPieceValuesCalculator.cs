using LemonEdge.Domain.Pieces;

namespace LemonEdge.Domain
{
    public interface IChessPieceValuesCalculator
    {
        int GetChessPieceValuesCount(ChessPiece chessPiece, Board board, int valuesLength, (int x, int y) startingPosition);
    }
}