using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEvents : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public RainManager rainManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Old"))
        {
            player.GetComponent<Animator>().SetBool("Old", true);
            print("OLD");
        }

        if(collision.CompareTag("Death"))
        {
            print("DEATH");
            player.GetComponent<Animator>().SetBool("Dead", true);
          
        }

        if(collision.CompareTag("Rain"))
        {
            
            rainManager.RainNow();
            //RainManager.raining = true;
        }
        if(collision.CompareTag("Morph") && !RewindBySlider.isRewindRunning)
        {
            player.GetComponent<Animator>().SetBool("Morph", true) ; 
        }

        if(collision.CompareTag("Plane") && !RewindBySlider.isRewindRunning)
        {
            if (!GameObject.Find("AirTraffickController").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Alert"))
            {
                GameObject.Find("PlanesCrashManager").GetComponent<Animator>().SetBool("Crash", true);
                GameObject.Find("PlanesCrashManager").GetComponent<Animator>().SetBool("Evade", false);

            }
            else
            {
                GameObject.Find("PlanesCrashManager").GetComponent<Animator>().SetBool("Crash", false);
                GameObject.Find("PlanesCrashManager").GetComponent<Animator>().SetBool("Evade", true);

            }
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Old"))
        {
            player.GetComponent<Animator>().SetBool("Old", false);
        }

        if (collision.CompareTag("Morph"))
        {
            player.GetComponent<Animator>().SetBool("Morph", false);
        }


        if (collision.CompareTag("Death"))
        {
           
            player.GetComponent<Animator>().SetBool("Dead", false);
            
           
        }

        if (collision.CompareTag("Plane"))
        {
            GameObject.Find("PlanesCrashManager").GetComponent<Animator>().SetBool("Crash", false);
            GameObject.Find("PlanesCrashManager").GetComponent<Animator>().SetBool("Evade", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("PreRain"))
        {
            
            rainManager.CancelRain();
        }

        if (collision.CompareTag("PreMorph"))
        {
            if(player.GetComponent<PlayerMovement>().lifeStage != PlayerMovement.LifeStage.dead)
            player.GetComponent<PlayerMovement>().lifeStage = PlayerMovement.LifeStage.caterpillar;
           // if (player.GetComponent<PlayerManager>().pollenColor == PlayerManager.PollenColor.Red)
          //  {
           //     player.GetComponent<PlayerManager>().RedCatterpillar();
          //  }
        }

        if(collision.CompareTag("Morph") && !RewindBySlider.isRewindRunning)
        {
            player.GetComponent<Animator>().SetBool("Morph", true);
        }
    }
}
