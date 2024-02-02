using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private Animator anim;
    public bool sleepable = false;
    bool canEat = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
       
    }

    private void Update()
    {
        if(sleepable)
        { if (SingingSwan.loud)
            {
                anim.SetBool("Awake", true);
            }
            else 
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
        }
    }

   
    public void StartEating()
    {
        if (canEat)
        {
            if (sleepable)
            {
                if (!anim.GetBool("Awake") || StealthScript.inLight)
                    anim.SetBool("Gobble", true);
                StartCoroutine(EatCooldown());
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
}
