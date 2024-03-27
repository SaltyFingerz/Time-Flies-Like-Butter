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
    [SerializeField] private AudioSource openSound;
    [SerializeField] private AudioSource teleportSound;
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
        if (!openSound.isPlaying)
        {
            openSound.Play();
        }

    }

    public Transform GetDestination()
    {
     
        teleportSound.Play();
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
            if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("Level"))
                PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("LevelSelectMap");

        }

    }


}
