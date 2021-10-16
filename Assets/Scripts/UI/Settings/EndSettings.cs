using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSettings : MonoBehaviour
{
    public void Ok()
    {
        transform.parent.GetComponent<Settings>().Save();
        DeletePanel();
    }

    public void DeletePanel()
    {
        Destroy(transform.parent.gameObject);
    }
}
