using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AlphaBot_Bitcoin { 
    public class IsGameOver
    {
        static public HashSet<Vector3> isfinishCubeInPosition;
        static public int numberViruses;
        static public bool IsGameOver_(Vector3 localPositionRobot, int numberСollectedСoins)
        {
            bool isGameOver = true;

            if (isfinishCubeInPosition.Count != 0)
            {
                isGameOver = isGameOver && isfinishCubeInPosition.Contains(localPositionRobot + Vector3.down);
            }
            isGameOver = isGameOver && (Level.coin.Count == numberСollectedСoins);
           // isGameOver = isGameOver && (numberDioactivations == numberViruses);

            return isGameOver;
        }
    }
}
