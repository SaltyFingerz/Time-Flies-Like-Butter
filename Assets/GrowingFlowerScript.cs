using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingFlowerScript : MonoBehaviour
{
    private AudioSource aS;
    Animator anim;
    void Start()
    {
        aS = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (PlayerMovement.rewind)
        {
            anim.SetBool("Rewind", true);
        }
        else
        {
            anim.SetBool("Rewind", false);
        }
    }
    public void playSound()
    {
        aS.Play();
    }

    
}
