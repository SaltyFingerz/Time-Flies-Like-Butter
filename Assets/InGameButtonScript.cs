using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameButtonScript : MonoBehaviour
{
    Animator anim;
    [SerializeField] private GameObject oven;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("Cube"))
        {
            anim.SetTrigger("Press");
            CirclesFlashingScript.on = true;
        }
    }

    public void CAKE()
    {
        oven.GetComponent<Animator>().SetTrigger("Open");
    }
}
