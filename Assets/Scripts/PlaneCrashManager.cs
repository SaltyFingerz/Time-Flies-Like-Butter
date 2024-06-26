using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using EZCameraShake;
using UnityEngine.SceneManagement;

public class PlaneCrashManager : MonoBehaviour
{
    [SerializeField] private Animator BangAnim;
    [SerializeField] private Animator SmokeAnim;
    [SerializeField] private GameObject SmokeRight;
    [SerializeField] private GameObject FireRight;

    [SerializeField] private GameObject SmokeLeft;
    [SerializeField] private GameObject FireLeft;
    [SerializeField] private Camera cam;

    [SerializeField] private AudioSource fireSFX;
    [SerializeField] private AudioClip bangSFX;
    [SerializeField] private AudioSource aS;

    [SerializeField] private GameObject polaroids;
    [SerializeField] private AudioClip Evasion;

    public CustomCameraShaker camShake;
    // Start is called before the first frame update


    private void Update()
    {
        if (RewindBySlider.isRewindRunning)
        {
            SmokeRight.SetActive(false);
            SmokeLeft.SetActive(false);
            FireRight.SetActive(false);
            FireLeft.SetActive(false);
        }
        else
        {
            SmokeRight.SetActive(true);
            SmokeLeft.SetActive(true);
            FireRight.SetActive(true);
            FireLeft.SetActive(true);
        }
    }



    public void PlayEvasion()
    {
        aS.PlayOneShot(Evasion);
    }

    public void PlayCrash()
    {
        aS.PlayOneShot(bangSFX);
    }

    public void PlayImpactEffect()
    {
        StartCoroutine(camShake.Shake(0.15f,0.4f));
        BangAnim.SetTrigger("Play");
        SmokeAnim.SetTrigger("Play");
        SmokeRight.GetComponent<VisualEffect>().Play();
        FireRight.GetComponent<VisualEffect>().Play();

        SmokeLeft.GetComponent<VisualEffect>().Play();
        FireLeft.GetComponent<VisualEffect>().Play();
        fireSFX.Play();
      
    }

    public void LevelComplete()
    {
        print("GhostTrafficControllerLevelComplete!");
    }

    public void ShakeCam()
    {
        StartCoroutine(camShake.Shake(0.15f, 0.4f));
        // CameraShaker.Instance.ShakeOnce(4, 3, 1, 1);
      
    }

    public void LoadNextScene()
    {
        StartCoroutine(WaitToLoadNextScene());
    }

    IEnumerator WaitToLoadNextScene()
    {

        GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlayVictorySound();

        if (PlayerPrefs.GetInt("Saved") == 1)
        {
            PlayerPrefs.SetInt("Saved", 3);
        }
        else
        {
            PlayerPrefs.SetInt("Saved", 2);
        }
        yield return new WaitForSeconds(2);
        polaroids.SetActive(true);

    }



    public void ReloadLevel()
    {
        if (PlayerPrefs.GetInt("Saved") == 2)
        {
            PlayerPrefs.SetInt("Saved", 3);
        }
        else
        {
            PlayerPrefs.SetInt("Saved", 1);
        }
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("LevelSelectMap");
        
    }

    

}
