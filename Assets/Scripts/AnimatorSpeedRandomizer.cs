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
            anim.speed = Random.Range(1f, 10f);
            print("random speed");
        }
        else print("not randomizing");
        
    }

    public void SetRandomWait()
    {
        if (anim != null && randomize)
        {
      
            anim.speed = Random.Range(0.01f, 20f);
            print("random wait");
        }

        else print("not randomizing");
    }
}