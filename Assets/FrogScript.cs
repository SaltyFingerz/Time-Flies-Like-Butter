using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private Animator anim;
    bool canEat = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
            Debug.Log("ËAT");
            anim.SetTrigger("Eat");
            
          
        }
    }

    IEnumerator EatCooldown()
    {
        yield return new WaitForSeconds(3);
        canEat = true;
    }
}
