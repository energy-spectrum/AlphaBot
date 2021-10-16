using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AlphaBot_Bitcoin;
public class Result : MonoBehaviour
{
    public Vector3 positionTo;
    public Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
        PushBackTheResult();
    }
    public Text text;
    public void ShowResult(Vector3 localPositionRobot, int numberСollectedСoins)
    {
        transform.position = startPosition;
        float result = 0;
        List<Tasks> tasks = new List<Tasks>();
        if (Level.isfinishCubeInPosition.Count != 0) //.Contains(localPositionRobot + Vector3.down))
        {
            tasks.Add(Tasks.finishCube);
        }
        if (Level.coin.Count != 0)
        {
            tasks.Add(Tasks.coins);
        }

        foreach (Tasks task in tasks)
        {
            switch (task)
            {
                case Tasks.finishCube:
                    result += 100f / tasks.Count * Convert.ToInt32(Level.isfinishCubeInPosition.Contains(localPositionRobot + Vector3.down));
                    break;
                case Tasks.coins:
                    result += 100f / tasks.Count * numberСollectedСoins / Level.coin.Count;
                    break;
                default:
                    print("Добавь обработку задачи!");
                    break;
            }
        }

        if (100f - result <= 0.0005)
        {
            result = 100;
        }

        text.text = ((int)result).ToString() + '%';
    }
    public void PushBackTheResult()
    {
        transform.position = positionTo;
    }
}

