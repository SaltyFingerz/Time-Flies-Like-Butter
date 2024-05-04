using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitingFlowerScript : MonoBehaviour
{
    private AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }
    public void PlayGrowingSound()
    {
        aS.Play();
    }
}
