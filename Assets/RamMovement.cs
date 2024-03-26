using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
   public static bool chase = false;
    public static bool chaseRight = false;
    public static bool chaseLeft = false;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    [SerializeField] private GameObject SeaSaw;
    private bool stand = false;
    public GameObject player;
    bool seasawReady = false;
    public static bool Goal = false;
    public static bool HungryOnRight;
    public GameObject RamHungry;
    public static bool onSeesaw;
    AudioSource aS;
    [SerializeField] private AudioClip walkingOnWood;
    [SerializeField] private GameObject cloudBig;
    [SerializeField] private GameObject cloudSmall;
 
  


    public enum RamState {healthy = 0, hungry = 1, obese = 2};
    public RamState ramState  = RamState.healthy;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        aS = GetComponent<AudioSource>();
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

        if(Input.GetKeyDown(KeyCode.E))
        {
            print(HungryOnRight);
        }

        if(stand)
        {
            //rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            anim.SetBool("Walking", false);
            rb.velocity = new Vector2(0, rb.velocity.y);


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

  

    public void ChaseFunc()
    {
       
        chase = true;
        print("CHASE");
        speed = sprintSpeed;
        if (player.transform.position.x < (gameObject.transform.position.x - padding +2))
        {
            movingLeft = true;
            movingRight = false;
        }

        if (player.transform.position.x < (gameObject.transform.position.x))
        {
            lookingLeft = true;
            lookingRight = false;
        }


        if (player.transform.position.x > (gameObject.transform.position.x + padding -2))
        {
            movingRight = true;
            movingLeft = false;
        }

        if (player.transform.position.x > (gameObject.transform.position.x))
        {
            lookingLeft = false;
            lookingRight = true;
        }

        if (player.transform.position.x < (gameObject.transform.position.x + padding) && player.transform.position.x > (gameObject.transform.position.x - padding))
        {
            movingLeft = false;
            movingRight = false;
        }
    }

    public void ChaseRight()
    {
        if (!aS.isPlaying && onSeesaw && ramState == RamState.hungry)
        {
            aS.PlayOneShot(walkingOnWood);
        }

        chase = true;
        print("CHASE");
        speed = sprintSpeed;
        lookingLeft = false;
        lookingRight = true;
        if (player.transform.position.x > (gameObject.transform.position.x + padding))
        {
            movingRight = true;
            movingLeft = false;
        }

       

        if (player.transform.position.x < (gameObject.transform.position.x + padding) && player.transform.position.x > (gameObject.transform.position.x - padding))
        {
            movingLeft = false;
            movingRight = false;
        }
    }

    public void ChaseLeft()
    {
        if (!aS.isPlaying && onSeesaw && ramState == RamState.hungry)
        {
            aS.PlayOneShot(walkingOnWood);
        }

        chase = true;
        print("CHASE");
        speed = sprintSpeed;
        lookingRight = false;
        lookingLeft = true;

        if (player.transform.position.x < (gameObject.transform.position.x - padding + 2))
        {
            movingLeft = true;
            movingRight = false;
        }

        if (player.transform.position.x < (gameObject.transform.position.x + padding) && player.transform.position.x > (gameObject.transform.position.x - padding))
        {
            movingLeft = false;
            movingRight = false;
        }

    }

    public void StopChaseFunc()
    {
        chase = false;
        movingLeft = false;
        movingRight = false;
        if(aS.isPlaying && onSeesaw) 
        {
            aS.Stop();
        }

    }

    IEnumerator LerpRamOntoSeasaw(Transform endPos)
    {
        if (!Goal && !RewindBySlider.isRewindRunning)
        {
       
            Vector3 startPos = transform.position;
            float elapsedTime = 0;
            float lerpDuration = 0.5f;
            // float lerpPercentage = 0f;

            while ((transform.position.y < endPos.position.y - 0.5f)|| (transform.position.y > endPos.position.y +0.5f))
            {

                elapsedTime += Time.deltaTime;
                float lerpPercentage = (elapsedTime / lerpDuration);
                transform.position = Vector3.Lerp(startPos, endPos.position, lerpPercentage);

                yield return null;
            }
            transform.position = endPos.position;
            onSeesaw = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("LeftSide") && ramState == RamState.hungry)
        {
            print("leftside");
            stand = true;
            movingLeft = false;
            movingRight = false;
            lookingLeft = false;
            lookingRight = true;
            SeaSaw.GetComponent<BoxCollider2D>().enabled = true;
            rb.velocity = new Vector2 (0, 0);

            chaseLeft = false;
            chaseRight = true;
         
         
           // gameObject.transform.position = collision.transform.position;
           StartCoroutine(LerpRamOntoSeasaw(collision.transform));

        }

        if (collision.name.Contains("LeftSide") && ramState == RamState.obese && HungryOnRight)
        {
            print("leftsideobese");
            stand = true;
            movingLeft = false;
            movingRight = false;
            lookingLeft = false;
            lookingRight = true;
           // SeaSaw.GetComponent<BoxCollider2D>().enabled = true;
            rb.velocity = new Vector2(0, 0);

            chaseLeft = false;
            chaseRight = true;


            StartCoroutine(LerpRamOntoSeasaw(collision.transform));

            SeaSaw.GetComponent<Animator>().SetTrigger("LeftDown");
            StartCoroutine(GoalActions());

        }

        else if (collision.name.Contains("RightSide") && ramState == RamState.hungry)
            {
            print("rightside");
                stand = true;
            lookingLeft = true; ;
                lookingRight = false;
             
                rb.velocity = new Vector2(0, 0);
                movingLeft = false;
                movingRight = false;

                chaseRight = false;
                chaseLeft = true;

            StartCoroutine(LerpRamOntoSeasaw(collision.transform));

            HungryOnRight = true;

            }

            else if (collision.name.Contains("MidRightPoint") && ramState == RamState.hungry && !seasawReady && lookingRight)
        {
            SeaSaw.GetComponent<Animator>().SetTrigger("RightDown");
            chaseRight = false;
           
            rb.velocity = new Vector2(0, 0);
            movingLeft = false;
            movingRight = false;
            stand = true;
            print("entermidpoint");

        }

        else if (collision.name.Contains("MidLeftPoint") && ramState == RamState.hungry && lookingLeft)
        {
            print("leftDown");
            SeaSaw.GetComponent<Animator>().SetTrigger("LeftDown");
            chaseRight = false;

            rb.velocity = new Vector2(0, 0);
            movingLeft = false;
            movingRight = false;
            stand = true;
            print("entermidpoint");

        }

        if(collision.name.Contains("EatZone") && ramState == RamState.hungry) 
        {
            anim.SetTrigger("Consume");
            stand = true;
            print("eatzone");

        }

       
    }




    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Contains("LeftSide") && ramState == RamState.hungry)
        {
            stand = false;

        }

        else if (collision.name.Contains("MidRightPoint") && ramState == RamState.hungry && !seasawReady)
        {
            chaseRight = false;

        }

        if (collision.name.Contains("RightSide") && ramState == RamState.hungry)
        {
            HungryOnRight = false;
        }



    }

    public void WalkToRightSide()
    {
        chaseRight = true;
        movingRight = true;
    }

    public void Stand()
    {
        stand = true;
    }

    public void StopStanding()
    {
        stand = false;
    }
    public bool isStanding()
    {
        return stand;
    }

    public void WalkRight()
    {
        stand = false;
        movingRight = true;
    }

    IEnumerator GoalActions()
    {
        stand = true;
        Goal = true;
        RamHungry.GetComponent<RamMovement>().Stand();
       
       




        yield return null;
    }

    public void InstantiateCloudBig()
    {
        Instantiate(cloudBig, transform.position + new Vector3(0, 3, 0), Quaternion.identity);
        cloudBig.GetComponent<SpriteRenderer>().flipX = gameObject.GetComponent<SpriteRenderer>().flipX;

    }

    public void InstantiateCloudSmall()
    {
        Instantiate(cloudSmall, transform.position + new Vector3(0, 3, 0), Quaternion.identity);
        cloudSmall.GetComponent<SpriteRenderer>().flipX = gameObject.GetComponent<SpriteRenderer>().flipX;

    }

}
