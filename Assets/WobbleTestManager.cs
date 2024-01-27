using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WobbleTestManager : MonoBehaviour
{
    public WobbleEffectCam _wobbleEffect;
    private Keyboard _keyboard;
    // Start is called before the first frame update
    void Start()
    {
        _keyboard = Keyboard.current;
    }

    // Update is called once per frame
    void Update()
    {
        if(_keyboard.aKey.wasPressedThisFrame)
        {
            WobbleOn();
        }
        else if(_keyboard.bKey.wasPressedThisFrame)
        {
            WobbleOff();
        }
    }

    private void WobbleOn()
    {
        //_wobbleEffect.enabled = true;
        _wobbleEffect.StartWobble();
    }

    private void WobbleOff()
    {
        _wobbleEffect.StopWobble();
    }
}
