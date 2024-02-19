using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private Vector3 thirstyEndPos = new Vector3(-6.5f, -7.72f, 0.05f);
    private Vector3 hungryEndPos = new Vector3(49.3f, 25.3f, 0.05f);
    bool LerpNow = false;
    public void DownRight()
    {
        midRpoint.SetActive(false);
        midLpoint.SetActive(true);
        ramMovementHungry.StopStanding();
        RamMovement.chaseRight = true;
       
    }

    public void DownLeft()
    {
        midLpoint.SetActive(false);
        midRpoint.SetActive(true);
        if(RamMovement.Goal)
        {
            // LerpNow = true;

            StartCoroutine(LerpRamOntoSeasaw(RamHungry, hungryEndPos));
            StartCoroutine(LerpRamOntoSeasaw(RamThirsty, thirstyEndPos));
            GetComponent<BoxCollider2D>().enabled = false;
           
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

            while (transform.position != endPos)
            {

                elapsedTime += Time.deltaTime;
                float lerpPercentage = (elapsedTime / lerpDuration);
                ram.transform.position = Vector3.Lerp(startPos, endPos, lerpPercentage);

                yield return null;
            }
        
    }

    private void Update()
    {
        if(LerpNow)
        {
            print("lerp");
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / lerpDuration;
            RamHungry.transform.position = Vector3.Lerp(RightSide.position, hungryEndPos, percentageComplete);
            RamThirsty.transform.position = Vector3.Lerp(LeftSide.position, thirstyEndPos, percentageComplete);


        }
    }


}
