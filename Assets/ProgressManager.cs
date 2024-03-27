using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Level;
    [SerializeField] private GameObject[] extras;

    private void Awake()
    {
        for (int i = 13; i >PlayerPrefs.GetInt("Level"); i--)
        {
            Level[i].SetActive(false);
        }
        
        if(PlayerPrefs.GetInt("Saved") == 1) //checks if tha planes crashed.
        {
            extras[0].SetActive(true);
        }
        else if(PlayerPrefs.GetInt("Saved") == 2) //checks if plane crash prevented.
        {
            extras[1].SetActive(true);
        }
        else if(PlayerPrefs.GetInt("Saved") == 3) // checks if plane has crashed and been saved previously. 
        {
            extras[0].SetActive(true);
            extras[1].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Saved") == 0)
        {
            extras[0].SetActive(false);
            extras[1].SetActive(false);
        }

        if(PlayerPrefs.GetInt("Balanced") == 1)//checks if rams are not saved.
        {
            extras[2].SetActive(true);
            extras[3].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Balanced") == 2) // checks if rams have been saved
        {
            extras[4].SetActive(true);
        }
        else if(PlayerPrefs.GetInt("Balanced") == 3) // checks if rams have both died and been saved before
        {
            extras[2].SetActive(true);
            extras[3].SetActive(true);
            extras[4].SetActive(true);
        }
        else if(PlayerPrefs.GetInt("Balanced") == 0)
        {
            extras[2].SetActive(false);
            extras[3].SetActive(false);
            extras[4].SetActive(false);
        }

    }
}
