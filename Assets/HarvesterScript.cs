using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvesterScript : MonoBehaviour
{
    [SerializeField] private GameObject Fruit;
  
    public void TakeFruit()
    {
        Fruit.SetActive(false);
    }

    private void Update()
    {
        if(Fruit.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("IdleFruit"))
        {
            StartCoroutine(AttractHarvester());
        }
    }

    IEnumerator AttractHarvester()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<Animator>().SetTrigger("Harvest");
    }
}
