using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDrops : MonoBehaviour
{
    private ParticleSystem pSystem;
   
    // Start is called before the first frame update
    void Start()
    {
        pSystem = GetComponent<ParticleSystem>();
    }



    public void StartDropping()
    {
        
        pSystem.Play();
    }

    public void StopDropping()
    {
        pSystem.Stop(); 
    }    
}
