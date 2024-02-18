using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasawScript : MonoBehaviour
{
    [SerializeField] private GameObject midRpoint;
    [SerializeField] private GameObject midLpoint;
   public void DownRight()
    {
        midRpoint.SetActive(false);
        midLpoint.SetActive(true);
        RamMovement.stand = false;
        RamMovement.chaseRight = true;
       
    }

    public void DownLeft()
    {
        midLpoint.SetActive(false);
        midRpoint.SetActive(true);
      
    }
}
