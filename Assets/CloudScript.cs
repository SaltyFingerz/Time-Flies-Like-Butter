using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    private void Update()
    {
        transform.Translate((new Vector3(0, 2, 0) * Time.deltaTime));
    }
}
