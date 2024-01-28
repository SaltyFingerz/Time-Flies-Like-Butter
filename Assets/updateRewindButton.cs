using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class updateRewindButton : MonoBehaviour
{
    public Sprite[] buttonSprites;
    private UnityEngine.UI.Button button;
    private int howManyFingersTouching = 0;

    [SerializeField] AudioSource rewindSound;

    public WobbleEffectCam _wobbleEffect;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<UnityEngine.UI.Button>();    
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.rewind)
        {
            button.GetComponent<UnityEngine.UI.Image>().sprite = buttonSprites[1];
            _wobbleEffect.StartWobble();
            rewindSound.Play();

        }
        else
        {
            button.GetComponent<UnityEngine.UI.Image>().sprite = buttonSprites[0];
            _wobbleEffect.StopWobble();
            rewindSound.Stop();
        }

        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        howManyFingersTouching++;

        if (howManyFingersTouching == 1)
            OnButtonDown();
    }

    public void OnButtonDown()
    {
        if (button.interactable)
        {
           
           
            _wobbleEffect.StartWobble();
            rewindSound.Play();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        howManyFingersTouching--;

        if (howManyFingersTouching == 0)
            OnButtonUp();
    }

    public void OnButtonUp()
    {
        if (button.interactable)
        {
           
            _wobbleEffect.StopWobble();
            rewindSound.Stop();
        }
    }



}
