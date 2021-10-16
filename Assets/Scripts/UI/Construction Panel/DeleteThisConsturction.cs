using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteThisConsturction : MonoBehaviour
{
    public void Delete()
    {
        DeleteConstruction.isActive = true;
        transform.parent.GetComponent<StorageOfConditions>().constructionPanel.GetComponent<OnClickConstruction>().OnClick();
        DeleteConstruction.isActive = false;

        Destroy(transform.parent.gameObject);
    }
}
