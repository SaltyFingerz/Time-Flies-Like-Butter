using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPyramidEvent : MonoBehaviour
{
    public static bool formed = false;
    // Start is called before the first frame update
 
    

    public void PyramidFormedEvent()
    {
        if(!PlayerMovement.rewind && !PlayerManager.fanOn)
        {
            formed = true;
        }
    }
}
