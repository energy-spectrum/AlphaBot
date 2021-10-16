using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeCounter : MonoBehaviour
{
    public Text counterText;
    public const int LIMIT_ITERATIONS = 10 * 1000;

    private string [] storageOfConditions;
    void Start()
    {
        storageOfConditions = transform.parent.GetComponent<StorageOfConditions>().storageOfConditions;

        counterText.text = storageOfConditions[0];
    }

    public void ChangeCounter_(int delta)
    {
        int counter = int.Parse(counterText.text) + delta;

        if (counter < 0)
        {
            counter = 0;
        }
        if (counter > LIMIT_ITERATIONS)
        {
            counter = LIMIT_ITERATIONS;
        }
        counterText.text = counter.ToString();

        storageOfConditions[0] = counterText.text;
    }
}
