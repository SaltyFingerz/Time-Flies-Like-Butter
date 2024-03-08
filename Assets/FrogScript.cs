using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private Animator anim;
    public bool sleepable = false;
    bool canEat = true;
    private Rigidbody2D rb;
    bool inLight = false;
    [SerializeField] private ParticleSystem sleep;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
       
    }

    public void StopSleep()
    {
      

        var em = sleep.emission;

        em.enabled = false;
        
    }

    public void StartSleep()
    {
        
        var em = sleep.emission;

        em.enabled = true;

    }

    private void Update()
    {
        if(sleepable)
        {
            if (RewindBySlider.isRewindRunning)
            {
                anim.SetBool("Awake", false);

            }

            else if (!RewindBySlider.isRewindRunning && (SingingSwan.loud || inLight))
            {
                anim.SetBool("Awake", true);
            }
            else if(!RewindBySlider.isRewindRunning && !SingingSwan.loud && !inLight)
            { 
                anim.SetBool("Awake", false); 
            }

         

        }
    }

    public void EatingEvent()
    {
        if (canEat)
        {
            Player.SetActive(false);
            canEat = false;
            StartCoroutine(EatCooldown());
            anim.ResetTrigger("Eat");
        }
    }

   
    public void StartEating()
    {
        if (canEat)
        {
            if (sleepable)
            {
                //if (!anim.GetBool("Awake") || StealthScript.inLight)
                if (anim.GetBool("Awake"))
                {
                    anim.SetBool("Gobble", true);
                    StartCoroutine(EatCooldown());
                }
            }

            else
            {
                
                anim.SetTrigger("Eat");

            }
            
          
        }
    }

    public void NoMoreGobble()
    {
        anim.SetBool("Gobble", false);
    }

    IEnumerator EatCooldown()
    {
        yield return new WaitForSeconds(3);
        canEat = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Light"))
        {
            inLight = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            inLight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {

            inLight = false;
        }
    }


}
