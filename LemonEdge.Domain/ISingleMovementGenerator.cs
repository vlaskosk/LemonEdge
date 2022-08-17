namespace LemonEdge.Domain
{
    public interface ISingleMovementGenerator
    {
        (int x, int y) GetMove((int x, int y) currentPosition, MovementType[] possibleMove, int singleMoveRepeat);
    }
}