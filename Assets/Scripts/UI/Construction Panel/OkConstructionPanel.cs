using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkConstructionPanel : MonoBehaviour
{
    public void Ok()
    {
        string[] storageOfConditions = transform.parent.GetComponent<StorageOfConditions>().storageOfConditions;

        for (int i = 0; i < storageOfConditions.Length; i++)
        {
            if (storageOfConditions[i] == "Operand"
                || storageOfConditions[i] == "Operator")
            {
                Ban();
                return;
            }              
        }

        Destroy(transform.parent.gameObject);
    }

    private void Ban()
    {
        print("BAAAN!!!!!! Condition is not initialization!");
    }
    
}
