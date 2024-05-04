using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSelectMapScript : MonoBehaviour
{ 
    public void ButtonPressed(Button ThisButton)
    {
      SceneManager.LoadScene(ThisButton.gameObject.name);
    }
}
