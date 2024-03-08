using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitingFlowerWeed : MonoBehaviour
{
    [SerializeField] private GameObject Weed;
    [SerializeField] private GameObject Flower;
  

    // Update is called once per frame
    void Update()
    {
        if(Weed.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("IdleFinal") && !PlayerMovement.rewind)
        {
            Flower.SetActive(true);
            gameObject.SetActive(false);
        }
        
    }
}
