using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleButterfly : MonoBehaviour
{
    [SerializeField] private GameObject gamets;
    [SerializeField] private GameObject stamen;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
     anim = GetComponent<Animator>();   
    }
    public void StartPollination()
    {
        anim.SetTrigger("Pollinate");
    }

    public void AcquirePollenEvent()
    {
        gamets.GetComponent<Animator>().SetTrigger("Jiggle");
        anim.ResetTrigger("Pollinate");
    }
    public void PollinateFlowerEvent()
    {

        stamen.GetComponent<Animator>().SetBool("Pollinated", true);
    }

 
}
