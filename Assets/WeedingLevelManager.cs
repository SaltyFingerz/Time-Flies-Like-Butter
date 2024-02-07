using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedingLevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] flowers;
    // Start is called before the first frame update
  
    public void RewindFlowers()
    {
        StartCoroutine(reviveFlowers());
       
    }

    public void ForwardFlowers()
    {
        StartCoroutine (forwardFlowers());
    }

    IEnumerator reviveFlowers()
    {
        for (int i = 0; i < flowers.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            flowers[i].GetComponent<Animator>().SetBool("Rewind", true);
            yield return new WaitForSeconds(1);
            yield return null;
        }
    }

    IEnumerator forwardFlowers()

    {
        for (int i = 0; i < flowers.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            flowers[i].GetComponent<Animator>().SetBool("Rewind", false);
            yield return new WaitForSeconds(1);
            yield return null;
        }
    }
}
