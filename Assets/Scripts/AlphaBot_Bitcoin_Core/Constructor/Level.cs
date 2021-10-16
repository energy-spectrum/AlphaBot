using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlphaBot_Bitcoin;
using AlphaBot_Bitcoin.RobotCore;
using System.Runtime.Serialization.Formatters.Binary;

public class Level : MonoBehaviour
{
    [Range(0.5f, 4f)]
    public float coinRotationSpeedInput = 1;
    static public float coinRotationSpeed;

    public Result resultInput;
    static public Result result;

    private HashSet<Vector3> isCubeInPosition;

    static public HashSet<Vector3> isfinishCubeInPosition;

    static public HashSet<Vector3> isVirusInPosition;
    //Очень важно решить вопрос с монетками 
    static public Dictionary<Vector3, Transform> coin;
    //static public HashSet<Vector3> isCoinInPosition;

    //static public Transform robotTransform;
    static public Robots robot;

    public RunGame runGame;

    private float _lowestPositionY = 1000 * 1000;

    void Start()
    {
        result = resultInput;
        //EqualityComparerCoordinates r = new EqualityComparerCoordinates() ;
        isCubeInPosition = new HashSet<Vector3>();
        isfinishCubeInPosition = new HashSet<Vector3>();
        isVirusInPosition = new HashSet<Vector3>();
        coin = new Dictionary<Vector3, Transform>();

        foreach (Transform child in transform)
        {
            if (child.tag == "Cube")
            {
                isCubeInPosition.Add(new Vector3(child.localPosition.x, child.localPosition.y, child.localPosition.z));
                if (child.GetComponent<Cube>().isFinishCube)
                {
                    isfinishCubeInPosition.Add(child.localPosition);
                }

                if (child.localPosition.y < _lowestPositionY)
                    _lowestPositionY = child.localPosition.y;
            }
            else if(child.tag == "Virus")
            {
                isVirusInPosition.Add(child.localPosition);
            }
            else if(child.tag == "Coin")
            {
                //isCoinInPosition.Add(child.localPosition);
                coin.Add(child.localPosition, child);
            }
            else if(child.tag == "Robot")
            {
                NextStep.runRobot = child.GetComponent<RunRobot>();
                runGame.BatyaRobotController = child.GetComponent<RobotController>();
                robot = child.GetComponent<RobotCore>().typeRobot;               
            }
        }
         

        IsGameOver.isfinishCubeInPosition = isfinishCubeInPosition;
        IsGameOver.numberViruses = isVirusInPosition.Count;

        Rangefinder.isCubeInPosition = isCubeInPosition;
        Rangefinder._lowestPositionY = _lowestPositionY;

        CanExecuteCommand.isCubeInPosition = isCubeInPosition;
        CanExecuteCommand._lowestPositionY = _lowestPositionY;

        coinRotationSpeed = coinRotationSpeedInput;

        if (File.Exists(Application.persistentDataPath + "/" + Settings.nameSavedFile))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/" + Settings.nameSavedFile, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            //GameSettings gameSettings = (GameSettings)bf.Deserialize(file);
            PlayerPrefs.SetFloat("speedAnimation", ((GameSettings)bf.Deserialize(file)).speedAnimation);
            file.Close();
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + '/' + Settings.nameSavedFile);

            PlayerPrefs.SetFloat("speedAnimation", new GameSettings().speedAnimation);

            bf.Serialize(file, new GameSettings());
            file.Close();
        }
    }
}
