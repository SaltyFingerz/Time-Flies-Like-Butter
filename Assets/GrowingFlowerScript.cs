using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingFlowerScript : MonoBehaviour
{
    private AudioSource aS;
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    public void playSound()
    {
        aS.Play();
    }

    
}
