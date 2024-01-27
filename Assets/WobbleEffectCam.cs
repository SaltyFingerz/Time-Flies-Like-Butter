using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WobbleEffectCam : MonoBehaviour
{
    public Material _wobbleEffectMaterial;
    public ScriptableRendererFeature _blitRenderFeature;

    private bool _wobbleActive = false;
    private float _frequency = 4f;
    private float _shift = 0f;
    private float _amplitude = 0f;
    private float _maxAmplitude = 0.05f;
    private float _amplitudeSpeed = 0.025f;
    private float _shiftSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void SetFrequency (float frequency)
    {
        _wobbleEffectMaterial.SetFloat("_frequency", frequency);

    }

    private void SetShift(float shift)
    {
        _wobbleEffectMaterial.SetFloat("_shift", shift);
    }

    private void SetAmplitude(float amplitude)
    {
        _wobbleEffectMaterial.SetFloat("_amplitude",  amplitude);
    }

    public void StartWobble()
    {
        if (!_wobbleActive)
        {
            _wobbleActive = true;
            StartCoroutine(WobbleCoroutine());
        }

    }

    public void StopWobble()
    {
        _wobbleActive = false;
    }

    private IEnumerator WobbleCoroutine()
    {
        SetFrequency(_frequency);
      

        while(_amplitude < _maxAmplitude)
        {
            if (_wobbleActive)
            {
                SetAmplitude(_amplitude);
                SetShift(_shift);

                _amplitude += _amplitudeSpeed * Time.deltaTime;
                _shift += _shiftSpeed * Time.deltaTime;
                _shift %= Mathf.PI * 2f;

                yield return null;
            }
            else
            {
                break;
            }
        }

        if (_wobbleActive)
        {
            _amplitude = _maxAmplitude;

            SetAmplitude(_amplitude);
        }

        
        while(_wobbleActive)
        {
            SetShift(_shift);

            _shift += _shiftSpeed * Time.deltaTime;
            _shift %= Mathf.PI * 2f;

            yield return null;
        }

        while (_amplitude > 0f)
        {
            if (!_wobbleActive)
            {
                SetAmplitude(_amplitude);
                SetShift(_shift);

                _amplitude -= _amplitudeSpeed * Time.deltaTime;
                _shift += _shiftSpeed * Time.deltaTime;
                _shift %= Mathf.PI * 2f;

                yield return null;
            }
            else
            {
                break;
            }

        }

        if (!_wobbleActive)
        {
            _amplitude = 0f;
            _shift = 0f;
            SetAmplitude(_amplitude);
            SetShift(_shift);
        }

        
       // enabled = false;
    }
}
