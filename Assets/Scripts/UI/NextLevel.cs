using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    void Start()
    {
        nextLevel = PlayerPrefs.GetString("NextLevel");
        numberOfNextLevels = PlayerPrefs.GetInt("NumberOfNextLevels");

        print(nextLevel.ToString() + " " + numberOfNextLevels);

        if (numberOfNextLevels <= 0) {
            GetComponent<Button>().interactable = false;
            GetComponent<Image>().color += Color.black;
        }
    }
    string nextLevel;
    int numberOfNextLevels;

 
    public void Next()
    {
        PlayerPrefs.SetInt("NumberOfNextLevels", numberOfNextLevels - 1);
        PlayerPrefs.SetString("NextLevel", "Level_" + (int.Parse(nextLevel.Split('_')[1]) + 1).ToString());
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevel);
    }
}
