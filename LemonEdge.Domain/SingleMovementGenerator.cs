namespace LemonEdge.Domain
{
    public class SingleMovementGenerator : ISingleMovementGenerator
    {
        public (int x, int y) GetMove((int x, int y) currentPosition, MovementType[] possibleMove, int singleMoveRepeat)
        {
            var newPosition = currentPosition;
            for (int repeat = 0; repeat < singleMoveRepeat; repeat++)
            {
                foreach (var movePart in possibleMove)
                {
                    switch (movePart)
                    {
                        case MovementType.PositiveVertical:
                            newPosition.y++;
                            break;
                        case MovementType.NegativeVertical:
                            newPosition.y--;
                            break;
                        case MovementType.PositiveHorizontal:
                            newPosition.x++;
                            break;
                        case MovementType.NegativeHorizontal:
                            newPosition.x--;
                            break;
                        default:
                            break;
                    }
                }
            }
            return newPosition;
        }
    }
}
