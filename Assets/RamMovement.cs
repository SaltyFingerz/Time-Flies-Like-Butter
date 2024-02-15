using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamMovement : MonoBehaviour
{
    [SerializeField] private float farLeft = -3f;
    [SerializeField] private float farRight = 18f;
    [SerializeField] private float speed = 1f;
   public bool movingLeft = false;
    public bool movingRight = false;
    public float padding = 3f;
    bool chase = false;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (!chase)
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

        if (movingLeft || movingRight)
        {
            transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
            anim.SetBool("Walking", true);

        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if (movingLeft)
        {
            Quaternion localRotation = transform.localRotation;
            localRotation.y = 180;
            transform.localRotation = localRotation;
        }

        else if (movingRight)
        {
            Quaternion localRotation = transform.localRotation;
            localRotation.y = 0;
            transform.localRotation = localRotation;
        }


       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && collision.GetComponent<PlayerMovement>().lifeStage == PlayerMovement.LifeStage.butterfly)
        {
            chase = true;
            print("CHASE");
            speed = 25;
            if(collision.transform.position.x < (gameObject.transform.position.x - padding))
            {
                movingLeft = true;
                movingRight = false;
            }

            else if(collision.transform.position.x > (gameObject.transform.position.x + padding))
            {
                movingRight = true;
                movingLeft = false;
            }

            else if (collision.transform.position.x < (gameObject.transform.position.x + padding) && collision.transform.position.x > (gameObject.transform.position.x - padding))
            {
                movingLeft = false;
                movingRight = false;
            }
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
