using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AddFunctionCall : MonoBehaviour
{
    public Transform functionsPanelTransform;
    public GameObject functionCallPrefab;
    public GameObject AddFunctionCall_(Color color, short numer)
    {
        Transform functionCallTransform = Instantiate<GameObject>(functionCallPrefab, functionsPanelTransform).transform;

        functionCallTransform.GetComponent<Image>().color = color;
        functionCallTransform.name = "FunctionCall " + numer.ToString();

        return functionCallTransform.gameObject;
    }
}
