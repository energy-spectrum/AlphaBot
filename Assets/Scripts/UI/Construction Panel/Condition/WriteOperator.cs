using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteOperator : MonoBehaviour
{
    public void WriteOperator_(string selectedOperator)
    {        
        ChooseOperator.textOperator.text = selectedOperator;
    }
}
