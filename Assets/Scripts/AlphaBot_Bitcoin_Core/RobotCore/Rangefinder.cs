using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlphaBot_Bitcoin.RobotCore
{
    public class Rangefinder : MonoBehaviour
    {
        static public HashSet<Vector3> isCubeInPosition;

        static public float _lowestPositionY;
        static private int Rangefinder_(Vector3 step, int stepZ, int stepX, Vector3 localPositionRobot)
        {
            Vector3 CubePosition = localPositionRobot + Vector3.down;

            int countCube = 0;
            bool flag = true;
            while (flag)
            {
                CubePosition += step;//new Vector3(stepX, 0, stepZ);

                if (isCubeInPosition.Contains(CubePosition) && !isCubeInPosition.Contains(CubePosition + Vector3.up))
                {
                    countCube++;
                    flag = true;
                }
                else
                    break;

            }

            print(countCube);
            return countCube;
        }
        static public int Left(Vector3 localPositionRobot, Directions direction)
        {
            Vector3 step = Vector3.zero;
            int stepX = 0, stepZ = 0; // На плоскости
            switch (direction)
            {
                case Directions.North:
                    step = Vector3.left;
                    stepX = -1;
                    break;
                case Directions.East:
                    step = Vector3.forward;
                    stepZ = +1;
                    break;
                case Directions.South:
                    step = Vector3.right;
                    stepX = +1;
                    break;
                case Directions.West:
                    step = Vector3.back;
                    stepZ = -1;
                    break;
            }
            Forward(localPositionRobot, direction);
            Right(localPositionRobot, direction);
            Back(localPositionRobot, direction);
            return Rangefinder_(step, stepZ, stepX, localPositionRobot);
        }

        static public int Right(Vector3 localPositionRobot, Directions direction)
        {
            Vector3 step = Vector3.zero;
            int stepX = 0, stepZ = 0; // На плоскости
            switch (direction)
            {
                //Север
                case Directions.North:
                    step = Vector3.right;
                    stepX = +1;
                    break;
                case Directions.East:
                    step = Vector3.back;
                    stepZ = -1;
                    break;
                case Directions.South:
                    step = Vector3.left;
                    stepX = -1;
                    break;
                case Directions.West:
                    step = Vector3.forward;
                    stepZ = +1;
                    break;
            }

            return Rangefinder_(step, stepZ, stepX, localPositionRobot);
        }
        static public int Forward(Vector3 localPositionRobot, Directions direction)
        {
            Vector3 step = Vector3.zero;
            int stepX = 0, stepZ = 0; // На плоскости
            switch (direction)
            {
                case Directions.North:
                    step = Vector3.forward;
                    stepZ = +1;
                    break;
                case Directions.East:
                    step = Vector3.right;
                    stepX = +1;
                    break;
                case Directions.South:
                    step = Vector3.back;
                    stepZ = -1;
                    break;
                case Directions.West:
                    step = Vector3.left;
                    stepX = -1;
                    break;
            }

            return Rangefinder_(step, stepZ, stepX, localPositionRobot);
        }

        static public int Back(Vector3 localPositionRobot, Directions direction)
        {
            Vector3 step = Vector3.zero;
            int stepX = 0, stepZ = 0; // На плоскости
            switch (direction)
            {
                case Directions.North:
                    step = Vector3.back;
                    stepZ = -1;
                    break;
                case Directions.East:
                    step = Vector3.left;
                    stepX = -1;
                    break;
                case Directions.South:
                    step = Vector3.forward;
                    stepZ = +1;
                    break;
                case Directions.West:
                    step = Vector3.right;
                    stepX = +1;
                    break;
            }

            return Rangefinder_(step, stepZ, stepX, localPositionRobot);
        }
    }
}