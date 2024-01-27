using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[Serializable, VolumeComponentMenuForRenderPipeline("Custom/Bloom", typeof(UniversalRenderPipeline))]
public class CustomBloomEffectComponent : VolumeComponent, IPostProcessComponent
{

    [Header("Bloom Settings")]
    public FloatParameter threshold = new FloatParameter(0.9f, true);

    public FloatParameter intensity = new FloatParameter(1, true);

    public ClampedFloatParameter scatter = new ClampedFloatParameter(0.7f, 0, 1, true);

    public IntParameter clamp = new IntParameter(65472, true);

    public ClampedIntParameter maxInteractions = new ClampedIntParameter(6, 0, 10);

    public NoInterpColorParameter tint = new NoInterpColorParameter(Color.white);

    public bool IsActive()
    {
        return true;
    }

    public bool IsTileCompatible()
    {
        return false;
    }


}
