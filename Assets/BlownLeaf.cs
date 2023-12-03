using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlownLeaf : MonoBehaviour
{
    [SerializeField] private GameObject grassHopper;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Hop"))
        {
            if(PlayerMovement.rewind)
            {
                print("HIPPITYHOPPITYNOW");
                grassHopper.GetComponent<Animator>().SetTrigger("ReverseJump");
            }
        }
    }


}
