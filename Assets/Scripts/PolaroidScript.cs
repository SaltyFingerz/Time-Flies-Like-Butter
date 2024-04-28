using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PolaroidScript : MonoBehaviour
{
    AudioSource aS;
    // Start is called before the first frame update
    void Awake()
    {
        aS = GetComponent<AudioSource>();   
    }

   public void PlaySound()
    {
        aS.Play();
    }

    public void ContinueButtonPressed()
    {
        if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("Level"))
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("LevelSelectMap");

    }
}
