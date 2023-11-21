using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private RuntimeAnimatorController redAC;
    [SerializeField] private RuntimeAnimatorController blueAC;

    public static bool openRed = false;
    public static bool openBlue = false;

    private GameObject currentPortal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else if (collision.gameObject.name.Contains("BlueFlower") && gameObject.GetComponent<Animator>().runtimeAnimatorController != blueAC)
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

        if (collision.gameObject.name.Contains("StamenRed"))
        {
            currentPortal = collision.gameObject;

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
            print("not null");
            transform.position = currentPortal.GetComponent<StamenScript>().GetDestination().position;
            currentPortal.GetComponent<StamenScript>().OpenDestination();
        }
    }

   

}
