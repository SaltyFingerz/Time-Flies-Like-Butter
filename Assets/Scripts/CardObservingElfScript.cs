using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardObservingElfScript : MonoBehaviour
{
    AudioSource aS;
    [SerializeField] private GameObject ClosingCanvas;


    private void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        aS.Play();
    }
    public void LoadNextScene()
    {
        StartCoroutine(WaitToLoadNextScene());
    }

    IEnumerator WaitToLoadNextScene()
    {
        GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlayVictorySound();
        if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("Level"))
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        yield return new WaitForSeconds(2);
        if(GameObject.Find("Audio Manager") != null)
            GameObject.Find("Audio Manager").GetComponent<AudioSource>().Stop();
        ClosingCanvas.SetActive(true);
      //  SceneManager.LoadScene("LevelSelectMap");

    }
}
