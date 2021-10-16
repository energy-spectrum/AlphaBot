using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkCondition : MonoBehaviour
{
    public ConditionInitialization conditionInitialization;
    public void Ok()
    {
        
        for (int i = 0; i < conditionInitialization.elementsCondition.Count; i++)
        {
            if (conditionInitialization.elementsCondition[i].text != "Operand" 
             && conditionInitialization.elementsCondition[i].text != "Operator")
            {
                conditionInitialization.storageOfConditions[i] = conditionInitialization.elementsCondition[i].text;
            }
            else
            {
                Ban();
                return;
            }
        }

        Destroy(conditionInitialization.transform.gameObject);
    }

    private void Ban()
    {
        print("BAAAN!!!!!! Condition is not initialization!");
    }
}
