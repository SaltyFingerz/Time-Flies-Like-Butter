using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MoveSlider : MonoBehaviour
{
    private Slider slider;
    bool reset = false;
    public PlayerMovement pMovement; 
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.rewind && (pMovement.rewindMode == PlayerMovement.RewindMode.enviroself || pMovement.rewindMode == PlayerMovement.RewindMode.voidtime))
        {
            MoveSliderBack();
            reset = false;
        }
        else
        {
            if (reset == false)
            resetSlider();
           
        }
    }

    //to move the slider back when rewinding by toggle
    public void MoveSliderBack()
    {
        slider.value -= 0.03f * Time.deltaTime;
    }

    public void resetSlider()
    {
        slider.value = 0f;
        reset = true;
    }
}
