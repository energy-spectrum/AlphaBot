//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AlphaBot_Bitcoin;
using System.IO;

public class OnCliceOnCell : MonoBehaviour
{
    public Material forward_Arrow, back_Arrow, right_Arrow, left_Arrow, jump, activate, pick, turnRight, turnLeft;
    
    public Commands command;
    public string numerFunctionCall;

    public Text text;

    private Image imageCell;

    Sprite spriteR;
    private void Start()
    {
        imageCell = GetComponent<Image>();

        spriteR = imageCell.sprite;
    }

    public void OnClice()
    {
        if (Erase.isActive)
        {
            command = Commands.None;
            imageCell.sprite = spriteR;
            imageCell.material = null;
            imageCell.color = Color.white;
            text.text = "";

            return;
        }
        if (ChooseCommandOrConstruction.command != Commands.None)
        {
            //Тупой способ Обнуления Sourse Image в None
            imageCell.sprite = Sprite.Create(Resources.Load<Texture2D>(@"EMPTY"), new Rect(new Vector2(0f, 1f), new Vector2(32f, 32f)),
                                             new Vector2(0.5f, 0.5f));

            command = ChooseCommandOrConstruction.command;
            Color colorTemp = text.color;
            colorTemp.a = 0f;
            text.color = colorTemp;

            switch (command)
            {
                case Commands.MoveForward:
                    imageCell.material = forward_Arrow;
                    break;
                case Commands.MoveBackward:
                    imageCell.material = back_Arrow;
                    break;
                case Commands.MoveRight:
                    imageCell.material = right_Arrow;
                    break;
                case Commands.MoveLeft:
                    imageCell.material = left_Arrow;
                    break;
                case Commands.Jump:
                    imageCell.material = jump;
                    break;
                case Commands.Activate:
                    imageCell.material = activate;
                    break;
                case Commands.Pick:
                    imageCell.material = pick;
                    break;
                case Commands.TurnRight:
                    imageCell.material = turnRight;
                    break;
                case Commands.TurnLeft:
                    imageCell.material = turnLeft;
                    break;

                case Commands.FunctionCall:
                    colorTemp.a = 1f;
                    text.color = colorTemp;
                    text.text = "Func() " + ChooseCommandOrConstruction.numerFunction;

                    imageCell.sprite = spriteR; 
                    imageCell.color = ChooseCommandOrConstruction.colorImage;

                    numerFunctionCall = ChooseCommandOrConstruction.numerFunction;
                    break;              
            }
        }
        else if (ChooseCommandOrConstruction.construction != Constructions.None)
        {
            if (ChooseCommandOrConstruction.construction == Constructions.IfElse && !(transform.parent.GetChild(transform.GetSiblingIndex() + 1).tag == "Cell"))
            {
                return;
            }
            CreateConstruction.CreateConstruction_(ChooseCommandOrConstruction.construction, transform.GetSiblingIndex());
        }
    }
}
