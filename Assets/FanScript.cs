using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{
    [SerializeField] private AudioSource aSButton;


    public void PlayButtonSFX()
    {
        aSButton.Play();
    }
}
