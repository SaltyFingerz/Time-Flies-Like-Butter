using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StamenScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator anim;
    
    [SerializeField] private Transform destination;
    [SerializeField] private Animator animDestStamen;
    private Collider2D triggerPortal;
    void Start()
    {
        anim = GetComponent<Animator>();
        triggerPortal = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerManager.openRed && gameObject.name.Contains("Red"))
        {
            
                anim.SetBool("Portal", true);
           
        }

        if(PlayerManager.openBlue && gameObject.name.Contains("Blue"))
        {
            anim.SetBool("Portal", true);
        }

       
    }


    public void OpenPortalEvent()
    {
        

            triggerPortal.enabled = true;
       

     
        

    }

    public Transform GetDestination()
    {
        print("destination yo");

        return destination;
       
    }

    public void OpenDestination()
    {
        animDestStamen.SetTrigger("Open");
    }    

    public void LoadNextLevel()
    {
        if (triggerPortal.enabled)
        {
            print("GOOOOO");
            SceneManager.LoadScene("DemoScene");
        }

    }


}
