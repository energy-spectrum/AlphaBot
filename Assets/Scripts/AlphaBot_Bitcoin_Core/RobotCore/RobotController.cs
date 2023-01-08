using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlphaBot_Bitcoin;

namespace AlphaBot_Bitcoin.RobotCore
{
    public class RobotController : MonoBehaviour
    {
        public Directions startDirection;

        private List<Commands> commands;

        private int batteryCharge;

        private Vector3 _localPositionRobot;

        private Directions direction;

        private int numberCollectedCoins = 0;

        private Dictionary<short, List<string>> functions;
        public void Initialization(List<string> allCode, int batteryCharge)
        {
            _localPositionRobot = transform.localPosition;

            numberCollectedCoins = 0;

            direction = startDirection;

            this.batteryCharge = batteryCharge;

            _isGameOver = false;
            _conditionInIfIsTrue = false;

            commands = new List<Commands>();

            functions = new Dictionary<short, List<string>>();
            short idxFunction = 0;
            for (int i = 0; i < allCode.Count; i++)
            {
                List<string> codeBlock = new List<string>();
                if (allCode[i] == "Function")
                {
                    idxFunction = short.Parse(allCode[i + 1]);
                    i += 2;
                    short countBrace = 0;                   
                    for (bool isBreak = false; i < allCode.Count && !isBreak; i++)
                    {                     
                        switch (allCode[i])
                        {
                            case "If":
                                codeBlock.Add("If");
                                //Condition
                                codeBlock.Add(allCode[++i]);

                                break;
                            case "Else":
                                codeBlock.Add("Else");

                                break;
                            case "While":
                                codeBlock.Add("While");
                                //Condition
                                codeBlock.Add(allCode[++i]);

                                break;
                            case "For":
                                codeBlock.Add("For");
                                //Condition
                                codeBlock.Add(allCode[++i]);

                                break;

                            case "FunctionCall":
                                codeBlock.Add("FunctionCall");
                                //Numer of Function
                                codeBlock.Add(allCode[++i]);
                                break;

                            case "{":
                                codeBlock.Add("{");
                                countBrace++;
                                break;

                            case "}":
                                codeBlock.Add("}");
                                countBrace--;
                               
                                if (countBrace == 0)
                                {
                                    codeBlock.RemoveAt(codeBlock.Count - 1);
                                    isBreak = true;
                                   
                                    i--;
                                }
                                
                                break;

                            default:
                                codeBlock.Add(allCode[i]);
                                break;
                        }                       
                    }                 
                }
                functions.Add(idxFunction, codeBlock);
            }

            Function(functions[0]);

            commands.Add(Commands.GameOver);
            GetComponent<RunRobot>().Run(commands);
        }

        private bool _isGameOver = false;

        private bool _conditionInIfIsTrue = false;

        bool If(string condition, List<string> codeBlock)
        {
            if (CheckCondition.IsTrue(condition, _localPositionRobot, (Directions)(((int)direction) % 4)))
            {
                Function(codeBlock);

                return true;
            }

            return false;
        }

        void Else(List<string> codeBlock)
        {
            if (!_conditionInIfIsTrue)
            {
                Function(codeBlock);
            }
        }

        void While(string condition, List<string> codeBlock)
        {
            while (CheckCondition.IsTrue(condition, _localPositionRobot, direction))
            {
                if (_isGameOver)
                {
                    return;
                }
                Function(codeBlock);
            }
        }

        void For(string condition, List<string> codeBlock)
        {
            int countIteration = int.Parse(condition);
            for (int i = 0; i < countIteration; i++)
            {
                if (_isGameOver)
                {
                    return;
                }
                Function(codeBlock);
            }
        }
   
