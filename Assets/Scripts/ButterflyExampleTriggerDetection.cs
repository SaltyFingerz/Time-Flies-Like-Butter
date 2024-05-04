using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyExampleTriggerDetection : MonoBehaviour
{
    [SerializeField] private ExampleButterfly butterScript;
    private bool hasPlayed = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !hasPlayed && collision.GetComponent<PlayerMovement>().lifeStage == PlayerMovement.LifeStage.butterfly)
        {
            butterScript.StartPollination();
            hasPlayed = true;
        }
    }
}
