using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionInitialization : MonoBehaviour
{
    public string[] storageOfConditions;

    public List<UnityEngine.UI.Text> elementsCondition;

    public void Initialization(string[] storageOfConditions)
    {
        this.storageOfConditions = storageOfConditions;

        for (int i = 0; i < storageOfConditions.Length; i++)
        {         
            elementsCondition[i].text = storageOfConditions[i];        
        }
    } 
}
