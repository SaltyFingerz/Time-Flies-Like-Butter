using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindButtonAppearance : MonoBehaviour
{
    [SerializeField] private GameObject rewindButton;
    // Start is called before the first frame update
    public void showButton()
    {
        rewindButton.SetActive(true);
        GameObject.Find("Player").GetComponent<PlayerMovement>().rewindMode = PlayerMovement.RewindMode.environment;
    }
}
