using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AlphaBot_Bitcoin.RobotCore;
using AlphaBot_Bitcoin;
public class RunGame : MonoBehaviour
{
    public Transform cellsTransform;

    public ButtonState runButtonState, StopGameButtonState;
    private string GetCondition(string[] storageOfConditions)
    {
        string condition = "";

        foreach (string el in storageOfConditions)
        {
            condition += el + ' ';
        }

        return condition.Remove(condition.Length - 1);
    }

    static public bool isRun = false;
    public void Run()
    {
        isRun = true;
        
        runButtonState.Passive();
        StopGameButtonState.Activate();

        List<string> allCode = new List<string>();

        foreach (Transform child in cellsTransform)
        {
            switch (child.tag)
            {
                case "Cell":
                    Commands command = child.GetComponent<OnCliceOnCell>().command;
                    if (command != Commands.None)
                    {                     
                        allCode.Add(command.ToString());
                        //Íîìåð âûçûâàåìîé ôóíêöèè
                        if (command == Commands.FunctionCall)
                        {
                            allCode.Add(child.GetComponent<OnCliceOnCell>().numerFunctionCall);
                        }
                    }
                 
                    break;

                case "Function":
                    allCode.Add("Function");
                    allCode.Add(child.name.Split(' ')[1]);

                    allCode.Add("{");
                    break;

                case "Brace":
                    allCode.Add("}");

                    break;

                case "If":
                    allCode.Add("If");                  
                    allCode.Add(GetCondition(child.GetComponent<StorageOfConditions>().storageOfConditions));
                    allCode.Add("{");

                    break;

                case "Else":
                    allCode.Add("Else");                
                    allCode.Add("{");

                    break;

                case "While":
                    allCode.Add("While");
                    allCode.Add(GetCondition(child.GetComponent<StorageOfConditions>().storageOfConditions));
                    allCode.Add("{");

                    break;

                case "For":
                    allCode.Add("For");
                    allCode.Add(GetCondition(child.GetComponent<StorageOfConditions>().storageOfConditions));
                    allCode.Add("{");

                    break;
                default:
                    break;
            }
        }

        int batteryÑharge = 100;
        BatyaRobotController.Initialization(allCode, batteryÑharge);
    }

    public RobotController BatyaRobotController;
}