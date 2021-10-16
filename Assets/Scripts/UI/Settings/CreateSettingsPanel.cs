using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSettingsPanel : MonoBehaviour
{
    public GameObject settingsPanel;
    public void CreatePanel()
    {
        Instantiate(settingsPanel, transform.parent);
    }
}
