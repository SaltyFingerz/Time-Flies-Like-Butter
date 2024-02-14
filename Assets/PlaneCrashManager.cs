using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCrashManager : MonoBehaviour
{
    [SerializeField] private Animator BangAnim;
    [SerializeField] private Animator SmokeAnim;
    // Start is called before the first frame update
 
    public void PlayImpactEffect()
    {
        BangAnim.SetTrigger("Play");
        SmokeAnim.SetTrigger("Play");
    }


}
