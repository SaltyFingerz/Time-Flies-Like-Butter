using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{

    public void NewGameButtonPressed()
    {
        PlayerPrefs.SetInt("Level", 0);
        PlayerPrefs.SetInt("Saved", 0);
        PlayerPrefs.SetInt("Balanced", 0);
        SceneManager.LoadScene("Onboarding");

    }

    public void LoadGameButtonPressed()
    {
        SceneManager.LoadScene("LevelSelectMap");
    }
}
