using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlphaBot_Bitcoin;

namespace AlphaBot_Bitcoin.RobotCore
{
    public class RunRobot : MonoBehaviour
    {
        [Range(0f, 5f)]
        public float WalkingAnimationSpeedInput = 1f;

        [Range(0f, 1f)]
        public float PausingAnimationSpeedInput = 0.4f;

        [Range(0f, 5f)]
        public float TurningAnimationSpeedInput = 1f;

        public float turningBoost = 50f;

        [Range(0f, 5f)]
        public float JumpUpAnimationSpeedInput = 1f;
        [Range(0f, 5f)]
        public float JumpDownAnimationSpeedInput = 2f;

        [Range(0f, 5f)]
        public float TeleportationSpeedInput = 0.4f;


        public float WalkingAnimationSpeed, PausingAnimationSpeed, TurningAnimationSpeed,
                     JumpUpAnimationSpeed, JumpDownAnimationSpeed, TeleportationSpeed;

        public Actions currentAction, jumpDirection;

        private List<Commands> commands;
        private Vector3 localPositionRobot;
        private float angleYRobot, deltaY = 0f;
        private int numberСollectedСoins;
        private bool inAction = false;
        private int idxCommand;

        private Transform thisTransform;
        private void Start()
        {
            thisTransform = transform;
        }
        public void Run(List<Commands> commands)
        {
            float speedAnimation = PlayerPrefs.GetFloat("speedAnimation");
       
            PausingAnimationSpeed = PausingAnimationSpeedInput / speedAnimation;
            WalkingAnimationSpeed = WalkingAnimationSpeedInput * speedAnimation;
            TurningAnimationSpeed = TurningAnimationSpeedInput * speedAnimation;
            JumpUpAnimationSpeed = JumpUpAnimationSpeedInput * speedAnimation;
            JumpDownAnimationSpeed = JumpDownAnimationSpeedInput * speedAnimation;
            TeleportationSpeed = TeleportationSpeedInput * speedAnimation;

            isJumpComplete = false;
            isStopY = false;
            deltaY = 0;
            numberСollectedСoins = 0;
            idxCommand = 0;
            this.commands = commands;

            localPositionRobot = thisTransform.localPosition;
            angleYRobot = thisTransform.rotation.eulerAngles.y;

            NextAction();
        }

        int countJumpDown;
        private void NextAction()
        {
            if (idxCommand < commands.Count)
            {
                switch (commands[idxCommand])
                {
                    case Commands.MoveForward:
                        currentAction = Actions.WalkForward;
                        break;
                    case Commands.MoveBackward:
                        currentAction = Actions.WalkBackward;
                        break;
                    case Commands.MoveRight:
                        currentAction = Actions.WalkRight;
                        break;
                    case Commands.MoveLeft:
                        currentAction = Actions.WalkLeft;
                        break;
                    case Commands.JumpUp:
                        currentAction = Actions.JumpUp;
                        switch (commands[++idxCommand])
                        {
                            case Commands.JumpForward:
                                jumpDirection = Actions.JumpForward;
                                break;
                            case Commands.JumpBack:
                                jumpDirection = Actions.JumpBack;
                                break;
                            case Commands.JumpRight:
                                jumpDirection = Actions.JumpRight;
                                break;
                            case Commands.JumpLeft:
                                jumpDirection = Actions.JumpLeft;
                                break;
                        }
                        break;
                    case Commands.JumpDown:
                        currentAction = Actions.JumpDown;
                        countJumpDown = 0;
                        for (; idxCommand < commands.Count; idxCommand++)
                        {
                            if (commands[idxCommand] == Commands.JumpDown)
                                countJumpDown++;
                            else
                                break;
                        }
                        switch (commands[idxCommand])
                        {
                            case Commands.JumpForward:
                                jumpDirection = Actions.JumpForward;
                                break;
                            case Commands.JumpBack:
                                jumpDirection = Actions.JumpBack;
                                break;
                            case Commands.JumpRight:
                                jumpDirection = Actions.JumpRight;
                                break;
                            case Commands.JumpLeft:
                                jumpDirection = Actions.JumpLeft;
                                break;
                        }
                        break;
                    case Commands.Pick:
                        currentAction = Actions.Pick;
                        break;
                    case Commands.Activate:
                        currentAction = Actions.Activate;
                        break;
                    case Commands.TurnRight:
                        currentAction = Actions.TurnRight;
                        break;
                    case Commands.TurnLeft:
                        currentAction = Actions.TurnLeft;
                        break;
                    case Commands.Ban:
                        currentAction = Actions.Ban;
                        break;
                    case Commands.GameOver:
                        currentAction = Actions.GameOver;
                        break;
                    default:
                        print("Не обработал!!!");
                        print(commands[idxCommand]);
                        break;
                }

                idxCommand++;
                if (currentAction == Actions.GameOver)
                {
                    inAction = true;
                }
                else
                {
                    inAction = !NextStep.isActivated;
                }
            }
        }

