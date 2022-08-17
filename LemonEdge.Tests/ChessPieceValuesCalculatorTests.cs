using LemonEdge.Domain;
using LemonEdge.Domain.Pieces;
using Moq;
using Shouldly;
using Xunit;

namespace LemonEdge.Tests
{
    public class ChessPieceValuesCalculatorTests
    {
        private readonly ChessPieceValuesCalculator _chessPieceValuesCalculator;

        private Queue<List<(int, int)>> _moves;

        public ChessPieceValuesCalculatorTests()
        {
            _moves = new Queue<List<(int, int)>>();
            var movementsCalculator = Mock.Of<IMovementsCalculator>();
            Mock.Get(movementsCalculator)
                .Setup(e => e.GetNextPossibleMoves(It.IsAny<ChessPiece>(), It.IsAny<Board>(), It.IsAny<(int, int)>()))
                .Returns(() => _moves.Dequeue());
            _chessPieceValuesCalculator = new ChessPieceValuesCalculator(movementsCalculator);
        }

        [Fact]
        public void ThatWillReturnSingleResult()
        {
            var board = new Board(new[,] {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" }
            }, new List<string> { }, new List<string>());
            var piece = new Bishop(3);
            var result = _chessPieceValuesCalculator.GetChessPieceValuesCount(piece, board, 1, (0, 0));
            result.ShouldBe(1); 
        }

        [Fact]
        public void ThatWillReturnSinglePathResult()
        {
            _moves = new Queue<List<(int, int)>> ( 
                new List<List<(int,int)>>{ 
                    new List<(int, int)> { (0, 0) }, 
                    new List<(int, int)> { (0, 0), (0, 0), (0, 0) } });
            var board = new Board(new[,] {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" }
            }, new List<string> { }, new List<string>());
            var piece = new Bishop(3);
            var result = _chessPieceValuesCalculator.GetChessPieceValuesCount(piece, board, 3, (0, 0));
            result.ShouldBe(3);
        }

        [Fact]
        public void ThatWillReturnMultiPathResult()
        {
            _moves = new Queue<List<(int, int)>>(new List<List<(int, int)>> { 
                new List<(int, int)> { (0, 0), (0, 0) }, //level 2
                new List<(int, int)> { (0, 0), (0, 0), (0, 0) }, //level3 first
                new List<(int, int)> { (0, 0), (0, 0) } }); //level 3 second
            var board = new Board(new[,] {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" }
            }, new List<string> { }, new List<string>());
            var piece = new Bishop(3);
            var result = _chessPieceValuesCalculator.GetChessPieceValuesCount(piece, board, 3, (0, 0));
            result.ShouldBe(5);
        }


        [Fact]
        public void ThatWillReturnIgnoreIncompletePathResult()
        {
            _moves = new Queue<List<(int, int)>>(new List<List<(int, int)>> {
                new List<(int, int)> { (0, 0), (0, 0) }, //level 2
                new List<(int, int)> { (0, 0) }, //level3 first
                new List<(int, int)> { (0, 0), (0, 0) }, //level4 first
                new List<(int, int)> { } }); //level3 second 
            var board = new Board(new[,] {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" }
            }, new List<string> { }, new List<string>());
            var piece = new Bishop(3);
            var result = _chessPieceValuesCalculator.GetChessPieceValuesCount(piece, board, 4, (0, 0));
            result.ShouldBe(2);
        }
    }
}
