using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthScript : MonoBehaviour
{
    public static bool inLight = false;
   
    // Start is called before the first frame update
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Light"))
        {
            inLight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Light"))
        {
            inLight = false;
        }
    }


}
