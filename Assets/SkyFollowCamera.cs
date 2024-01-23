using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyFollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target; 
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, 0);
    }
}
