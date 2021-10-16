using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NumberCellsRemaining : MonoBehaviour
{
    public int numberOfCellsRemaining;

    public Text textNumberCellsRemaining;

    private void Start()
    {
        ChangeNumberCellsRemaining(0);
    }
    public void ChangeNumberCellsRemaining(int delta)
    {
        numberOfCellsRemaining += delta;
        textNumberCellsRemaining.text = numberOfCellsRemaining.ToString();
    }
}
