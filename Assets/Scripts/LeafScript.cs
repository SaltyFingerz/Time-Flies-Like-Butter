using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
            if(PlayerMovement.rewind)
        {
            anim.SetBool("Forward",  false);
            anim.SetBool("Backward", true);
        }

            else
        {
            anim.SetBool("Forward", true);
            anim.SetBool("Backward", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("Trigger"))
        {
            Destroy(rb);
        }
    }
    public void DropLeaf()
    {if(rb != null)
        rb.WakeUp();
    }
}
