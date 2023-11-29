using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEvents : MonoBehaviour
{
    [SerializeField] private GameObject player;
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
           player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Rigidbody2D>().gravityScale = 10;
        }

        if(collision.CompareTag("Rain"))
        {
            print("RAIN");
            RainManager.raining = true;
        }
    }
}
