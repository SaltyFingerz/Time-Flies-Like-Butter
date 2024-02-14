using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlaneCrashManager : MonoBehaviour
{
    [SerializeField] private Animator BangAnim;
    [SerializeField] private Animator SmokeAnim;
    [SerializeField] private GameObject SmokeRight;
    [SerializeField] private GameObject FireRight;

    [SerializeField] private GameObject SmokeLeft;
    [SerializeField] private GameObject FireLeft;
    // Start is called before the first frame update

    public void PlayImpactEffect()
    {
        BangAnim.SetTrigger("Play");
        SmokeAnim.SetTrigger("Play");
        SmokeRight.GetComponent<VisualEffect>().Play();
        FireRight.GetComponent<VisualEffect>().Play();

        SmokeLeft.GetComponent<VisualEffect>().Play();
        FireLeft.GetComponent<VisualEffect>().Play();
    }

    

}
