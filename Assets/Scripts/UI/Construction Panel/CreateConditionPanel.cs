using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateConditionPanel : MonoBehaviour
{
    public GameObject conditionPanelPrefab;
    public Vector3 localPosition;

    public void CreateConditionPanel_()
    {
        Transform conditionPanelTransform = Instantiate<GameObject>(conditionPanelPrefab, transform.parent.parent).transform;
        conditionPanelTransform.localPosition = localPosition;

        conditionPanelTransform.GetComponent<ConditionInitialization>()
        .Initialization(transform.parent.GetComponent<StorageOfConditions>().storageOfConditions);
    }
}
