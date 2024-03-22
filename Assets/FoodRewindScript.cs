using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRewindScript : MonoBehaviour
{
    private void Update()
    {

        if (PlayerMovement.rewind && GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("OnGroundIdle"))
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<Animator>().SetTrigger("ReAppear");

        }

        else if (!PlayerMovement.rewind && GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Reapper"))
        {
            GetComponent<Animator>().SetTrigger("Drop");
        }

     


    }

    public void HasAppearedTrue()
    {
        GetComponent<Animator>().SetBool("HasAppeared", true);
    }

}
