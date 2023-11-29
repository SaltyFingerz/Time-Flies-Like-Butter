using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AnimatorSpeedRandomizer : MonoBehaviour
{
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
     
    }



    public void SetRandomSpeed()
    {
        if (anim != null)
        {
            anim.speed = Random.Range(1f, 3f);
       
        }
        
    }

    public void SetRandomWait()
    {
        if (anim != null)
        {
      
            anim.speed = Random.Range(0.01f, 0.05f);
        }
    }
}
