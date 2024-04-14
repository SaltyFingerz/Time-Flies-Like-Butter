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
    [SerializeField] private GameObject Pollen;
    private ParticleSystem PollenPS;
    private Animator anim;
    private Color PollenPScolor;

    [SerializeField] private AudioSource aS4;
    [SerializeField] private AudioClip[] pollenSneezes;
    private AudioClip pollenSneeze;

    [SerializeField] private AudioClip splash;
    [SerializeField] private AudioClip acEating; 

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
        if(Pollen != null)
        PollenPS = Pollen.GetComponent<ParticleSystem>();
      

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
                    Pollen.SetActive(true);
                    PollenPScolor = new Color(100, 0, 0, 100);

                }
                else if(gameObject.GetComponent<PlayerMovement>().lifeStage == PlayerMovement.LifeStage.butterfly)
                {
                    //  gameObject.GetComponent<Animator>().runtimeAnimatorController = redButterflyAC;
                    gameObject.GetComponent<Animator>().SetTrigger("RedFly");
                    Pollen.SetActive(true);

                }
                break;

            case PollenColor.Blue:
                Pollen.SetActive(true);
                PollenPScolor = new Color(0, 127, 255, 255);
                break;
        }

    }

    public void RedCatterpillar()
    {
        gameObject.GetComponent<Animator>().runtimeAnimatorController = redAC;
    }

    IEnumerator splashThenReload()
    {
        aS4.PlayOneShot(splash);
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            PlayerMovement.rewind = false;
            GameObject.Find("Main Camera").GetComponent<WobbleEffectCam>().StopWobble();
            StartCoroutine(splashThenReload()); 
          
        }

        if(collision.gameObject.name.Contains("AirTraffickController"))
        {
            collision.GetComponent<Animator>().SetBool("Alert", true);
        }

        else if (collision.gameObject.name.Contains("RedGamet") && gameObject.GetComponent<Animator>().runtimeAnimatorController != blueAC && gameObject.GetComponent<PlayerMovement>().lifeStage == PlayerMovement.LifeStage.caterpillar)
        {
            if (!aS4.isPlaying)
            {
                int index = Random.Range(0, pollenSneezes.Length);
                pollenSneeze = pollenSneezes[index];
                aS4.PlayOneShot(pollenSneeze);
            }
            Pollen.SetActive(true);
            PollenPScolor = new Color(100, 0, 0, 100);

            if (collision.GetComponent<Animator>() != null)
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

            PollenState();

            var main = PollenPS.main;
            main.startColor = PollenPScolor;
        }

        else if (collision.gameObject.name.Contains("RedGamet") && gameObject.GetComponent<Animator>().runtimeAnimatorController != blueAC && gameObject.GetComponent<PlayerMovement>().lifeStage == PlayerMovement.LifeStage.butterfly)

        {

            if (!aS4.isPlaying)
            {
                int index = Random.Range(0, pollenSneezes.Length);
                pollenSneeze = pollenSneezes[index];
                aS4.PlayOneShot(pollenSneeze);
            }
            Pollen.SetActive(true);
            PollenPScolor = new Color(100, 0, 0, 100);
            if (collision.GetComponent<Animator>() != null)
            {
                collision.GetComponent<Animator>().SetTrigger("Jiggle");
            }
            // gameObject.GetComponent<Animator>().runtimeAnimatorController = redButterflyAC;
            gameObject.GetComponent<Animator>().SetTrigger("RedFly");
            pollenColor = PollenColor.Red;

            PollenState();

            var main = PollenPS.main;
            main.startColor = PollenPScolor;
        }
        else if (collision.gameObject.name.Contains("BlueGamet") && gameObject.GetComponent<PlayerMovement>().lifeStage == PlayerMovement.LifeStage.caterpillar)
        {
            Pollen.SetActive(true);
            PollenPScolor = new Color(0, 127, 255, 255);

            if (!aS4.isPlaying)
            {
                int index = Random.Range(0, pollenSneezes.Length);
                pollenSneeze = pollenSneezes[index];
                aS4.PlayOneShot(pollenSneeze);
                print("SNEEZE");
            }

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

            PollenState();

            var main = PollenPS.main;
            main.startColor = PollenPScolor;
        }

        else if (collision.gameObject.name.Contains("RedFlower") && (gameObject.GetComponent<Animator>().runtimeAnimatorController == redAC || pollenColor == PollenColor.Red))
        {
            openRed = true;
        }

        else if (collision.gameObject.name.Contains("RedFFruit") && (gameObject.GetComponent<Animator>().runtimeAnimatorController == redAC || pollenColor == PollenColor.Red) && !PlayerMovement.rewind)
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Pollinated", true);
        }

        else if (collision.gameObject.name.Contains("BlueFlower") && gameObject.GetComponent<Animator>().runtimeAnimatorController == blueAC)
        {
            openBlue = true;
        }

        if (collision.gameObject.name.Contains("StamenRed") || collision.gameObject.name.Contains("StamenBlue"))
        {
            

                if (collision.gameObject.CompareTag("Goal"))
                {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(WaitToLoad());
                   

                }

                if (!collision.gameObject.CompareTag("Goal"))
                {
                    transform.position = collision.gameObject.GetComponent<StamenScript>().GetDestination().position;
                    collision.gameObject.GetComponent<StamenScript>().OpenDestination();
                }
            


        }

        IEnumerator WaitToLoad()
        {
            GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlayVictorySound();
            yield return new WaitForSeconds(1);
            collision.gameObject.GetComponent<StamenScript>().LoadNextLevel();
        }

        if (collision.gameObject.name.Contains("Fan") && !fanOn)
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Start", true);
            if (SceneManager.GetActiveScene().name == "FanLevel")
                levelScript.GetComponent<FanLevelManager>().BlowLeaf();
            else if (SceneManager.GetActiveScene().name == "CardsLevel")
                levelScript.GetComponent<CardLevelScript>().FanOn();
            fanOn = true;
            collision.GetComponent<FanScript>().PlayButtonSFX();
        }

        else if (collision.gameObject.name.Contains("Fan") && fanOn)
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Start", false);
            //   if (SceneManager.GetActiveScene().name == "FanLevel")
            //    levelScript.GetComponent<FanLevelManager>().BlowLeaf();
            if (SceneManager.GetActiveScene().name == "CardsLevel")
                levelScript.GetComponent<CardLevelScript>().FanOff();
            fanOn = false;
            collision.GetComponent<FanScript>().PlayButtonSFX();
        }

        if (collision.gameObject.name.Contains("BlindsHandle"))
        {
            closeBlind = true;
        }

        if (collision.gameObject.name.Contains("Grasshopper") && !PlayerMovement.rewind)
        {
            love = true;
        }

        if(collision.gameObject.name.Contains("Fire"))
        {
            anim.SetTrigger("Die");
        }

        if ((SceneManager.GetActiveScene().name == "WeedingLevel" || SceneManager.GetActiveScene().name == "CloverSandwich") && GetComponent<PlayerMovement>().lifeStage == PlayerMovement.LifeStage.caterpillar && !PlayerMovement.rewind)
        {
          
            if (collision.gameObject.CompareTag("WeedUp") && !collision.gameObject.GetComponent<WeedScript>().Eaten())
            {
                aS4.PlayOneShot(acEating);
                gameObject.GetComponent<Animator>().SetTrigger("EatUp");
                currentWeed = collision.gameObject;
                eating = true;
            }

            else if (collision.gameObject.CompareTag("WeedDown") && !collision.gameObject.GetComponent<WeedScript>().Eaten())
            {
                aS4.PlayOneShot(acEating);
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

        if ((SceneManager.GetActiveScene().name == "WeedingLevel" || SceneManager.GetActiveScene().name == "CloverSandwich") && GetComponent<PlayerMovement>().lifeStage == PlayerMovement.LifeStage.caterpillar && !PlayerMovement.rewind)
        {
            print("weed collision");
            if (collision.gameObject.CompareTag("WeedUp") && !collision.gameObject.GetComponent<WeedScript>().Eaten() && eating)
            {
                gameObject.transform.position = collision.gameObject.transform.position - new Vector3(2, 0.6f, 0);
                gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            }

           


            else if (collision.gameObject.CompareTag("WeedDown") && !collision.gameObject.GetComponent<WeedScript>().Eaten() && eating )
            {
                gameObject.transform.position = collision.gameObject.transform.position - new Vector3(2, 0.6f, 0);
                gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            }

            else if (collision.gameObject.name.Contains("Weed") && collision.gameObject.GetComponent<WeedScript>().Eaten())
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

   

   

}
