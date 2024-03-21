using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenScript : MonoBehaviour
{
    public void AllowCakeEating()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void PreventCakeEating()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
