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

    public enum PortalState { closed = 0, open = 1};
    public PortalState portalState = PortalState.closed;
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

            portalState = PortalState.open;
           
        }

        if(PlayerManager.openBlue && gameObject.name.Contains("Blue"))
        {
            portalState = PortalState.open;
        }

        PortalStateFunction();
    }
    void PortalStateFunction()
    {
        switch (portalState)
        {
            case PortalState.closed:
                anim.SetBool("Portal", false);

                break;

            case PortalState.open:
                anim.SetBool("Portal", true);


                break;

           

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
            /*
                if (SceneManager.GetActiveScene().name == "TeleportLevel")
                {
                    SceneManager.LoadScene("RisingWaterLevel");
                }

                else if (SceneManager.GetActiveScene().name == "RisingWaterLevel")
                {
                    SceneManager.LoadScene("RisingWaterLevel2");
                }
            */

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

    }


}
