using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour
{
    [SerializeField] private Animator water;
    [SerializeField] private Animator rain;
    [SerializeField] private GameObject rainObj;
    [SerializeField] private GameObject drops;
    public static bool raining = false; 

    void Update()
    {
        if(raining)
        {
            StartCoroutine(StartRaining());
 
        }
        
    }

    IEnumerator StartRaining()
    {
        rainObj.SetActive(true);
        
       
        yield return new WaitForSeconds(2);
        drops.SetActive(true);

        yield return new WaitForSeconds(2);

        water.SetBool("Rise", true);
        rain.SetBool("Rise", true);

    }
}
