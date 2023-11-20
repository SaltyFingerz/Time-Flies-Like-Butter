using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateRewindButton : MonoBehaviour
{
    private Transform rewindText;
    private Transform forwardText;
    // Start is called before the first frame update
    void Start()
    {
        rewindText = this.gameObject.transform.GetChild(0);
        forwardText = this.gameObject.transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.rewind)
        {
            forwardText.gameObject.SetActive(true);
            rewindText.gameObject.SetActive(false);
        }
        else
        {
            forwardText.gameObject.SetActive(false);
            rewindText.gameObject.SetActive(true);
        }
    }
}
