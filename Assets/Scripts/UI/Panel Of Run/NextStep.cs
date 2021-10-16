using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AlphaBot_Bitcoin.RobotCore;
public class NextStep : MonoBehaviour
{
    static ButtonState buttonState;
    private void Start()
    {
        buttonState = GetComponent<ButtonState>();
    }
    static public bool isGameOver = false, isActivated = false;
  
    static public RunRobot runRobot;
    public RunGame runGame;

    static public void Passive()
    {
        buttonState.Passive();
    }

    public void Next()
    {
        if (!RunGame.isRun)
        {
            runGame.Run();
        }
        if (!isGameOver)
        {
            isActivated = true;
            runRobot.NextStep_();
        }
        else
        {
            buttonState.Passive();
            isGameOver = false;
            isActivated = false;
        }
    }

   
}
