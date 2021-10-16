using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightClicked : MonoBehaviour, IPointerDownHandler
{
    CreateConstructionPanel createConstructionPanel;

    private void Start()
    {
        createConstructionPanel = GetComponent<CreateConstructionPanel>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(1))
        {
            createConstructionPanel.CreateConstructionPanel_();
        }
    }
}
