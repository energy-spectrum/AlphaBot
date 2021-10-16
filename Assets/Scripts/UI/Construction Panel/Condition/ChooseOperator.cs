using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseOperator : MonoBehaviour
{
    static public UnityEngine.UI.Text textOperator;

    public GameObject listOperatorsPrefab;

    public Vector3 localPosition;
    public void ChooseOperator_()
    {
        Destroy(WhichPanelIsActivated.listPanel);
        Destroy(WhichPanelIsActivated.panel);


        textOperator = transform.GetComponentInChildren<UnityEngine.UI.Text>();

        Transform listOperatorsTransform = Instantiate<GameObject>(listOperatorsPrefab, transform.parent).transform;
        listOperatorsTransform.localPosition = localPosition;

        WhichPanelIsActivated.listPanel = listOperatorsTransform.gameObject;
    }
}
