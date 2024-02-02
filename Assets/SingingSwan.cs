using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingingSwan : MonoBehaviour
{
    [SerializeField] private ParticleSystem notes;
    private AudioSource audio;


    public AudioSource audioSource;
    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;

    private float currentUpdateTime = 0f;

    private float clipLoudness;
    private float[] clipSampleData;
    public static bool loud = false;

  

    // Use this for initialization
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        // ac = GetComponent<AudioClip>(); 
        audio.Play();
        

        if (!audioSource)
        {
            Debug.LogError(GetType() + ".Awake: there was no audioSource set.");
        }
        clipSampleData = new float[sampleDataLength];

    }

    // Update is called once per frame
    void Update()
    {
        

        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for
        }

        if(clipLoudness <0.0009f)
        {
            loud = false;
          
           var em = notes.emission;
        
            em.enabled = false;



        }
        else
        {
            loud = true;
            
            var em = notes.emission;
            em.enabled = true;
            notes.Play(true);
        }


    }



    //  private AudioClip ac; 

    // Start is called before the first frame update
  
}
