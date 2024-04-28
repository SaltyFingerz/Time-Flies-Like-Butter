using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButtonScript : MonoBehaviour
{
    public void ExitButtonPressed()
    {
        SceneManager.LoadScene("LevelSelectMap");
    }
   
}
