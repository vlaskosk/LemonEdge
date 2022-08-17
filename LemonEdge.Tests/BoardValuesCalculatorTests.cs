using LemonEdge.Domain;
using LemonEdge.Domain.Pieces;
using Moq;
using Shouldly;
using Xunit;

namespace LemonEdge.Tests
{
    public class BoardValuesCalculatorTests
    {
        private BoardValuesCalculator _calculator;

        public BoardValuesCalculatorTests()
        {
            var chessPieceValuesCalculator = Mock.Of<IChessPieceValuesCalculator>();
            Mock.Get(chessPieceValuesCalculator)
                .Setup(e => e.GetChessPieceValuesCount(It.IsAny<ChessPiece>(), It.IsAny<Board>(),It.IsAny<int>(), It.IsAny<(int, int)>()))
                .Returns<ChessPiece, Board, int, (int, int)>((piece,_,_,_) => piece is Rook ? 2 : 1);

            _calculator = new BoardValuesCalculator(chessPieceValuesCalculator);
        }

        [Fact]
        public void ThatWillCalculateWithNoRestrictions()
        {
            var board = new Board(new[,] {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" }
            }, new List<string> { }, new List<string>());
            var bishop = new Bishop(3);
            var rook = new Rook(3);
            var result = _calculator.GetValuesCount(new List<ChessPiece> { bishop, rook }, board, 3);
            result.Keys.Count.ShouldBe(2);
            result.ContainsKey(bishop).ShouldBeTrue();
            result.ContainsKey(rook).ShouldBeTrue();
            result[bishop].ShouldBe(9); //9 possible starting positions
            result[rook].ShouldBe(18); //9 possible starting positions
        }

        [Fact]
        public void ThatWillIgnoreRestrictedStartingPositions()
        {
            var board = new Board(new[,] {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" }
            }, new List<string> { "2", "4" }, new List<string> { "3", "6"});
            var bishop = new Bishop(3);
            var rook = new Rook(3);
            var result = _calculator.GetValuesCount(new List<ChessPiece> { bishop, rook }, board, 3);
            result.Keys.Count.ShouldBe(2);
            result.ContainsKey(bishop).ShouldBeTrue();
            result.ContainsKey(rook).ShouldBeTrue();
            result[bishop].ShouldBe(5); //5 possible starting positions
            result[rook].ShouldBe(10); //5 possible starting positions
        }
    }
}
