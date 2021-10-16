using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AlphaBot_Bitcoin;

public class ChooseCommandOrConstruction : MonoBehaviour
{
    public Commands commandInBar; 
    public Constructions constructionInBar;

    public static Commands command = Commands.None; 
    public static string numerFunction;
    //Временно!
    public static Color colorImage;
    public static Constructions construction = Constructions.None;

    public void СhooseCommand()//Commands selectedCommand)
    {
        TurnOffAllTools.Off();

        command = commandInBar;// selectedCommand;
        construction = Constructions.None;

        if (command == Commands.FunctionCall)
        {
            numerFunction = transform.name.Split(' ')[1];
            //Временно!
            colorImage = transform.GetComponent<Image>().color;         
        }
    }

    public void СhooseConstruction()//Constructions selectedConstruction)
    {
        TurnOffAllTools.Off();

        construction = constructionInBar;// selectedConstruction;

        command = Commands.None;
    }
}
