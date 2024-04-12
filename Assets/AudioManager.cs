using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource m_AudioSource;

    [SerializeField] private AudioClip music;
    [SerializeField] private AudioClip successSFX;

    public static bool inverse;
    bool won = false;

    private void Update()
    {
        if(inverse)
        {
            m_AudioSource.pitch = -1;
        }
        else
        {
            m_AudioSource.pitch = 1;
        }
    }
    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.volume = 0.15f;
        won = false;
    
        m_AudioSource.clip = music;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayVictorySound()
    {
        if (!won)
        {
            m_AudioSource = GetComponent<AudioSource>();
            m_AudioSource.Stop();
            m_AudioSource.volume = 1;
            m_AudioSource.PlayOneShot(successSFX);
            won = true;
            StartCoroutine(replayMusic());
        }
    }

    IEnumerator replayMusic()
    {
        while (m_AudioSource.isPlaying)
        {
            yield return null;
        }
        m_AudioSource.Play();
        
    }
 
}
