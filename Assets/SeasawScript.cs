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
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            RamThirsty.transform.position = new Vector3(-6.5f, -7.72f, 0.05f);
            RamHungry.transform.position = new Vector3(49.3f, 25.3f, 0.05f);
            RamHungry.transform.rotation = new Quaternion(0, 0, 0, 0);
            print("transform position");
        }
      
    }

 
}
