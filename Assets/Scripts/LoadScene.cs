using UnityEngine;
public class LoadScene : MonoBehaviour
{
    public string nameScene;
    public void Load()
    {      
        print("LOAD PLEASE!!");

        if (!isNotForLevel)
        {
            PlayerPrefs.SetInt("NumberOfNextLevels", transform.parent.childCount - transform.GetSiblingIndex() - 1);
            PlayerPrefs.SetString("NextLevel", "Level_" + (transform.GetSiblingIndex() + 1).ToString());
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
    }

    public bool isNotForLevel;
}
