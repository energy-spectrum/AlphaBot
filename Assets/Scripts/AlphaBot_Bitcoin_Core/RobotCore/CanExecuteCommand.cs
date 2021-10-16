using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlphaBot_Bitcoin;

namespace AlphaBot_Bitcoin.RobotCore
{
    class CanExecuteCommand
    {
        static public HashSet<Vector3> isCubeInPosition;
        static public float _lowestPositionY;
        static private bool DistanceDifference(Directions direction, Vector3 localPositionRobot)
        {
            Vector3 distanceDifference = Vector3.zero;
            switch ((Directions)(((int)direction) % 4))
            {
                case Directions.North:
                    distanceDifference = Vector3.forward;
                    break;
                case Directions.East:
                    distanceDifference = Vector3.right;
                    break;
                case Directions.South:
                    distanceDifference = Vector3.back;
                    break;
                case Directions.West:
                    distanceDifference = Vector3.left;
                    break;
            }
       
            if (isCubeInPosition.Contains(localPositionRobot + Vector3.down + distanceDifference) 
             && !isCubeInPosition.Contains(localPositionRobot + distanceDifference))
            {
                return true;
            }
            return false;
        }

        //Для получения координат робота после прыжка
        static public Vector3 distanceDifference, pos;
        static public bool CanExecute(Commands command, Vector3 localPositionRobot, Directions direction)
        {
            bool can = false;
            switch (command)
            {
                case Commands.MoveForward:
                    can = DistanceDifference(direction, localPositionRobot);
                    break;
                case Commands.MoveBackward:
                    can = DistanceDifference(direction, localPositionRobot);
                    break;
                case Commands.MoveRight:
                    can = DistanceDifference(direction, localPositionRobot);
                    break;
                case Commands.MoveLeft:
                    can = DistanceDifference(direction, localPositionRobot);
                    break;
                case Commands.Jump:
                    switch ((Directions)(((int)direction) % 4))
                    {
                        case Directions.North:
                            distanceDifference = Vector3.forward;
                            break;
                        case Directions.East:
                            distanceDifference = Vector3.right;
                            break;
                        case Directions.South:
                            distanceDifference = Vector3.back;
                            break;
                        case Directions.West:
                            distanceDifference = Vector3.left;
                            break;
                    }
                    pos = localPositionRobot + distanceDifference;
                    //
                    //if (isCubeInPosition.Contains(pos))
                    //{
                    //    int a = 0;
                    //}
                    //if(!isCubeInPosition.Contains(pos + Vector3.up))
                    //{
                    //    int b = 0;
                    //}
                    //
                    if (isCubeInPosition.Contains(pos) && !isCubeInPosition.Contains(pos + Vector3.up))
                    {
                        can = true;
                        pos += Vector3.up;
                    }
                    else if(!isCubeInPosition.Contains(pos + Vector3.down))
                    {
                        pos += Vector3.down * 2;

                        while (_lowestPositionY <= pos.y)
                        {
                            if (isCubeInPosition.Contains(pos))
                            {
                                can = true;
                                break;
                            }
                            pos += Vector3.down;
                        }

                        pos += Vector3.up;
                    }

                    break;
                case Commands.Pick:
                    can = Level.coin.ContainsKey(localPositionRobot);               
                    break;

                case Commands.Activate:
                    can = false;
                    break;
           
                //Все остальное, что не нужно проверять
                default:
                    break;
            }

            return can;
        }
    }
}
