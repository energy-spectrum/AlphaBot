using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Transform thisTransform;
    private void Start()
    {
        thisTransform = transform;
    }
    void Update()
    {
        thisTransform.rotation = Quaternion.Euler(thisTransform.rotation.eulerAngles + new Vector3(0, 20f * Level.coinRotationSpeed * Time.deltaTime, 0));
    }
}
