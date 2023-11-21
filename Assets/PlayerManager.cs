using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private RuntimeAnimatorController redAC;

    public static bool openRed = false;

    private GameObject currentPortal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else if (collision.gameObject.name.Contains("BlueFlower"))
        {
            gameObject.GetComponent<Animator>().runtimeAnimatorController = redAC;
        }

        else if (collision.gameObject.name.Contains("RedFlower") && gameObject.GetComponent<Animator>().runtimeAnimatorController == redAC)
        {
            openRed = true;
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
