using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeAudio : MonoBehaviour
{
    private void Awake()
    {
        GameObject.Find("Audio Manager").GetComponent<AudioSource>().Play();
    }
}
