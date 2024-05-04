using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaseRoadManager : MonoBehaviour
{
    [SerializeField] private GameObject passRoad;
    [SerializeField] private GameObject failRoad;
    // Start is called before the first frame update
    void Awake()
    {
        if(gameObject.name.Contains("Ghost"))
        {
            if(PlayerPrefs.GetInt("Saved") == 1)
            {
                failRoad.SetActive(false);
                passRoad.SetActive(true);   
            }
            else if(PlayerPrefs.GetInt("Saved") == 2)
            {
                failRoad.SetActive(true);
                passRoad.SetActive(false);
            }
            else if(PlayerPrefs.GetInt("Saved") == 3)
            {
                failRoad.SetActive(false);
                passRoad.SetActive(false);
            }

            else if(PlayerPrefs.GetInt("Saved") == 0) 
            {
                failRoad.SetActive(true);
                passRoad.SetActive(true);
            }
        }

        else if(gameObject.name.Contains("Seesaw"))
        {
            if (PlayerPrefs.GetInt("Balanced") == 1)
            {
                failRoad.SetActive(false);
                passRoad.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("Balanced") == 2)
            {
                failRoad.SetActive(true);
                passRoad.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Balanced") == 3)
            {
                failRoad.SetActive(false);
                passRoad.SetActive(false);
            }

            else if (PlayerPrefs.GetInt("Balanced") == 0)
            {
                failRoad.SetActive(true);
                passRoad.SetActive(true);
            }



        }
    }

   
}
