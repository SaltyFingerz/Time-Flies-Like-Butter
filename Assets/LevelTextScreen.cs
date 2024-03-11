using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTextScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

   public void PlayButtonPressed()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
