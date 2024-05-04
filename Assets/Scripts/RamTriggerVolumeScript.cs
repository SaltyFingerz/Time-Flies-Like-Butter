using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamTriggerVolumeScript : MonoBehaviour
{
    public RamMovement ramMovement;
    public GameObject Ram;


    private void Update()
    {
        transform.position = Ram.transform.position;
        transform.rotation = Ram.transform.rotation;
    }



    // Update is called once per frame

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetComponent<PlayerMovement>().lifeStage == PlayerMovement.LifeStage.butterfly && !ramMovement.isStanding() && ramMovement.ramState == RamMovement.RamState.hungry)
        {
            print("to follow");
           ramMovement.ChaseFunc();
        }

        if (collision.CompareTag("Player") && collision.GetComponent<PlayerMovement>().lifeStage == PlayerMovement.LifeStage.butterfly && RamMovement.chaseRight && ramMovement.ramState == RamMovement.RamState.hungry)
        {
            ramMovement.ChaseRight();
        }

        if (collision.CompareTag("Player") && collision.GetComponent<PlayerMovement>().lifeStage == PlayerMovement.LifeStage.butterfly && RamMovement.chaseLeft && ramMovement.ramState == RamMovement.RamState.hungry)
        {
            ramMovement.ChaseLeft();
        }


        if (collision.CompareTag("Player") && collision.GetComponent<PlayerMovement>().lifeStage == PlayerMovement.LifeStage.butterfly && ramMovement.ramState == RamMovement.RamState.obese && !ramMovement.isStanding() && RamMovement.HungryOnRight)
        {
         //   ramMovement.ChaseRight();
            ramMovement.ChaseFunc();
            print("go right");
        }



    }

   



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ramMovement.StopChaseFunc();
        }
    }

 

}