        public void NextStep_()
        {
            inAction = true;
        }
        public void Pause(bool pause)
        {
            inAction = false;
        }

        void JumpTowards(Actions jumpDirection)
        {
            switch (jumpDirection)
            {
                case Actions.JumpForward:
                    thisTransform.Translate(Vector3.forward * Time.deltaTime * JumpUpAnimationSpeed, Space.World);
                    if (localPositionRobot.z + 1 <= thisTransform.localPosition.z)
                    {
                        localPositionRobot += Vector3.forward;
                        isJumpComplete = true;
                    }
                    break;
                case Actions.JumpBack:
                    thisTransform.Translate(Vector3.back * Time.deltaTime * JumpUpAnimationSpeed, Space.World);
                    if (localPositionRobot.z - 1 >= thisTransform.localPosition.z)
                    {
                        localPositionRobot += Vector3.back;
                        isJumpComplete = true;
                    }
                    break;
                case Actions.JumpRight:
                    thisTransform.Translate(Vector3.right * Time.deltaTime * JumpUpAnimationSpeed, Space.World);
                    if (localPositionRobot.x + 1 <= thisTransform.localPosition.x)
                    {
                        localPositionRobot += Vector3.right;
                        isJumpComplete = true;
                    }
                    break;
                case Actions.JumpLeft:
                    thisTransform.Translate(Vector3.left * Time.deltaTime * JumpUpAnimationSpeed, Space.World);
                    if (localPositionRobot.x - 1 >= thisTransform.localPosition.x)
                    {
                        localPositionRobot += Vector3.left;
                        isJumpComplete = true;
                    }
                    break;
            }
        }

