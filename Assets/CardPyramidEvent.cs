using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPyramidEvent : MonoBehaviour
{
    AudioSource aS;
    public static bool formed = false;
    // Start is called before the first frame update


    private void Start()
    {
        aS = GetComponent<AudioSource>();
    }
    public void PlaySoundCollapse()
    {
        aS.Play();
    }
    public void PyramidFormedEvent()
    {
        if(!PlayerMovement.rewind && !PlayerManager.fanOn)
        {
            formed = true;
        }
    }
}
