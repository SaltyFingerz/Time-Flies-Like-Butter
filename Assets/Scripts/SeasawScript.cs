using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeasawScript : MonoBehaviour
{
    [SerializeField] private GameObject midRpoint;
    [SerializeField] private GameObject midLpoint;
    public RamMovement ramMovementHungry;
    public GameObject RamThirsty;
    public GameObject RamHungry;
    public Transform LeftSide;
    public Transform RightSide;
    private float lerpDuration = 1f;
    private float elapsedTime;
    private Vector3 thirstyEndPos = new Vector3(-6.5f, -7.7f, 0.05f);
    private Vector3 hungryEndPos = new Vector3(54f, 21.3f, 0.05f);
    bool LerpNow = false;
    [SerializeField] private AudioSource aS;
    [SerializeField] private AudioSource aS2;
    [SerializeField] private AudioSource aS3;

    private void Awake()
    {
        GetComponent<BoxCollider2D>().enabled = false;
      
    }
    public void DownRight()
    {
        midRpoint.SetActive(false);
        midLpoint.SetActive(true);
        ramMovementHungry.StopStanding();
        RamMovement.chaseRight = true;
       
    }

    public void PlaySeesawSound()
    {
        aS3.Play();
    }

    public void DownLeft()
    {
        midLpoint.SetActive(false);
        midRpoint.SetActive(true);
        if(RamMovement.Goal)
        {
            // LerpNow = true;
            RamMovement.onSeesaw = false;
            StartCoroutine(LerpRamOntoSeasaw(RamHungry, hungryEndPos));
            StartCoroutine(LerpRamOntoSeasaw(RamThirsty, thirstyEndPos));
            GetComponent<BoxCollider2D>().enabled = false;
            aS.Play();
            aS2.Play();
            RamHungry.transform.rotation = new Quaternion(0, 0, 0, 0);
            RamHungry.GetComponent<Animator>().SetTrigger("Consume");
            RamThirsty.GetComponent<Animator>().SetTrigger("Consume");

         
        }
      
    }

    IEnumerator LerpRamOntoSeasaw(GameObject ram, Vector3 endPos)
    {
       
        
            Vector3 startPos = ram.transform.position;
            float elapsedTime = 0;
            float lerpDuration = 0.5f;
            // float lerpPercentage = 0f;

            while (ram.transform.position.y < endPos.y -0.3f || ram.transform.position.y > endPos.y + 0.3f)
            {

                elapsedTime += Time.deltaTime;
                float lerpPercentage = (elapsedTime / lerpDuration);
                ram.transform.position = Vector3.Lerp(startPos, endPos, lerpPercentage);
            RamHungry.transform.rotation = new Quaternion(0, 0, 0, 0);
            yield return null;
            }
       
        RamHungry.transform.rotation = new Quaternion(0, 0, 0, 0);
        GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlayVictorySound();
        if (PlayerPrefs.GetInt("Balanced") ==1)
        {
            PlayerPrefs.SetInt("Balanced", 3);
        }
        else
        {
            PlayerPrefs.SetInt("Balanced", 2);
        }
      //  PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("LevelSelectMap");

    }






}