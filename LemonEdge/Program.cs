using LemonEdge.Domain;
using LemonEdge.Domain.Pieces;

namespace LemonEdge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var board = new Board(new[,] {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" },
                {"*", "0", "#" }
            }, new List<string> { "*", "#" }, new List<string> { "0", "1" });
            var pieces = new List<ChessPiece>
            {
                new Bishop(3),
                new King(),
                new Knight(),
                new Queen(4),
                new Rook(4)
            };
            var boardValuesCalculator = GetBoardValuesCalculator();
            var results = boardValuesCalculator.GetValuesCount(pieces, board, 7);
            foreach (var result in results)
            {
                Console.WriteLine($"{result.Key.Name} - possible combinations: {result.Value}");
            }
        }

        // this would be done by DI container in real life
        private static BoardValuesCalculator GetBoardValuesCalculator()
        {
            return new BoardValuesCalculator(new ChessPieceValuesCalculator(new MovementsCalculator(new SingleMovementGenerator())));
        }
    }
}