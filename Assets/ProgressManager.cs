using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Level;



    private void Awake()
    {
        for (int i = 12; i >PlayerPrefs.GetInt("Level"); i--)
        {
            Level[i].SetActive(false);
        }
        

    }
}
