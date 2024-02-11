using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBoardingLevel : MonoBehaviour
{
    [SerializeField] private GameObject Branch;
  

    public void FallBranch()
    {
        Branch.GetComponent<Animator>().SetBool("Fall", true);
        Branch.GetComponent<Animator>().SetBool("Rewind", false);
    }

    public void RewindBranch()
    {
        Branch.GetComponent<Animator>().SetBool("Rewind", true);
        Branch.GetComponent<Animator>().SetBool("Fall", false);

    }
}
