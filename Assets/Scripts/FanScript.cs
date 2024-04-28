using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{
    [SerializeField] private AudioSource aSButton;
    [SerializeField] private AudioSource aSFan;
    bool on = false;

    private void Update()
    {
        if (on)
        {
            if(!aSFan.isPlaying)
            {
                aSFan.Play();
            }
        }
        else
        {
            if(aSFan.isPlaying)
            {
                aSFan.Stop();
            }    
        }


    }

    //Abinmation Events:
    public void PlayButtonSFX()
    {
        aSButton.Play();
    }

    public void FanOn()
    {
        on = true;
    }

    public void FanOff()
    {
        on = false;
    }
}
