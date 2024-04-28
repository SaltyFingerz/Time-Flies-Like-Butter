using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedScript : MonoBehaviour
{
    [SerializeField] private GameObject flowerVictim;
    private Animator anim;
   private bool eaten = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.ResetTrigger("Eaten");
    }

    private void Update()
    {
        if(flowerVictim.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("IdleLivingFlower") && PlayerMovement.rewind)
        {
            StartCoroutine(ShrinkWeed());
        }

        else if( !PlayerMovement.rewind)
        {
            StartCoroutine(GrowWeed());

        }
    }

    IEnumerator ShrinkWeed()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("Grow", false);
        anim.SetBool("Rewind", true);
    }

    IEnumerator GrowWeed()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("Grow", true);
        anim.SetBool("Rewind", false);
    }

    // Start is called before the first frame update
    public void KillFlower()
    {
        flowerVictim.GetComponent<Animator>().SetBool("Dying", true);
    }

    public void NotKillingFlower()
    {
        flowerVictim.GetComponent<Animator>().SetBool("Dying", false);
    }

    public void EatenEvent()
    {
        anim.SetTrigger("Eaten");
        eaten = true;

    }

    public bool Eaten()
    {
        return eaten;
    }
}
