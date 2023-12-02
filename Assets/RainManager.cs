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
    public GameObject[] splashes;
  

    IEnumerator StartRaining()
    {
        rainObj.SetActive(true);

        for (int i = 0; i < rainDrops.Length; i++)
        {
            rainDrops[i].GetComponent<RainDrops>().StartDropping();
        }


        yield return new WaitForSeconds(1);
      
        for (int i = 0; i < splashes.Length; i++)
        {
            splashes[i].GetComponent<Animator>().SetBool("Splash", true);
        }

        yield return new WaitForSeconds(2);

        water.SetBool("Rise", true);
       // rain.SetBool("Rise", true);

    }

    public void RainNow()
    {
      
        StartCoroutine(StartRaining());
    }

    public void CancelRain()
    {
        water.SetBool("Rise", false);

        for (int i = 0; i < splashes.Length; i++)
        {
            splashes[i].GetComponent<Animator>().SetBool("Splash", false);
        }

        for (int i = 0; i < rainDrops.Length; i++)
        {
            rainDrops[i].GetComponent<RainDrops>().StartDropping();
        }

        rainObj.GetComponent<DeactivateRain>().StopRain();
    }
}
