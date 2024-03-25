using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FanLevelManager : MonoBehaviour
{

    [SerializeField] private GameObject Fan;
    [SerializeField] private GameObject Leaf;
    [SerializeField] private GameObject Hopper;
    [SerializeField] private GameObject Love;
    [SerializeField] private GameObject Thoughts;
    AudioSource aS;

    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.rewind)
        {
            Fan.GetComponent<Animator>().SetBool("Start", false);
            Hopper.GetComponent<Animator>().SetBool("Jump", false);
            Hopper.GetComponent<Animator>().SetBool("Hit", false);

            if (Hopper.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("IdleHopperFloor"))
            {
                Thoughts.SetActive(true);
            }
            else
            {
                Thoughts.SetActive(false);
            }

        }

        else
        {
            Hopper.GetComponent<Animator>().ResetTrigger("ReverseJump");
            Thoughts.SetActive(false);

            if (!PlayerManager.closeBlind)
            {
                Hopper.GetComponent<Animator>().SetBool("Jump", true);
            }
            else
            {
                Hopper.GetComponent<Animator>().SetBool("Hit", true);
            }
            
            
        }

        if(PlayerManager.love)
        {
            Hopper.GetComponent<Animator>().SetBool("Blush", true);
            Love.SetActive(true);
            StartCoroutine(waitToLoadLevel());
        }
    }

    IEnumerator waitToLoadLevel()
    {
        if(!aS.isPlaying) 
        aS.Play();
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("LevelSelectMap");
    }

    public void BlowLeaf()
    {
        Leaf.GetComponent<Animator>().SetBool("Blow", true);
    }
}