        bool isJumpComplete = false, isStopY = false;
        private void Update()
        {
            if (inAction)
            {
                switch (currentAction)
                {
                    case Actions.WalkForward:
                        thisTransform.Translate(Vector3.forward * Time.deltaTime * WalkingAnimationSpeed, Space.World);

                        if (localPositionRobot.z + 1 <= thisTransform.localPosition.z)
                        {
                            localPositionRobot += Vector3.forward;
                            thisTransform.localPosition = localPositionRobot;

                            inAction = false;
                            Invoke("NextAction", PausingAnimationSpeed);
                        }
                        break;
                    case Actions.WalkBackward:
                        thisTransform.Translate(Vector3.back * Time.deltaTime * WalkingAnimationSpeed, Space.World);

                        if (localPositionRobot.z - 1 >= thisTransform.localPosition.z)
                        {
                            localPositionRobot += Vector3.back;
                            thisTransform.localPosition = localPositionRobot;

                            inAction = false;
                            Invoke("NextAction", PausingAnimationSpeed);
                        }
                        break;
                    case Actions.WalkRight:
                        thisTransform.Translate(Vector3.right * Time.deltaTime * WalkingAnimationSpeed, Space.World);

                        if (localPositionRobot.x + 1 <= thisTransform.localPosition.x)
                        {
                            localPositionRobot += Vector3.right;
                            thisTransform.localPosition = localPositionRobot;

                            inAction = false;
                            Invoke("NextAction", PausingAnimationSpeed);
                        }
                        break;
                    case Actions.WalkLeft:
                        thisTransform.Translate(Vector3.left * Time.deltaTime * WalkingAnimationSpeed, Space.World);

                        if (localPositionRobot.x - 1 >= thisTransform.localPosition.x)
                        {
                            localPositionRobot += Vector3.left;
                            thisTransform.localPosition = localPositionRobot;

                            inAction = false;
                            Invoke("NextAction", PausingAnimationSpeed);
                        }
                        break;
                    
                    case Actions.TurnRight:
                        deltaY += turningBoost * Time.deltaTime * TurningAnimationSpeed;
                        thisTransform.rotation = Quaternion.Euler(thisTransform.rotation.eulerAngles  
                                            + new Vector3(0, turningBoost * Time.deltaTime * TurningAnimationSpeed, 0));

                        if(deltaY >= 90f)
                        {
                            deltaY = (int)deltaY;
                            deltaY -= deltaY % 90;
                            angleYRobot += deltaY;

                            thisTransform.rotation = Quaternion.Euler(new Vector3(0, angleYRobot, 0));

                            deltaY = 0;

                            inAction = false;
                            Invoke("NextAction", PausingAnimationSpeed);
                        }
                        
                        break;
                    case Actions.TurnLeft:
                        deltaY += turningBoost * Time.deltaTime * TurningAnimationSpeed;
                        thisTransform.rotation = Quaternion.Euler(thisTransform.rotation.eulerAngles
                                            - new Vector3(0, turningBoost * Time.deltaTime * TurningAnimationSpeed, 0));

                        if (deltaY >= 90f)
                        {
                            deltaY = (int)deltaY;
                            deltaY -= deltaY % 90;
                            angleYRobot -= deltaY;

                            thisTransform.rotation = Quaternion.Euler(new Vector3(0, angleYRobot, 0));

                            deltaY = 0;

                            inAction = false;
                            Invoke("NextAction", PausingAnimationSpeed);
                        }
                        break;
                    case Actions.JumpUp:
                        if (localPositionRobot.y > thisTransform.localPosition.y - 1 && !isStopY)
                        {
                            thisTransform.Translate(Vector3.up * Time.deltaTime * JumpUpAnimationSpeed, Space.World);
                        }
                        else
                        {
                            if ((localPositionRobot.y != thisTransform.localPosition.y) && (!isStopY))
                            {
                                localPositionRobot += Vector3.up;
                                isStopY = true;
                            }

                            JumpTowards(jumpDirection);

                            if (isJumpComplete)
                            {
                                thisTransform.localPosition = localPositionRobot;
                                isJumpComplete = false; isStopY = false;
                                inAction = false;
                                Invoke("NextAction", PausingAnimationSpeed);
                            }
                        }                        

                        break;
                    case Actions.JumpDown:                        
                        if (!isJumpComplete)
                        {
                            JumpTowards(jumpDirection);
                        }
                        else
                        {
                            if (localPositionRobot.y < thisTransform.localPosition.y + countJumpDown && !isStopY)
                            {
                                thisTransform.Translate(Vector3.down * Time.deltaTime * JumpDownAnimationSpeed, Space.World);
                            }
                            else
                            {
                                localPositionRobot += Vector3.down * countJumpDown;
                                isStopY = true;

                                thisTransform.localPosition = localPositionRobot;
                                isJumpComplete = false; isStopY = false;
                                inAction = false;
                                Invoke("NextAction", PausingAnimationSpeed);
                            }
                        }
                                        
                        break;

                    case Actions.Pick:
                        Level.coin[localPositionRobot].localPosition += Vector3.down;

                        numberСollectedСoins++;

                        inAction = false;
                        Invoke("NextAction", PausingAnimationSpeed);
                        break;

                    case Actions.TeleportIn:
                        break;
                    case Actions.TeleportFrom:
                        break;

                    case Actions.Ban:
                        print("BAAAN!");
                        inAction = false;
                        Invoke("NextAction", PausingAnimationSpeed);
                        break;
                    case Actions.GameOver:
                        //Добавить окно результата прохождения уровня
                        Level.result.ShowResult(localPositionRobot, numberСollectedСoins);

                        NextStep.isGameOver = true;
                        NextStep.Passive();
                        inAction = false;
                        
                        break;
                    default:
                        break;
                }
            }
        }

        public void StopRobot()
        {
            CancelInvoke();
            inAction = false;
            currentAction = Actions.None;
        }
    }
}
