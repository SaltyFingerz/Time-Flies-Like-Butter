using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddingManager : MonoBehaviour
{
    [SerializeField] private GameObject FacesObject;
    [SerializeField] private GameObject Polaroids;
    [SerializeField] private AudioClip puudingQuestion;
    [SerializeField] private AudioClip puddingAnswer1;
    [SerializeField] private AudioClip puddingAnswer2;
    [SerializeField] private AudioClip puddingConclusion;
    AudioSource aS;


    private void Awake()
    {
        aS = GetComponent<AudioSource>();
    }

    public void StartConversation()
    {
        FacesObject.GetComponent<Animator>().SetTrigger("Talk");
    }

    public void PlayPolaroids()
    {
        Polaroids.SetActive(true);
    }

    public void PlayPuddingQuestion()
    {
        aS.pitch = 1f;
        aS.PlayOneShot(puudingQuestion);
    }

    public void PlayPuddingAnswer1()
    {
        aS.pitch = 0.9f;
        aS.PlayOneShot(puddingAnswer1);
    }

    public void PlayPuddingAnswer2()
    {
        aS.pitch = 1.1f;
        aS.PlayOneShot(puddingAnswer2);
    }


    public void PlayPuddingConclusion()
    {
        aS.pitch = 1.05f;
        aS.PlayOneShot(puddingConclusion);
        StartCoroutine(increaseMusicVolume());
    }

    IEnumerator increaseMusicVolume()
    {
        yield return new WaitForSeconds(1);
        GameObject.Find("Audio Manager").GetComponent<AudioSource>().volume = 0.1f;
    }
}
