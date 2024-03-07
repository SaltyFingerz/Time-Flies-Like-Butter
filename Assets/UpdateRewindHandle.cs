using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateRewindHandle : MonoBehaviour
{
    private Vector3 direction = new Vector3(0, 0, 50);


    private void Update()
    {
        if(RewindBySlider.isRewindRunning)
            gameObject.transform.Rotate(5 * direction * Time.deltaTime); 
        else
        transform.rotation = Quaternion.identity;   


    }

}
