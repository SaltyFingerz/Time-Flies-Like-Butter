using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLevelScript : MonoBehaviour
{
    [SerializeField] private GameObject cards;
    private Animator anim;
    public GameObject obsElf;
    // Start is called before the first frame update
    void Start()
    {
        anim = cards.GetComponent<Animator>();
        obsElf = GameObject.Find("ObsElf");
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(PlayerMovement.rewind)
        {
            Rewind();
        }
        else
        {
            Forward();
        }

        if(CardPyramidEvent.formed)
        {
            ShockElf();
        }
       
    }

    public void FanOn()
    {
        anim.SetBool("Fan", true);
    }

    public void FanOff()
    {
        anim.SetBool("Fan", false);
    }

    public void Rewind()
    {
        anim.SetBool("Rewind", true);
    }

    public void Forward()
    {
        anim.SetBool("Rewind", false);
    }

    public void ShockElf()
    {
        obsElf.GetComponent<Animator>().SetTrigger("Formed");
    }
}
