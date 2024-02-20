using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private RuntimeAnimatorController redAC;
    [SerializeField] private RuntimeAnimatorController blueAC;
    [SerializeField] private RuntimeAnimatorController redButterflyAC;
    [SerializeField] private GameObject levelScript;
    private Animator anim;


    public GameObject currentWeed = null;
    public static bool openRed = false;
    public static bool openBlue = false;
    public static bool closeBlind = false;
    public static bool love = false;

    public static bool fanOn = false;

    bool eating = false;

    public bool flexiPollen = false;

    private GameObject currentPortal;

    public enum PollenColor { None = 0, Red =1, Blue = 2 }
    public PollenColor pollenColor = PollenColor.None;

    private void Awake()
    {
        openRed = false;
        openBlue = false;
        anim = GetComponent<Animator>();
    }
    
    private void PollenState()
    {
        switch (pollenColor)
        {
            case PollenColor.None:

               

                break;

            case PollenColor.Red:
                if(gameObject.GetComponent<PlayerMovement>().lifeStage == PlayerMovement.LifeStage.caterpillar)
                {
                    //gameObject.GetComponent<Animator>().runtimeAnimatorController = redAC;
                    gameObject.GetComponent<Animator>().SetTrigger("RedCat");

                }
                else if(gameObject.GetComponent<PlayerMovement>().lifeStage == PlayerMovement.LifeStage.butterfly)
                {
                    //  gameObject.GetComponent<Animator>().runtimeAnimatorController = redButterflyAC;
                    gameObject.GetComponent<Animator>().SetTrigger("RedFly");

                }
                break;

            case PollenColor.Blue:

                break;
        }

    }

    public void RedCatterpillar()
    {
        gameObject.GetComponent<Animator>().runtimeAnimatorController = redAC;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(collision.gameObject.name.Contains("AirTraffickController"))
        {
            collision.GetComponent<Animator>().SetBool("Alert", true);
        }

        else if (collision.gameObject.name.Contains("RedGamet") && gameObject.GetComponent<Animator>().runtimeAnimatorController != blueAC && gameObject.GetComponent<PlayerMovement>().lifeStage == PlayerMovement.LifeStage.caterpillar)
        {
           
            if(collision.GetComponent<Animator>() != null)
            {
                print("wiggle"); 
                collision.GetComponent<Animator>().SetTrigger("Jiggle");
            }

            if (flexiPollen)
                pollenColor = PollenColor.Red;
            else if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("IdleOld") || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("StandOld") || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("StartWalkOld") || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("WalkOld"))
            {
                gameObject.GetComponent<Animator>().runtimeAnimatorController = redAC;
                gameObject.GetComponent<Animator>().SetTrigger("Oldie");


            }
            else if (!flexiPollen)
            {
                gameObject.GetComponent<Animator>().runtimeAnimatorController = redAC;

            }
        }

        else if (collision.gameObject.name.Contains("RedGamet") && gameObject.GetComponent<Animator>().runtimeAnimatorController != blueAC && gameObject.GetComponent<PlayerMovement>().lifeStage == PlayerMovement.LifeStage.butterfly)

        {
            if (collision.GetComponent<Animator>() != null)
            {
                collision.GetComponent<Animator>().SetTrigger("Jiggle");
            }
            // gameObject.GetComponent<Animator>().runtimeAnimatorController = redButterflyAC;
            gameObject.GetComponent<Animator>().SetTrigger("RedFly");
            pollenColor = PollenColor.Red;
        }
        else if (collision.gameObject.name.Contains("BlueGamet") && gameObject.GetComponent<PlayerMovement>().lifeStage == PlayerMovement.LifeStage.caterpillar)
        {
            if (collision.GetComponent<Animator>() != null)
            {
                collision.GetComponent<Animator>().SetTrigger("Jiggle");
            }

            if (flexiPollen)
                pollenColor = PollenColor.Blue;
            else if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("IdleOld") || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("StandOld") || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("StartWalkOld") || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("WalkOld"))
            {
                gameObject.GetComponent<Animator>().runtimeAnimatorController = blueAC;
                gameObject.GetComponent<Animator>().SetTrigger("Oldie");
            }
            else if (!flexiPollen)
            {
                gameObject.GetComponent<Animator>().runtimeAnimatorController = blueAC;

            }
        }

        else if (collision.gameObject.name.Contains("RedFlower") && (gameObject.GetComponent<Animator>().runtimeAnimatorController == redAC || pollenColor == PollenColor.Red))
        {
            openRed = true;
        }

        else if (collision.gameObject.name.Contains("RedFFruit") && (gameObject.GetComponent<Animator>().runtimeAnimatorController == redAC || pollenColor == PollenColor.Red))
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Pollinated", true);
        }

        else if (collision.gameObject.name.Contains("BlueFlower") && gameObject.GetComponent<Animator>().runtimeAnimatorController == blueAC)
        {
            openBlue = true;
        }

        if (collision.gameObject.name.Contains("StamenRed") || collision.gameObject.name.Contains("StamenBlue"))
        {
            currentPortal = collision.gameObject;

        }

        if (collision.gameObject.name.Contains("Fan") && !fanOn)
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Start", true);
            if (SceneManager.GetActiveScene().name == "FanLevel")
                levelScript.GetComponent<FanLevelManager>().BlowLeaf();
            else if (SceneManager.GetActiveScene().name == "CardsLevel")
                levelScript.GetComponent<CardLevelScript>().FanOn();
            fanOn = true;
        }

        else if (collision.gameObject.name.Contains("Fan") && fanOn)
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Start", false);
            //   if (SceneManager.GetActiveScene().name == "FanLevel")
            //    levelScript.GetComponent<FanLevelManager>().BlowLeaf();
            if (SceneManager.GetActiveScene().name == "CardsLevel")
                levelScript.GetComponent<CardLevelScript>().FanOff();
            fanOn = false;
        }

        if (collision.gameObject.name.Contains("Handle"))
        {
            closeBlind = true;
        }

        if (collision.gameObject.name.Contains("Grasshopper") && !PlayerMovement.rewind)
        {
            love = true;
        }

        if (SceneManager.GetActiveScene().name == "WeedingLevel")
        {
            if (collision.gameObject.CompareTag("WeedUp") && !collision.gameObject.GetComponent<WeedScript>().Eaten())
            {
               
                gameObject.GetComponent<Animator>().SetTrigger("EatUp");
                currentWeed = collision.gameObject;
                eating = true;
            }

            else if (collision.gameObject.CompareTag("WeedDown") && !collision.gameObject.GetComponent<WeedScript>().Eaten())
            {

                gameObject.GetComponent<Animator>().SetTrigger("EatDown");
                currentWeed = collision.gameObject;
                eating = true;
            }


        }

        if(SceneManager.GetActiveScene().name == "Onboarding")
        {
            if(collision.gameObject.CompareTag("Branch") && !PlayerMovement.rewind)
            {
                levelScript.GetComponent<OnBoardingLevel>().FallBranch();
            }
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().name == "Onboarding")
        {
            if (collision.gameObject.CompareTag("Branch") && !PlayerMovement.rewind)
            {
                levelScript.GetComponent<OnBoardingLevel>().FallBranch();
            }
        }

        if (SceneManager.GetActiveScene().name == "WeedingLevel")
        {
            if (collision.gameObject.CompareTag("WeedUp") && !collision.gameObject.GetComponent<WeedScript>().Eaten())
            {
                gameObject.transform.position = collision.gameObject.transform.position - new Vector3(2, 0, 0);
                gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            }

           


            else if (collision.gameObject.CompareTag("WeedDown") && !collision.gameObject.GetComponent<WeedScript>().Eaten())
            {
                gameObject.transform.position = collision.gameObject.transform.position - new Vector3(2, 0, 0);
                gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            }

            else if (collision.gameObject.GetComponent<WeedScript>().Eaten())
            {
                currentWeed = null;
                eating = false;
                /* print("pop");
                  gameObject.transform.position = gameObject.transform.position;
                  gameObject.transform.rotation = gameObject.transform.rotation; */
            }

        }
    }


    public void DestroyWeed(GameObject collision)
    {
       currentWeed.GetComponent<Animator>().SetTrigger("Eaten");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("StamenRed"))
        {
            if (collision.gameObject == currentPortal)
            {
                currentPortal = null;
            }
        }

        
    }

    private void Update()
    {
        if (currentPortal != null)
        {

            if(currentPortal.CompareTag("Goal") )
            {
                currentPortal.GetComponent<StamenScript>().LoadNextLevel();
              
            }
            print("not null");
            if (!currentPortal.CompareTag("Goal"))
            {
                transform.position = currentPortal.GetComponent<StamenScript>().GetDestination().position;
                currentPortal.GetComponent<StamenScript>().OpenDestination();
            }
        }

       

        PollenState();

        if(SceneManager.GetActiveScene().name == "WeedingLevel")
        {
           if(PlayerMovement.rewind)
            {
                levelScript.GetComponent<WeedingLevelManager>().RewindFlowers();
            }
           else
            {
                levelScript.GetComponent<WeedingLevelManager>().ForwardFlowers();
            }


        }

        else if (SceneManager.GetActiveScene().name == "Onboarding")
        {
            if(PlayerMovement.rewind)
            {
                levelScript.GetComponent<OnBoardingLevel>().RewindBranch();
            }
            
        }
    }

   

}
