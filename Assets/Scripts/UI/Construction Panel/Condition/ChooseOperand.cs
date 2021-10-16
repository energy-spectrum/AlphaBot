using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChooseOperand : MonoBehaviour
{
    static public Text textOperand;

    public GameObject listOperandsPrefab;
    public Vector3 localPosition;
    public void ChooseOperand_()
    {
        Destroy(WhichPanelIsActivated.listPanel);

        textOperand = transform.GetComponentInChildren<Text>();

        Transform listOperandsTransform = Instantiate<GameObject>(listOperandsPrefab, transform.parent).transform;
        listOperandsTransform.localPosition = localPosition;
        listOperandsTransform.GetChild(0).GetComponent<Button>().onClick.Invoke();

        WhichPanelIsActivated.listPanel = listOperandsTransform.gameObject;
    }
}
