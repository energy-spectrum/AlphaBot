using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;

public class Settings : MonoBehaviour
{
    public Text textSpeedAnimation;
    public Slider sliderSpeedAnimation;

    static public string nameSavedFile = "GameSettings.save";
    GameSettings gameSettings;
    private void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/" + nameSavedFile))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/" + nameSavedFile, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            gameSettings = (GameSettings)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            gameSettings = new GameSettings();
        }

        sliderSpeedAnimation.value = gameSettings.speedAnimation;
    }

    public void Save()
    {
        gameSettings.speedAnimation = float.Parse(textSpeedAnimation.text);

        PlayerPrefs.SetFloat("speedAnimation", gameSettings.speedAnimation);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + nameSavedFile);
        bf.Serialize(file, gameSettings);
        file.Close();
    }
}
