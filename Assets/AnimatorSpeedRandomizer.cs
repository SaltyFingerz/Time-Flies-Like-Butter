using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AnimatorSpeedRandomizer : MonoBehaviour
{
    private Animator anim;
    private AnimatorStateTransition animState; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        animState = GetComponent<AnimatorStateTransition>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.speed = Random.Range(0.1f, 2f);
        animState.exitTime = Random.Range(0, 5);
    }
}
