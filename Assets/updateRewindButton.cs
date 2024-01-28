using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateRewindButton : MonoBehaviour
{
    public Sprite[] buttonSprites;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();    
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.rewind)
        {
            button.GetComponent<Image>().sprite = buttonSprites[1];
            
        }
        else
        {
            button.GetComponent<Image>().sprite = buttonSprites[0];
        }
    }
}
