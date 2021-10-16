using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeValue : MonoBehaviour
{
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }
    public Slider slider;
    void Update()
    {
        text.text = slider.value.ToString();
        if(text.text.Length > 4)
        {
            text.text = text.text.Substring(0, 4);
        }
    }
}
