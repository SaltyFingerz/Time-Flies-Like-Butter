using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class RamMovement : MonoBehaviour
{
    [SerializeField] private float farLeft = -3f;
    [SerializeField] private float farRight = 18f;
    [SerializeField] private float speed = 1f;
    public float sprintSpeed = 15f;
   public bool movingLeft = false;
    private bool lookingLeft = false;
    private bool lookingRight = false;
    public bool movingRight = false;
    public float padding = 3f;
    public bool idleWalking = false;
    bool chase = false;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    [SerializeField] private GameObject SeaSaw;
    private bool stand = false;



    public enum RamState {healthy = 0, hungry = 1, obese = 2};
    public RamState ramState  = RamState.healthy;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

  

    void StateCheck()
    {
        switch (ramState)
        {
            case RamState.healthy:

                anim.SetBool("Hungry", false);
                anim.SetBool("Obese", false);
                break;

            case RamState.hungry:

                anim.SetBool("Hungry", true);
                anim.SetBool("Obese", false);
                break;

            case RamState.obese:

                anim.SetBool("Hungry", false);
                anim.SetBool("Obese", true);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        StateCheck();

        if(stand)
        {
            //rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
           
        }

        if (!chase && idleWalking)
        {
            if (transform.position.x < farLeft)
            {
                movingLeft = false;

            }



            else if (transform.position.x > farRight)
            {
                movingLeft = true;

            }
        }

        if (movingRight)
        {
         // transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
            rb.velocity = new Vector2(speed, rb.velocity.y);
            anim.SetBool("Walking", true);

        }

        else if (movingLeft)
        {
          //  transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
              rb.velocity = new Vector2(-speed, rb.velocity.y);
            anim.SetBool("Walking", true);

        }
        else if(!movingLeft && !movingRight)
        {
            anim.SetBool("Walking", false);
        }

        if (movingLeft || lookingLeft)
        {
            sr.flipX = false;
        }

        else if (movingRight || lookingRight)
        {
           sr.flipX=true;
        }


       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && collision.GetComponent<PlayerMovement>().lifeStage == PlayerMovement.LifeStage.butterfly)
        {
            chase = true;
            print("CHASE");
            speed = sprintSpeed;
            if(collision.transform.position.x < (gameObject.transform.position.x - padding + 2))
            {
                movingLeft = true;
                movingRight = false;
            }

            if (collision.transform.position.x < (gameObject.transform.position.x))
            {
                lookingLeft = true;
                lookingRight = false;
            }


             if(collision.transform.position.x > (gameObject.transform.position.x + padding))
            {
                movingRight = true;
                movingLeft = false;
            }

            if (collision.transform.position.x > (gameObject.transform.position.x))
            {
                lookingLeft = false;
                lookingRight = true;
            }

             if (collision.transform.position.x < (gameObject.transform.position.x + padding) && collision.transform.position.x > (gameObject.transform.position.x - padding))
            {
                movingLeft = false;
                movingRight = false;
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("Side"))
        {
           
            SeaSaw.GetComponent<BoxCollider2D>().enabled = true;
            rb.velocity = new Vector2 (0, 0);
            movingLeft = false;
            movingRight=false;
            stand = true;
            lookingRight = true;
            gameObject.transform.position = collision.transform.position;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            chase = false;
        }
    }



}
