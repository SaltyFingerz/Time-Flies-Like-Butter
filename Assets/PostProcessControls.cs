using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessControls : MonoBehaviour
{

    private Volume v;
    private Bloom b;
    private Vignette vg;
    private ColorAdjustments ca;
    public PlayerMovement playerMovement;
    public float increment = 0.3f;
    public float bigIncrement = 30f;
    private float initialVignetteIntensity;
    private float initialSaturation;

    private void Start()
    {
        v = GetComponent<Volume>();
        v.profile.TryGet(out b);
        v.profile.TryGet(out vg);
        v.profile.TryGet(out ca);
        initialVignetteIntensity = vg.intensity.value;
        initialSaturation = ca.saturation.value;

    }

    private void Update()
    {
        if(GameObject.Find("Player").GetComponent<PlayerMovement>().lifeStage != PlayerMovement.LifeStage.dead && GameObject.Find("Player").GetComponent<PlayerMovement>().lifeStage != PlayerMovement.LifeStage.ghostButterfly)
        {
            ResetVignette();
            ResetSaturation();
        }
        
        if(playerMovement.rewindMode == PlayerMovement.RewindMode.voidtime && PlayerMovement.rewind)
        {
            HueShift();
        }
        else
        {
            StopHueShift();
        }
    }

    public void DecreaseSaturation()
    {
        StartCoroutine(GraduallyDecreaseSaturation());
    }

    public void IncreaseVignette()
    {
        StartCoroutine(GraduallyIncreaseVignette());
    }

    public void ResetVignette()
    {
        vg.intensity.value = initialVignetteIntensity;
    }

    public void ResetSaturation()
    {
        ca.saturation.value = initialSaturation;
    }

    public void HueShift()
    {
        if (ca.hueShift.value < 180)
            ca.hueShift.value += Mathf.Cos(Time.deltaTime);
        else
            ca.hueShift.value = -180;
    }

    public void StopHueShift()
    {
        ca.hueShift.value = 0;
    }



    IEnumerator GraduallyIncreaseVignette()
    {
        while (vg.intensity.value <0.38f) 
        {
            vg.intensity.value += increment*Time.deltaTime;
            yield return null;
        }
        vg.intensity.value = 0.38f;

    }

    IEnumerator GraduallyDecreaseSaturation()
    {
        while (ca.saturation.value > -50f)
        {
            ca.saturation.value -= bigIncrement * Time.deltaTime;
            yield return null;
        }
        ca.saturation.value = -50f;
    }
}
