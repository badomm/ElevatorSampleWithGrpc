namespace ElevatorServer;

public enum ElevatorMoveDirection
{
    UP,
    DOWN,
    NONE
}

public static class ElevatorMoveDirectionExtensions
{
    static public ElevatorSim.Direction ToElevatorMoveDirection(this ElevatorMoveDirection dir) => dir switch
    {
        ElevatorMoveDirection.UP => ElevatorSim.Direction.Up,
        ElevatorMoveDirection.DOWN => ElevatorSim.Direction.Down,
        ElevatorMoveDirection.NONE => ElevatorSim.Direction.Standby,
        _ => throw new NotImplementedException()
    };
}

