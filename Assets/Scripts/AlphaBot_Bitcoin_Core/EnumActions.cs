namespace AlphaBot_Bitcoin.RobotCore
{
    public enum Actions
    {
        None,

        WalkForward,
        WalkBackward,
        WalkRight,
        WalkLeft,

        TurnRight,
        TurnLeft,

        Jump,
        JumpUp,
        JumpDown,
        JumpForward,
        JumpBack,
        JumpRight,
        JumpLeft,

        Pick,
        Activate,

        TeleportIn,
        TeleportFrom,

        Ban,

        GameOver 
    }
}