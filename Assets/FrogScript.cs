using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }



    public void EatingEvent()
    {
        Player.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void StartEating()
    {
        anim.SetTrigger("Eat");
    }
}
