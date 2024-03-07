using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindButtonAppearance : MonoBehaviour
{
    [SerializeField] private GameObject rewindButton;
    private PlayerMovement pMovement;
    // Start is called before the first frame update

    private void Start()
    {
       pMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    public void showButton()
    {
        rewindButton.SetActive(true);
        GameObject.Find("Player").GetComponent<PlayerMovement>().rewindMode = PlayerMovement.RewindMode.environment;
    }

    public void showSlider()
    {
      

        
        pMovement.SetRewindPlayer();

    }
}
