using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePanel : MonoBehaviour
{
    public GameObject panelPreafab;
    public Vector3 localPosition;
   
    public void CreatePanel_()
    {
        Destroy(WhichPanelIsActivated.panel);
        WhichPanelIsActivated.panel = Instantiate<GameObject>(panelPreafab, transform.parent.parent);
        WhichPanelIsActivated.panel.transform.localPosition = localPosition;
    }
}
