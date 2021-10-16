using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickConstruction : MonoBehaviour
{
    private MinusCell minusCell;

    private void Start()
    {
        minusCell = GetComponent<MinusCell>();
    }

    public bool isMainFunction;

    public void OnClick()
    {
        if (DeleteConstruction.isActive)
        {
            if (!isMainFunction)
            {
                GetComponent<Construction>().DeleteConstruction();
            }
            else
            {
                print("This function is main. Her don't delete");
            }
        }
        else if (Erase.isActive)
        {
            GetComponent<Construction>().EraseBlockCode();
        }
        else
        {
            minusCell.RemoveLastCellInBlock();
        }
    }
}
