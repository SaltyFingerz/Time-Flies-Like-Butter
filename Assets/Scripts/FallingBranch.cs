using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBranch : MonoBehaviour
{
    AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

   public void PlayFallSFX()
    {
        aS.Play();
    }
}
