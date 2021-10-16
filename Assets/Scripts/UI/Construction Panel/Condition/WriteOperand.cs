using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteOperand : MonoBehaviour
{
    public void WriteOperand_(string s)
    {
        string operand = ChooseOperand.textOperand.text;

        //                                   '1' т к число не начинается с нуля
        if (('0' <= s[0] && s[0] <= '9') && ('1' <= operand[0] && operand[0] <= '9'))
        {         
            operand += s;             
        }
        else
        {
            operand = s;
        }

        ChooseOperand.textOperand.text = operand;
    }

    public void DeleteLastNumeral()
    {
        string operand = ChooseOperand.textOperand.text;
        if ('1' <= operand[0] && operand[0] <= '9')
        {
            ChooseOperand.textOperand.text = operand.Remove(operand.Length - 1, 1);

            if (ChooseOperand.textOperand.text.Length == 0)
            {
                ChooseOperand.textOperand.text = "0";
            }
        }
    }
}
