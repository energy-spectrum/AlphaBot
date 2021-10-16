using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tests : MonoBehaviour
{
    private string[] tests = { "\n\tGuide the robot to the finish cube", "\n\tCollect all coins | " };
    void Start()
    {
        Text text = GetComponent<Text>();

        if (Level.isfinishCubeInPosition.Count != 0)
        {
            text.text += tests[0];
        }
        if(Level.coin.Count != 0)
        {
            text.text += tests[1] + Level.coin.Count.ToString();
        }
    }
}
