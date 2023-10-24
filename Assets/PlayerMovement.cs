using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //www.youtube.com/watch?v=K1xZ-rycYY8&t=42s

    private float horizontal;
    private float vertical;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool canMorph = false;

    public LeafScript leaf;

    [SerializeField] private AudioSource aS;
    [SerializeField] private AudioClip morphSound;
    [SerializeField] private AudioClip burstSound;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public enum LifeStage {caterpillar = 0, butterfly = 1, dead = 2};
    public LifeStage lifeStage = LifeStage.caterpillar;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        StateCheck();


            Flip();

       
    }

    void StateCheck()
    {
        switch (lifeStage)
        {
            case LifeStage.caterpillar:

                if (Input.GetButtonDown("Jump") && isGrounded())
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                }

                if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
                {
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                }

                if (Input.GetKeyDown(KeyCode.Q))

                {
                    Debug.Log("MorphingTime");
                    canMorph = true;
                    Metamorphosis();

                }

                if (rb.velocity.x != 0 && isGrounded())
                {
                    anim.SetBool("Walking", true);
                }
                else
                {
                    anim.SetBool("Walking", false);
                }

                break;

            case LifeStage.butterfly:

                rb.gravityScale = 0f;

                /*if (rb.velocity.x != 0 || rb.velocity.y != 0)
                {
                    //anim flying.
                }
                else
                {
                    anim.SetBool("Walking", false);
                }*/

                break;

            case LifeStage.dead:
             
                break;

            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        if (lifeStage == LifeStage.caterpillar)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        if(lifeStage== LifeStage.butterfly)
        {
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void Metamorphosis()
    {
        if (canMorph)
        {
            anim.SetBool("Morph", true);
            aS.PlayOneShot(morphSound);
        }
    }

    public void BurstEvent()
    {
        aS.PlayOneShot(burstSound);
    }    

    public void MorphEvent()
    {
        lifeStage = LifeStage.butterfly;
      

    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) 
        { 
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("TriggerLeaf1"))
        {
            leaf.DropLeaf();
        }
    }

}
