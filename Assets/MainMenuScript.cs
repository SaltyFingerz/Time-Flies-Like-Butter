using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{

    public void NewGameButtonPressed()
    {
        PlayerPrefs.SetInt("Level", 0);
        SceneManager.LoadScene("LevelSelectMap");
    }

    public void LoadGameButtonPressed()
    {
        SceneManager.LoadScene("LevelSelectMap");
    }
}
