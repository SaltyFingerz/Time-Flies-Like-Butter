using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanLevelManager : MonoBehaviour
{

    [SerializeField] private GameObject Fan;
    [SerializeField] private GameObject Leaf;
    [SerializeField] private GameObject Hopper;
    [SerializeField] private GameObject Love;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.rewind)
        {
            Fan.GetComponent<Animator>().SetBool("Start", false);
            Hopper.GetComponent<Animator>().SetBool("Jump", false);
            Hopper.GetComponent<Animator>().SetBool("Hit", false);

        }

        else
        {
            Hopper.GetComponent<Animator>().ResetTrigger("ReverseJump");

            if (!PlayerManager.closeBlind)
            {
                Hopper.GetComponent<Animator>().SetBool("Jump", true);
            }
            else
            {
                Hopper.GetComponent<Animator>().SetBool("Hit", true);
            }
            
            
        }

        if(PlayerManager.love)
        {
            Hopper.GetComponent<Animator>().SetBool("Blush", true);
            Love.SetActive(true);   
        }
    }

    public void BlowLeaf()
    {
        Leaf.GetComponent<Animator>().SetBool("Blow", true);
    }
}
