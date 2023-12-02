using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateRain : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Deactivate());

    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }

}
