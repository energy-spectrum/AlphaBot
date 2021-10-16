namespace AlphaBot_Bitcoin
{
    public enum Commands : byte
    {
        None, 

        MoveForward,
        MoveBackward,
        MoveRight,
        MoveLeft,

        Jump,
        JumpUp,
        JumpDown,
        JumpForward,
        JumpBack,
        JumpRight,
        JumpLeft,

        Pick,
        Activate,
        TurnRight,
        TurnLeft,

        Ban,//Когда нельзя выполнить действие

        FunctionCall,

        GameOver
    }
}