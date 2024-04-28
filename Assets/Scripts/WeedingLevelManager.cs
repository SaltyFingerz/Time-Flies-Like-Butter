using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeedingLevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] flowers;
    [SerializeField] private GameObject[] weeds;
   
    // Start is called before the first frame update
  

    IEnumerator WinState()
    {
        
       
            yield return new WaitForSeconds(1);
            print("WIN");
        
           
       
    }

    private void Update()
    {

        if (PlayerMovement.rewind)
        {
            RewindFlowers();
            if(SceneManager.GetActiveScene().name == "CloverSandwich")
            {
                GameObject.Find("Player").GetComponent<PlayerMovement>().DisableMorphing();
                GameObject.Find("Player").GetComponent<Animator>().SetBool("Morph", false);
                GameObject.Find("Player").GetComponent<Animator>().SetTrigger("UnMorph");

            }
        }
        else
        {
            ForwardFlowers();
            if (SceneManager.GetActiveScene().name == "CloverSandwich")
            {
                GameObject.Find("Player").GetComponent<Animator>().ResetTrigger("UnMorph");
            }
        }


        if (weeds[0].GetComponent<WeedScript>().Eaten() && weeds[1].GetComponent<WeedScript>().Eaten() && flowers[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("IdleLivingFlower") && flowers[1].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("IdleLivingFlower") && !PlayerMovement.rewind)
        StartCoroutine(WinState());
    }

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