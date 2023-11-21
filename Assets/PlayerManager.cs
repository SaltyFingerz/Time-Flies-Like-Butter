using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private RuntimeAnimatorController redAC;

    public static bool openRed = false;

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
    }

    
}
