using LemonEdge.Domain;
using LemonEdge.Domain.Pieces;
using Moq;
using Shouldly;
using Xunit;

namespace LemonEdge.Tests
{
    public class MovementsCalculatorTests
    {
        private readonly MovementsCalculator _movementsCalculator;
        private readonly ISingleMovementGenerator _singleMovementGenerator;

        private (int, int) _nextMove;

        public MovementsCalculatorTests()
        {
            _singleMovementGenerator = Mock.Of<ISingleMovementGenerator>();
            Mock.Get(_singleMovementGenerator)
                .Setup(e => e.GetMove(It.IsAny<(int, int)>(), It.IsAny<MovementType[]>(), It.IsAny<int>()))
                .Returns(() => _nextMove);
            _movementsCalculator = new MovementsCalculator(_singleMovementGenerator);
        }

        [Fact]
        public void ThatWillGenerateAllMoves()
        {
            _nextMove = (0, 1);
            var board = new Board(new[,] {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" }
            }, new List<string>{}, new List<string>());
            var piece = new Bishop(3);
            var possibleMoves = _movementsCalculator.GetNextPossibleMoves(piece, board, (0, 0));
            //12 theoretical moves
            Mock.Get(_singleMovementGenerator)
                .Verify(e => e.GetMove(It.IsAny<(int, int)>(), It.IsAny<MovementType[]>(), It.IsAny<int>()), Times.Exactly(12));
            possibleMoves.Count.ShouldBe(12);
        }

        [Theory]
        [MemberData("GetOutsideBoardMoves")]
        public void ThatWillRemoveOutsideBoardMoves((int,int) move)
        {
            _nextMove = move;
            var board = new Board(new[,] {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" }
            }, new List<string> { }, new List<string>());
            var piece = new Bishop(1);
            var possibleMoves = _movementsCalculator.GetNextPossibleMoves(piece, board, (0, 0));
            possibleMoves.Count.ShouldBe(0);
        }

        [Fact]
        public void ThatWillRemoveForbiddenValues()
        {
            _nextMove = (0, 1);
            var board = new Board(new[,] {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" }
            }, new List<string> { "4" }, new List<string>());
            var piece = new Bishop(3);
            var possibleMoves = _movementsCalculator.GetNextPossibleMoves(piece, board, (0, 0));
            possibleMoves.Count.ShouldBe(0);
        }

        public static IEnumerable<object[]> GetOutsideBoardMoves => new List<object[]>{ 
            new object[]{ (0,-1) },
            new object[]{ (-1,0) },
            new object[]{ (4,0) },
            new object[]{ (0,4) },
            new object[]{ (3,0) },
            new object[]{ (0,3) },
        };


    }
}
