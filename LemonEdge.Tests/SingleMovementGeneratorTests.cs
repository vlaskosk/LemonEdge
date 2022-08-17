using LemonEdge.Domain;
using Shouldly;
using Xunit;

namespace LemonEdge.Tests
{
    public class SingleMovementGeneratorTests
    {
        [Theory]
        [MemberData("GetData")]
        public void ThatConvertsMovementType(
            MovementType[] possibleMove,
            int singleMoveRepeat,
            (int x, int y) expectedResult)
        {
            var generator = new SingleMovementGenerator();
            var result = generator.GetMove((0,0), possibleMove, singleMoveRepeat);
            result.ShouldBe(expectedResult);
        }

        public static IEnumerable<object[]> GetData => new List<object[]>{ 
            //simple
            new object[]{new []{ MovementType.NegativeVertical}, 1, (0,-1) },
            new object[]{new []{ MovementType.NegativeHorizontal}, 1, (-1,0) },
            new object[]{new []{ MovementType.PositiveHorizontal}, 1, (1,0) },
            new object[]{new []{ MovementType.PositiveVertical}, 1, (0,1) },

            //multiple repeats
            new object[]{new []{ MovementType.NegativeVertical}, 3, (0,-3) },
            new object[]{new []{ MovementType.NegativeHorizontal}, 3, (-3,0) },
            new object[]{new []{ MovementType.PositiveHorizontal}, 3, (3,0) },
            new object[]{new []{ MovementType.PositiveVertical}, 3, (0,3) },

            //combination of moves repeats
            new object[]{new []{ MovementType.NegativeVertical, MovementType.NegativeHorizontal }, 1, (-1,-1) },
            new object[]{new []{ MovementType.NegativeVertical, MovementType.NegativeHorizontal }, 3, (-3,-3) },
        };
    }
}
