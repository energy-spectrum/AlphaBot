using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlphaBot_Bitcoin
{
    public enum CodeElements : int
    {
        If,
        Else,
        While,
        For,

        Function,
        FunctionCall,

        MoveForward,
        MoveBackward,
        MoveRight,
        MoveLeft,

        TurnRight,
        TurnLeft,

        Jump,
        Pick,

        Activate,

        Brace,


    }
}