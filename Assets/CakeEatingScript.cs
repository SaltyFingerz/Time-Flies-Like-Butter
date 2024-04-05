using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CakeEatingScript : MonoBehaviour
{
    [SerializeField] private GameObject camera;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("Player"))
        {
            camera.GetComponent<Animator>().SetTrigger("Move");
            StartCoroutine(reduceVolume());
            if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("Level"))
            {
                PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
                

            }
            
           // SceneManager.LoadScene("LevelSelectMap");
        }
    }


    IEnumerator reduceVolume()
    {
        float elapsedTime = 0;
        float lerpDuration = 0.5f;
        while ((GameObject.Find("Audio Manager").GetComponent<AudioSource>().volume > 0.01f))
        {

            elapsedTime += Time.deltaTime;
            float lerpPercentage = (elapsedTime / lerpDuration);
            GameObject.Find("Audio Manager").GetComponent<AudioSource>().volume = Mathf.Lerp(0.1f, 0.01f, lerpPercentage);

            yield return null;
        }
    
    }
}
