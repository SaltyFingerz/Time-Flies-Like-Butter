using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private RuntimeAnimatorController redAC;
    [SerializeField] private RuntimeAnimatorController blueAC;
    [SerializeField] private GameObject levelScript;

    public static bool openRed = false;
    public static bool openBlue = false;

    private GameObject currentPortal;

    private void Awake()
    {
        openRed = false;
        openBlue = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else if (collision.gameObject.name.Contains("RedGamet") && gameObject.GetComponent<Animator>().runtimeAnimatorController != blueAC)
        {
            gameObject.GetComponent<Animator>().runtimeAnimatorController = redAC;
        }

        else if (collision.gameObject.name.Contains("GreenFlower"))
        {
            gameObject.GetComponent<Animator>().runtimeAnimatorController = blueAC;
        }

        else if (collision.gameObject.name.Contains("RedFlower") && gameObject.GetComponent<Animator>().runtimeAnimatorController == redAC)
        {
            openRed = true;
        }

        else if(collision.gameObject.name.Contains("BlueFlower") && gameObject.GetComponent<Animator>().runtimeAnimatorController == blueAC)
        {
            openBlue = true;
        }

        if (collision.gameObject.name.Contains("StamenRed") || collision.gameObject.name.Contains("StamenBlue"))
        {
            currentPortal = collision.gameObject;

        }

        if(collision.gameObject.name.Contains("Fan"))
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Start", true);
            levelScript.GetComponent<FanLevelManager>().BlowLeaf();
        }
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
    }

   

}
