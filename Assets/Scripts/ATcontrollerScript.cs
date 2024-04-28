using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATcontrollerScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem sleep;
    AudioSource aS;
    [SerializeField] private AudioClip snoring;
    [SerializeField] private AudioClip ghasp;
    bool canGasp = true;

    private void Start()
    {
        aS = GetComponent<AudioSource>();
   
    }

    // Start is called before the first frame update
    public void StopSleep()
    {
        sleep.Stop();
        if (canGasp)
        {
            aS.loop = false;
            aS.PlayOneShot(ghasp);
            canGasp = false;
        }

    }

    public void Snore()
    {
        aS.loop=true;
        aS.PlayOneShot(snoring);
    }
}
