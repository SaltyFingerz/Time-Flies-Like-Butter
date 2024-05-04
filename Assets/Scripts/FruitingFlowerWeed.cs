using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitingFlowerWeed : MonoBehaviour
{
    [SerializeField] private GameObject Weed;
    [SerializeField] private GameObject Flower;
    [SerializeField] private GameObject Food;
    // Update is called once per frame
    void Update()
    {
        if(Weed.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("IdleFinal") && !PlayerMovement.rewind)
        {
            Flower.SetActive(true);
            gameObject.SetActive(false);
        }
        

    }

    public void SpawnPowerup()
    {
        if (!PlayerMovement.rewind && Weed.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("EatenWeed"))
        {
           
            Food.GetComponent<Animator>().SetBool("Appear", true);


        }

        else if (PlayerMovement.rewind)
        {
            Food.SetActive(true);
        }
    }
}