        private void Function(List<string> codeBlock)
        {
            if (_isGameOver)
            {
                return;
            }
            for (int i = 0; i < codeBlock.Count; i++)
            {
                string condition;

                switch (codeBlock[i])
                {
                    //Actions
                    //Move
                    case "MoveForward":
                        Commands moveCommand = Commands.MoveForward;
                        Vector3 directionOfMovement = Vector3.forward;
                        batteryÑharge--;
                        switch ((Directions)((int)direction % 4))
                        {
                            case Directions.North:
                                moveCommand = Commands.MoveForward;
                                directionOfMovement = Vector3.forward;
                                break;
                            case Directions.East:
                                moveCommand = Commands.MoveRight;
                                directionOfMovement = Vector3.right;
                                break;
                            case Directions.South:
                                moveCommand = Commands.MoveBackward;
                                directionOfMovement = Vector3.back;
                                break;
                            case Directions.West:
                                moveCommand = Commands.MoveLeft;
                                directionOfMovement = Vector3.left;
                                break;
                            default:
                                break;
                        }
                        if (CanExecuteCommand.CanExecute(moveCommand, _localPositionRobot, direction))
                        {
                            commands.Add(moveCommand);
                            _localPositionRobot += directionOfMovement;
                        }
                        else
                            commands.Add(Commands.Ban);
                        
                        break;

                    case "MoveBackward":
                        batteryCharge--;
                        if (CanExecuteCommand.CanExecute(Commands.MoveBackward, _localPositionRobot, direction + 2))
                        {
                            commands.Add(Commands.MoveBackward);
                            _localPositionRobot += Vector3.back;
                        }
                        else
                            commands.Add(Commands.Ban);

                        break;

                    case "MoveLeft":
                        batteryCharge--;
                        if (CanExecuteCommand.CanExecute(Commands.MoveLeft, _localPositionRobot, direction - 1))
                        {
                            commands.Add(Commands.MoveLeft);
                            _localPositionRobot += Vector3.left;
                        }
                        else
                            commands.Add(Commands.Ban);

                        break;

                    case "MoveRight":
                        batteryCharge--;
                        if (CanExecuteCommand.CanExecute(Commands.MoveRight, _localPositionRobot, direction + 1))
                        {
                            commands.Add(Commands.MoveRight);
                            _localPositionRobot += Vector3.right;
                        }
                        else
                            commands.Add(Commands.Ban);

                        break;
                    //Turn
                    case "TurnLeft":
                        batteryCharge--;

                        commands.Add(Commands.TurnLeft);
                        //direction -= 1;
                        direction = OperatorsForDirections.Sum((int)direction, -1);

                        break;

                    case "TurnRight":
                        batteryCharge--;

                        commands.Add(Commands.TurnRight);
                        //print(direction);
                        direction = OperatorsForDirections.Sum((int)direction, +1);
                        //print(direction + "\n");
                        break;
                    //Jump
                    case "Jump":
                        batteryCharge--;
                        if (CanExecuteCommand.CanExecute(Commands.Jump, _localPositionRobot, direction))
                        {
                            if (_localPositionRobot.y < CanExecuteCommand.pos.y)
                            {
                                commands.Add(Commands.JumpUp);
                                switch (direction)
                                {
                                    case Directions.North:
                                        commands.Add(Commands.JumpForward);
                                        break;
                                    case Directions.East:
                                        commands.Add(Commands.JumpRight);
                                        break;
                                    case Directions.South:
                                        commands.Add(Commands.JumpBack);
                                        break;
                                    case Directions.West:
                                        commands.Add(Commands.JumpLeft);
                                        break;
                                }
                            }
                            else
                            {
                                for (int countJumpDown = 0; countJumpDown < _localPositionRobot.y - CanExecuteCommand.pos.y; countJumpDown++)
                                {
                                    commands.Add(Commands.JumpDown);
                                }
                                switch (direction)
                                {
                                    case Directions.North:
                                        commands.Add(Commands.JumpForward);
                                        break;
                                    case Directions.East:
                                        commands.Add(Commands.JumpRight);
                                        break;
                                    case Directions.South:
                                        commands.Add(Commands.JumpBack);
                                        break;
                                    case Directions.West:
                                        commands.Add(Commands.JumpLeft);
                                        break;
                                }
                            }
                            _localPositionRobot = CanExecuteCommand.pos;
                        }
                        else
                            commands.Add(Commands.Ban);

                        break;
                    //Activate
                    case "Activate":
                        batteryCharge--;
                        if (CanExecuteCommand.CanExecute(Commands.Activate, _localPositionRobot, direction))
                            commands.Add(Commands.Activate);
                        else
                            commands.Add(Commands.Ban);

                        break;
                    //Pick
                    case "Pick":
                        batteryCharge--;
                        if (CanExecuteCommand.CanExecute(Commands.Pick, _localPositionRobot, direction))
                        {
                            commands.Add(Commands.Pick);
                            numberCollectedCoins++;
                        }
                        else
                            commands.Add(Commands.Ban);

                        break;

                    //FunctionCall
                    case "FunctionCall":
                        Function(functions[short.Parse(codeBlock[++i])]);
                        break;

                    //Constructions               
                    case "If":
                        condition = codeBlock[++i];

                        _conditionInIfIsTrue = If(condition, ReadCodeBlockConstruction(ref codeBlock, ref i));
                        break;
                    case "Else":
                        Else(ReadCodeBlockConstruction(ref codeBlock, ref i));
                        break;

                    case "While":
                        condition = codeBlock[++i];

                        While(condition, ReadCodeBlockConstruction(ref codeBlock, ref i));
                        break;

                    case "For":
                        condition = codeBlock[++i];

                        For(condition, ReadCodeBlockConstruction(ref codeBlock, ref i));
                        break;
                }

                if (batteryCharge == 0 || IsGameOver.IsGameOver_(_localPositionRobot, numberCollectedCoins))
                {
                    _isGameOver = true;
                    return;
                }
            }
        }

        List<string> ReadCodeBlockConstruction(ref List<string> codeBlock, ref int i)
        {
            List<string> codeBlockConstruction = new List<string>();

            i += 2;
            int countBrace = 1;

            for (; countBrace != 0; i++)
            {
                if (codeBlock[i] == "}")
                {
                    countBrace--;
                }
                if (codeBlock[i] == "{")
                {
                    countBrace++;
                }

                codeBlockConstruction.Add(codeBlock[i]);
            }

            i--;
            return codeBlockConstruction;
        }

    }
}
