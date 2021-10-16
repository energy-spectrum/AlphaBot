using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonState : MonoBehaviour
{
    public bool isActivated;
    private Button button;
    private Image image;
    void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        if (!isActivated)
        {
            Passive();
        }
    }

    public void Activate()
    {
        button.interactable = true;
        image.color -= Color.black;
    }

    public void Passive()
    {
        button.interactable = false;
        image.color += Color.black;
    }
}
