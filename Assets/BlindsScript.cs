using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindsScript : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
     anim = GetComponent<Animator>();
        anim.SetBool("Close", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerManager.closeBlind)
        { anim.SetBool("Close", true); }
    }
}
