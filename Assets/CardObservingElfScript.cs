using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardObservingElfScript : MonoBehaviour
{
    AudioSource aS;

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
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex + 1);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
