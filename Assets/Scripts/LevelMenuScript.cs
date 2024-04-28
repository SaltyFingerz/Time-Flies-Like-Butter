using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuScript : MonoBehaviour
{
    public void LoadSimpleTpLevel()
    {
        SceneManager.LoadScene("SimpleTpLevel");
    }

    public void LoadFanLevel()
    {
        SceneManager.LoadScene("FanLevel");
    }

    public void LoadDemoScene()
    {
        SceneManager.LoadScene("DemoScene");
    }

    public void LoadRisingWaterLevel()
    {
        SceneManager.LoadScene("RisingWaterLevel");
    }

    public void LoadRisingWaterLevel2()
    {
        SceneManager.LoadScene("RisingWaterLevel2");
    }

    public void LoadTeleportLevel()
    {
        SceneManager.LoadScene("TeleportLevel");
    }
}
