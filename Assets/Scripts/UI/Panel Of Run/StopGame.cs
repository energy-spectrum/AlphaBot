using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AlphaBot_Bitcoin.RobotCore;
public class StopGame : MonoBehaviour
{
    public Transform LevelTransform;

    public ButtonState runButtonState, stepButtonState;

    private ButtonState stopGameButtonState;

    private List<Transform> robots;
    private List<Quaternion> robotsRotations;

    private List<Transform> NonCubeElements; // In Level
    private List<Vector3> localPositionsNonCubeElements;//Соответсвенно по индексу

    void Start()
    {
        NonCubeElements = new List<Transform>();
        localPositionsNonCubeElements = new List<Vector3>();
        robotsRotations = new List<Quaternion>();
        robots = new List<Transform>();
        foreach (Transform child in LevelTransform)
        {
            if (child.tag != "Cube")
            {
                if (child.tag == "Robot")
                {
                    robots.Add(child);
                    robotsRotations.Add(child.rotation);
                }
                NonCubeElements.Add(child);
                localPositionsNonCubeElements.Add(child.localPosition);
            }
        }

        stopGameButtonState = GetComponent<ButtonState>();
    }

    public void StopTheGame()
    {
        stopGameButtonState.Passive();
        foreach (Transform robot in robots)
        {
            robot.GetComponent<RunRobot>().StopRobot();
        }

        PutEverythingBackInPlace();

        
        runButtonState.Activate();
        if (NextStep.isGameOver)
        {
            stepButtonState.Activate();
        }
        RunGame.isRun = false;
        NextStep.isActivated = false;
        NextStep.isGameOver = false;
    }

    private void PutEverythingBackInPlace()
    {
        //Отодвинуть панель результата
        Level.result.PushBackTheResult();

        for (int i = 0; i < NonCubeElements.Count; i++)
        {
            NonCubeElements[i].localPosition = localPositionsNonCubeElements[i];
        }

        for (int i = 0; i < robots.Count; i++)
        {
            robots[i].rotation = robotsRotations[i];
        }
    }

}
