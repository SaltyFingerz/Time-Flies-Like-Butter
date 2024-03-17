using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SadElfScript : MonoBehaviour
{
    Animator anim;
    [SerializeField] private ParticleSystem tears;
    [SerializeField] private GameObject splash;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
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
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex + 1);
        tears.Stop();
        yield return new WaitForSeconds(1f);
        splash.SetActive(false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
