using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasawScript : MonoBehaviour
{
    [SerializeField] private GameObject midpoint;
   public void DownRight()
    {
        midpoint.SetActive(false);
        RamMovement.stand = false;
        RamMovement.chaseRight = true;
       
    }
}
