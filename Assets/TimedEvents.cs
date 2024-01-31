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
    }
}
