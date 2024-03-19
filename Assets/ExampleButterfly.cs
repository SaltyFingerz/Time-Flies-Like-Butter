using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleButterfly : MonoBehaviour
{
    [SerializeField] private GameObject gamets;
    [SerializeField] private GameObject stamen;
    private AudioSource aS;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
     anim = GetComponent<Animator>();   
        aS = GetComponent<AudioSource>();
    }
    public void StartPollination()
    {
        anim.SetTrigger("Pollinate");
    }

    public void AcquirePollenEvent()
    {
        aS.Play();
        gamets.GetComponent<Animator>().SetTrigger("Jiggle");
        anim.ResetTrigger("Pollinate");
    }
    public void PollinateFlowerEvent()
    {

        stamen.GetComponent<Animator>().SetBool("Pollinated", true);
    }

 
}
