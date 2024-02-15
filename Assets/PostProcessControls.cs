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
