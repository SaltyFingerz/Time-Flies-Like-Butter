using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToCamera : MonoBehaviour
{
    [SerializeField] private GameObject mainCam;
 

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = mainCam.transform.position;
        gameObject.GetComponent<Camera>().orthographicSize = mainCam.GetComponent<Camera>().orthographicSize;
    }
}
