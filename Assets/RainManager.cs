using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour
{
    [SerializeField] private Animator water;
    //[SerializeField] private Animator rain;
    [SerializeField] private GameObject rainObj;
    [SerializeField] private GameObject drops;

    private bool rain = false;

    public GameObject[] rainDrops; 
  

    IEnumerator StartRaining()
    {
        rainObj.SetActive(true);

        for (int i = 0; i < rainDrops.Length; i++)
        {
            rainDrops[i].GetComponent<RainDrops>().StartDropping();
        }


        yield return new WaitForSeconds(2);
      //  drops.SetActive(true);

        yield return new WaitForSeconds(2);

        water.SetBool("Rise", true);
       // rain.SetBool("Rise", true);

    }

    public void RainNow()
    {
      
        StartCoroutine(StartRaining());
    }
}
