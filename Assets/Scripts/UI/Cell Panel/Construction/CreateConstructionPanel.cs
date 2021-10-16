using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateConstructionPanel : MonoBehaviour
{
    public GameObject constructionPanelPrefab;
    // public Transform canvasMain;
    // public Transform cellPanelTransform;

    private string[] storageOfConditions;
    void Start()
    {
        storageOfConditions = GetComponent<StorageOfConditions>().storageOfConditions;

        CreateConstructionPanel_();
    }

    public void CreateConstructionPanel_()
    {
        Transform constructionPanelTransform = Instantiate<GameObject>(constructionPanelPrefab, transform.parent.parent).transform;
        // float width = (float)Screen.width / canvasMain.GetComponent<CanvasScaler>().scaleFactor;
        // float height = (float)Screen.height / canvasMain.GetComponent<CanvasScaler>().scaleFactor;

        // constructionPanel.transform.position = new Vector2(width / 2, height / 2);
        // 
        //constructionPanel.transform.localPosition =transform.

        constructionPanelTransform.GetComponent<StorageOfConditions>().storageOfConditions = storageOfConditions;
        constructionPanelTransform.GetComponent<StorageOfConditions>().constructionPanel = this.gameObject;
    }
}
