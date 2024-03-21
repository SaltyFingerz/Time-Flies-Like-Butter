using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclesFlashingScript : MonoBehaviour
{
    bool disappear = true;
    public static bool on = false;

    void Update()
    {
        CheckState();
        if (on)
        {

            if (disappear)
            {
                foreach (Transform child in transform)
                {

                    child.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -1f) * Time.deltaTime;
                }
            }
            else
            {
                foreach (Transform child in transform)
                {

                    child.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 1f) * Time.deltaTime;
                   
                }
            }
        }
        
    }

    public void CheckState()
    {
        if (gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color.a >= 0.9f)
        {
            disappear = true;
           
           
        }
        else if(gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color.a <= 0.1f)
        {
           
            disappear = false;
        }
    }

}
