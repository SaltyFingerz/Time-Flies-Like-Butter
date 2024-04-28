using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioSource successSFX;

  

    public static bool inverse;


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

        if(successSFX.isPlaying || SceneManager.GetActiveScene().name == "SwanAndFireFlyLevel")
        {
            m_AudioSource.Stop();
        }
        else if(!m_AudioSource.isPlaying)
        {
            m_AudioSource.Play();
        }
    }
    
    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.volume = 0.3f;
     
    
       
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
      
           
           

            successSFX.Play();
        
          
       
    }

   
 
}
