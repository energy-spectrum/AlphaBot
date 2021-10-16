using System.Collections.Generic;
using UnityEngine;
using AlphaBot_Bitcoin.RobotCore;

namespace AlphaBot_Bitcoin
{
    public class CheckCondition
    {
        static public bool IsTrue(string condition, Vector3 localPositionRobot, Directions direction)
        {
            bool isTrue = false;

            string[] elements = condition.Split(' ');

            List<object> operands = new List<object>();
           
            for (int i = 0; i < elements.Length; i += 2)
            {
                switch (elements[i])
                {
                    case "Rangefinder.Right()":
                        operands.Add(Rangefinder.Right(localPositionRobot, direction));
                        break;
                    case "Rangefinder.Left()":
                        operands.Add(Rangefinder.Left(localPositionRobot, direction));
                        break;
                    case "Rangefinder.Forward()":
                        operands.Add(Rangefinder.Forward(localPositionRobot, direction));
                        break;
                    case "Rangefinder.Back()":
                        operands.Add(Rangefinder.Back(localPositionRobot, direction));
                        break;

                    //If all did'n fit, than this is number
                    default:
                        operands.Add(int.Parse(elements[i]));
                        break;
                }
            }


            if (elements.Length > 3)
            {
                bool isTrue1 = false;
                switch (elements[1])
                {
                    case "<":
                        isTrue1 = (int)operands[0] < (int)operands[1];
                        break;
                    case ">":
                        isTrue1 = (int)operands[0] > (int)operands[1];
                        break;
                    case "<=":
                        isTrue1 = (int)operands[0] <= (int)operands[1];
                        break;
                    case ">=":
                        isTrue1 = (int)operands[0] >= (int)operands[1];
                        break;
                    case "==":
                        isTrue1 = operands[0].Equals(operands[1]);
                        break;
                    case "!=":
                        isTrue1 = !operands[0].Equals(operands[1]);
                        break;
                }

                bool isTrue2 = false;

                switch (elements[5])
                {
                    case "<":
                        isTrue2 = (int)operands[0] < (int)operands[1];
                        break;
                    case ">":
                        isTrue2 = (int)operands[0] > (int)operands[1];
                        break;
                    case "<=":
                        isTrue2 = (int)operands[0] <= (int)operands[1];
                        break;
                    case ">=":
                        isTrue2 = (int)operands[0] >= (int)operands[1];
                        break;
                    case "==":
                        isTrue2 = operands[0].Equals(operands[1]);
                        break;
                    case "!=":
                        isTrue2 = !operands[0].Equals(operands[1]);
                        break;
                }

                switch (elements[3])
                {
                    case "And":
                        isTrue = isTrue1 && isTrue2;
                        break;
                    case "Or":
                        isTrue = isTrue1 || isTrue2;
                        break;
                }
            }
            else
            {
                switch (elements[1])
                {
                    case "<":
                        isTrue = (int)operands[0] < (int)operands[1];
                        break;
                    case ">":
                        isTrue = (int)operands[0] > (int)operands[1];
                        break;
                    case "<=":
                        isTrue = (int)operands[0] <= (int)operands[1];
                        break;
                    case ">=":
                        isTrue = (int)operands[0] >= (int)operands[1];
                        break;
                    case "==":
                        isTrue = operands[0].Equals(operands[1]);
                        break;
                    case "!=":
                        isTrue = !operands[0].Equals(operands[1]);
                        break;
                }
            }

            return isTrue;
        }
    }
}
