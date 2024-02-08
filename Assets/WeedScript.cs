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
    }
    // Start is called before the first frame update
    public void KillFlower()
    {
        flowerVictim.GetComponent<Animator>().SetBool("Dying", true);
    }

    public void NotKillingFlower()
    {
        flowerVictim.GetComponent<Animator>().SetBool("Dying", true);
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
