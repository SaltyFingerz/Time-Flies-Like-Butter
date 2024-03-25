using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PolaroidScript : MonoBehaviour
{
    AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();   
    }

   public void PlaySound()
    {
        aS.Play();
    }

    public void ContinueButtonPressed()
    {
        SceneManager.LoadScene("LevelSelectMap");
    }
}
