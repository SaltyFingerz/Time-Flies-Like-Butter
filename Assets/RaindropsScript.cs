using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaindropsScript : MonoBehaviour
{
    [SerializeField] private AudioClip[] droplets;
    [SerializeField] private GameObject rain;
    private AudioSource aS;
    private AudioClip droplet;
    [SerializeField] float interval = 0.2f;


    private void Start()
    {
        aS = GetComponent<AudioSource>();   
    }
    // Update is called once per frame
    void Update()
    {
        if(rain.activeSelf && !aS.isPlaying)
        {
            StartCoroutine(dropletSound()); 
        }
    }

    IEnumerator dropletSound()
    {
        new WaitForSeconds(1f);
        while (rain.activeSelf)
        {
            int index = Random.Range(0, droplets.Length);
            droplet = droplets[index];
            aS.PlayOneShot(droplet);
            yield return new WaitForSeconds(interval);
        }
        yield return null;
    }
}
