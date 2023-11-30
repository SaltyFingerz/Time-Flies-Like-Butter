using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSpeedRandomizer : MonoBehaviour
{
    private Animator anim;
    public bool randomize = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
     
    }



    public void SetRandomSpeed()
    {
        if (anim != null && randomize)
        {
            anim.speed = Random.Range(1f, 3f);
       
        }
        
    }

    public void SetRandomWait()
    {
        if (anim != null && randomize)
        {
      
            anim.speed = Random.Range(0.01f, 0.05f);
        }
    }
}
