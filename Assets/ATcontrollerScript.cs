using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATcontrollerScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem sleep;
    // Start is called before the first frame update
 public void StopSleep()
    {
        sleep.Stop();
    }
}
