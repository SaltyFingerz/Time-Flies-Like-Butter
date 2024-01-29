using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    //www.youtube.com/watch?v=K1xZ-rycYY8&t=42s

    private float horizontal;
    private float vertical;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool canMorph = false;
    public static bool rewindable = false;

    private bool hop1 = false;
    private bool hop2 = false;
    private bool hop3 = false;
    private bool hop4 = false;

    private bool prevGrounded = false;

    private PlayerInput input;

    private SpriteRenderer sprite;
    private Collider2D collider;

    public LeafScript leaf;

    public GenericRewind rewindScript;
    public RewindManager rewindManager;
    public CameraFollow cam;
    public FrogScript frog;

    
    //  bool mobile = true;

    [SerializeField] private GameObject rewindChild;


    [SerializeField] private AudioSource aS;
    [SerializeField] private AudioClip morphSound;
    [SerializeField] private AudioClip burstSound;



    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject slerpyLerp;
    [SerializeField] private GameObject HopAnim;
    [SerializeField] private GameObject SlerpEnd;
    [SerializeField] private GameObject SlerpCentre;
    [SerializeField] private GameObject KeyClock;
    [SerializeField] private GameObject SliderRewind;
    [SerializeField] private GameObject RewindButton;
    [SerializeField] private GameObject UpButton;
    [SerializeField] private GameObject DownButton;
    [SerializeField] private GameObject JumpButton;

    public static bool rewind = false;
    bool canToggle;



    Vector2 inputVector = Vector2.zero;
    PlayerInput playerInput;
    PlayerInputActions inputActions;


    public enum LifeStage {caterpillar = 0, butterfly = 1, dead = 2};
    public LifeStage lifeStage = LifeStage.caterpillar;

    public enum RewindMode { environment = 0, enviroself = 1, voidtime = 2, none = 3}
    public RewindMode rewindMode = RewindMode.environment;
    // Start is called before the first frame update

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        input = GetComponent<PlayerInput>();
        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();
        //inputActions.Player.Jump.performed += Jump;
        // inputActions.Player.Rewind.performed += Rewind;

        if (SceneManager.GetActiveScene().name == "TeleportLevel")
        {
            print("rewindenviroself");
            rewindMode = RewindMode.enviroself;


            rewindable = true;

            KeyClock.SetActive(true);
            rewindScript.EnableRewind();



            rewindManager.RestartTracking();

            RewindButton.SetActive(false);
        }

        else if (SceneManager.GetActiveScene().name == "DemoScene")
        {
            SliderRewind.SetActive(false);
            RewindButton.SetActive(true);
        }

        else if (SceneManager.GetActiveScene().name == "RisingWaterLevel" || SceneManager.GetActiveScene().name == "RisingWaterLevel2")
        {
            rewindMode = RewindMode.enviroself;


            rewindable = true;

            KeyClock.SetActive(true);
            rewindScript.EnableRewind();



            rewindManager.RestartTracking();

            RewindButton.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "SimpleTpLevel" || SceneManager.GetActiveScene().name == "FanLevel")
        {
            rewindMode = RewindMode.none;


            rewindable = false;

            KeyClock.SetActive(false);
           



            RewindButton.SetActive(false);
        }

    

    }

   

   /* public void Jump(InputAction.CallbackContext context)
    {
        if (lifeStage == LifeStage.caterpillar)
        {
            if (isGrounded())
            {
                if (context.performed)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                }
               
            }

            if (context.canceled && rb.velocity.y > 0f) //not working why?
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

        }
    } */
    // Update is called once per frame
    void Update()
    {
        /*  if (!mobile)
          {
              horizontal = Input.GetAxisRaw("Horizontal");
              vertical = Input.GetAxisRaw("Vertical");

          }*/


        /*
        if (transform.localScale.x == 1.00001f)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        */

        prevGrounded = isGrounded();

        if(isGrounded() && !prevGrounded)
        {
          //  anim.SetTrigger("Squash");
        }
        
        StateCheck();

        RewindState();

        if (rewind)
        {
            ReverseFlip();
        }
        else
        {
            Flip();
        }

        AdjustCameraSmoothTime();
       
    }



  void AdjustCameraSmoothTime()
    {
        if(rb.velocity.y < -10)
        cam.GetComponent<CameraFollow>().ReduceSmoothTime();
        else
        cam.GetComponent<CameraFollow>().RestoreSmoothTime();
    }

    
    void RewindState()
    {
        switch (rewindMode)
        {
            case RewindMode.environment:
                RewindButton.SetActive(true);
                break;

            case RewindMode.enviroself:
                SliderRewind.SetActive(true);
                RewindButton.SetActive(false);


                break;

            case RewindMode.voidtime:

                RewindButton.SetActive(true);
                KeyClock.SetActive(true);

                break;

            case RewindMode.none:
                RewindButton.SetActive(false);
                SliderRewind.SetActive(false);

                break;

        }
    }


    void StateCheck()
    {
        switch (lifeStage)
        {
            case LifeStage.caterpillar:

                rb.gravityScale = 4f;

                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
                UpButton.SetActive(false);
                DownButton.SetActive(false);

                if (slerpyLerp.activeSelf && inputActions.Player.Jump.ReadValue<float>() > 0 && isGrounded() && rewind)
                {
                    sprite.enabled = false;

                    if(hop1)
                    {
                        HopAnim.GetComponent<SpriteRenderer>().enabled = true;
                        HopAnim.GetComponent<Animator>().SetTrigger("Hop1");
                    }

                    else if(hop2)
                    {
                        HopAnim.GetComponent<SpriteRenderer>().enabled = true;
                        HopAnim.GetComponent<Animator>().SetTrigger("Hop2");

                    }

                    else if (hop3)
                    {
                        HopAnim.GetComponent<SpriteRenderer>().enabled = true;
                        HopAnim.GetComponent<Animator>().SetTrigger("Hop3");

                    }

                    else if (hop4)
                    {
                        HopAnim.GetComponent<SpriteRenderer>().enabled = true;
                        HopAnim.GetComponent<Animator>().SetTrigger("Hop4");
                    }

                }

                

                if (inputActions.Player.Jump.ReadValue<float>() > 0 && isGrounded())
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                    anim.SetTrigger("Stretch");
                }

                if (inputActions.Player.Jump.ReadValue<float>() == 0 && rb.velocity.y > 0f)
                {
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                }

                if (inputActions.Player.Rewind.ReadValue<float>() == 0 && canMorph)

                {
                    Debug.Log("MorphingTime");
                  
                    StartCoroutine(waitToMorph());

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
                rb.velocity = new Vector2(horizontal * speed, vertical * speed);
                UpButton.SetActive(true);
                DownButton.SetActive(true);
                JumpButton.SetActive(false);

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
                print("ded");
            

                rb.gravityScale = 10f;
                rb.velocity = new Vector2(0, rb.velocity.y);
               

                break;

            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        if (lifeStage == LifeStage.caterpillar)
        {
            
        }
        if(lifeStage== LifeStage.butterfly)
        {
           
        }
        if(lifeStage == LifeStage.dead)
        {
            

        }

        inputVector = inputActions.Player.Move.ReadValue<Vector2>();
        horizontal = SimpleInput.GetAxis("Horizontal");
        vertical = SimpleInput.GetAxis("Vertical");
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    IEnumerator waitToMorph()
    {
        yield return new WaitForSeconds(2);
        if(inputActions.Player.Rewind.ReadValue<float>() == 0)
        Metamorphosis();
    }

    public void Metamorphosis()
    {
        if (canMorph)
        {
            anim.SetBool("Morph", true);
            
            
        }
    }

    public void ButterflyEvent()
    {
        lifeStage = LifeStage.butterfly;
    }

    public void MorphSoundEvent()
    {
        aS.PlayOneShot(morphSound);
        cam.GreaterDistance();

        lifeStage = LifeStage.dead;
        print("beingmorhpstopmovingalready");

    }

    public void DeathEvent()
    {
        lifeStage = LifeStage.dead;
    }

    public void DeadEvent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BeginMorphEvent()
    {
        lifeStage = LifeStage.dead;
        print("beingmorhpstopmovingalready");
    }

    public void BurstEvent()
    {
        aS.PlayOneShot(burstSound);
        
    }    

    public void CaterpillarEvent()
    {
        print("CATERPILLAR EVENT");
        lifeStage = LifeStage.caterpillar;
    }

    public void MorphEvent()
    {
        lifeStage = LifeStage.butterfly;

    }



    private void Flip()
    {
        if(isFacingRight && horizontal < 0f) 
        { 
            isFacingRight = !isFacingRight;
           
            Quaternion localRotation = transform.localRotation;
            localRotation.y = 180;
            transform.localRotation = localRotation;
        }
        else if (!isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;


            Quaternion localRotation = transform.localRotation;
            localRotation.y = 0;
            transform.localRotation = localRotation;
        }
    }

    private void ReverseFlip()
    {
        if (isFacingRight && horizontal < 0f)
        {
            isFacingRight = !isFacingRight;

            Quaternion localRotation = transform.localRotation;
            localRotation.y = 180;
            transform.localRotation = localRotation;
        }
        else if (!isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Quaternion localRotation = transform.localRotation;
            localRotation.y = 0;
            transform.localRotation = localRotation;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("TriggerLeaf1"))
        {
            leaf.DropLeaf();
        }

        if (collision.CompareTag("VoidPowerUp"))
        {
            collision.gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Stop();
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;

            rewindMode = RewindMode.voidtime;

            Debug.Log("voidTimeRewindMode");
           // rewindable = true;
            //rewindScript.EnableRewind();

          //  rewindManager.RestartTracking();

           // KeyClock.SetActive(false);


        }


        else if (collision.CompareTag("PlayerRwPowerUp"))
        {
            collision.gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Stop();
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            rewind = false;

            rewindMode = RewindMode.enviroself;

            rewindable = true;

            KeyClock.SetActive(true);
             rewindScript.EnableRewind();
            
          /*  if (!gameObject.name.Contains("Rewindable"))
            {
                cam.LookAtRewindablePlayer();
                sprite.enabled = false;
                collider.enabled = false;
                rewindChild.GetComponent<SpriteRenderer>().enabled = true;
                rewindChild.GetComponent<Collider2D>().enabled = true;
                
            }*/

            rewindManager.RestartTracking();
            Debug.Log("enviroeself rewind modë");



        }

        else if (collision.CompareTag("Food"))
        {
            collision.gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Stop();
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            canMorph = true;
        }




        else if (collision.name.Contains("Hop") && rewindMode == RewindMode.voidtime)
        {
            if (rewind)
            {
                slerpyLerp.SetActive(true);
              //  slerpyLerp.GetComponent<SlerpySlerp>().ShowTrajectory();
            }




            if (collision.name.Contains("Hop1"))
            {
                hop1 = true;
                SlerpEnd.transform.position = new Vector3(16, 6.4f, 0);
                SlerpCentre.transform.position = new Vector3(15.87f, 5.52f, 0);
            }

            if (collision.name.Contains("Hop2"))
            {
                hop2 = true;
                SlerpEnd.transform.position = new Vector3(16, 6.4f, 0);
                SlerpCentre.transform.position = new Vector3(15.87f, 5.52f, 0);
            }

            else if (collision.name.Contains("Hop3"))
            {
                Debug.Log("Hop3");
                hop3 = true;
                SlerpEnd.transform.position = new Vector3(18.82f, 14.95f, 0);
                SlerpCentre.transform.position = new Vector3(24.69f, 16.72f, 0);

            }

            else if (collision.name.Contains("Hop4"))
            {
                hop4 = true;
                SlerpEnd.transform.position = new Vector3(17.34f, -1.74f, 0);
                SlerpCentre.transform.position = new Vector3(17.47f, -3.4f, 0);
            }
        }

        else if (collision.name.Contains("HighPoint"))
        {
            cam.LookLower();
        }

        else if (collision.name.Contains("EatZone") && lifeStage== LifeStage.caterpillar)
        {
            frog.StartEating();

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name.Contains("Hop") && rewindMode == RewindMode.voidtime)
        {
            if (rewind)
            {
                slerpyLerp.SetActive(true);
              //  if (rb.velocity.x == 0)
                    slerpyLerp.GetComponent<SlerpySlerp>().ShowTrajectory();
              //  else
               //     slerpyLerp.GetComponent<SlerpySlerp>().DestroyDots();
            }

            if (collision.name.Contains("Hop1"))
            {
                hop1 = true;
                SlerpEnd.transform.position = new Vector3(16, 6.4f, 0);
                SlerpCentre.transform.position = new Vector3(15.87f, 5.52f, 0);
            }

            if (collision.name.Contains("Hop2"))
            {
                hop2 = true;
                SlerpEnd.transform.position = new Vector3(16, 6.4f, 0);
                SlerpCentre.transform.position = new Vector3(15.87f, 5.52f, 0);
            }

            else if (collision.name.Contains("Hop3"))
            {
                Debug.Log("Hop3");
                hop3 = true;
                SlerpEnd.transform.position = new Vector3(18.82f, 14.95f, 0);
                SlerpCentre.transform.position = new Vector3(24.69f, 16.72f, 0);

            }

            else if (collision.name.Contains("Hop4"))
            {
                hop4 = true;
                SlerpEnd.transform.position = new Vector3(17.34f, -1.74f, 0);
                SlerpCentre.transform.position = new Vector3(17.47f, -3.4f, 0);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Contains("Hop"))
        {
            slerpyLerp.GetComponent<SlerpySlerp>().DestroyDots();
            slerpyLerp.SetActive(false);
        }

        if (collision.name.Contains("Hop1"))
        {
            hop1 = false;
        }

        if (collision.name.Contains("Hop2"))
        {
            hop2 = false;
        }
    }

}
