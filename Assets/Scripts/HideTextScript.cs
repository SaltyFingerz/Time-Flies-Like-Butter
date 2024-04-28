using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTextScript : MonoBehaviour
{

    [SerializeField] private GameObject leadObj;

    void Update()
    {
        if(!leadObj.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}
