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
            if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("Level"))
            {
                PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
                

            }
            
           // SceneManager.LoadScene("LevelSelectMap");
        }
    }
}
