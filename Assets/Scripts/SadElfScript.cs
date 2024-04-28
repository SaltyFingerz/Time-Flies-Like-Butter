using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SadElfScript : MonoBehaviour
{
    Animator anim;
    AudioSource aS;
    [SerializeField] private ParticleSystem tears;
    [SerializeField] private GameObject splash;
    [SerializeField] private GameObject Polaroids;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
        aS = GetComponent<AudioSource>();
        aS.Play();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            anim.SetTrigger("Smile");
        }
    }

 

    IEnumerator StopTearsCoroutine()
    {
        GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlayVictorySound();
        aS.Stop();
        if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("Level"))
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        tears.Stop();
        yield return new WaitForSeconds(1f);
        splash.SetActive(false);
        yield return new WaitForSeconds(1f);
        Polaroids.SetActive(true);
       // SceneManager.LoadScene("LevelSelectMap");


    }
}
