using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastForwarder : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 3;
            }
            else if(Time.timeScale == 3)
                {
                    Time.timeScale = 1;
                }
            
        }
    }
}
