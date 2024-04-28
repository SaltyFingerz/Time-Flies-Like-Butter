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
        if(collision.name.Contains("Cube") || collision.name.Contains("Player"))
        {
            anim.SetBool("Pressed", true);
            CirclesFlashingScript.on = true;
            oven.GetComponent<Animator>().SetBool("Open", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Contains("Cube") || collision.name.Contains("Player"))
        {
            oven.GetComponent<Animator>().SetBool("Open", false);
            anim.SetBool("Pressed", false);
            CirclesFlashingScript.on = false;
        }
    }

    public void CAKE()
    {
        oven.GetComponent<Animator>().SetBool("Bake", true);
    }
}
