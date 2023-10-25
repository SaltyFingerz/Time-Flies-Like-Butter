using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//www.youtube.com/watch?v=ZBj3LBA2vUY

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 5f, -10f);
    public float smoothTime = 1f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;



    // OR

  //  public float followSpeed = 2f;

    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
       

        /*
        //OR
        Vector3 newPos = new Vector3(target.position.x, target.position.y +5f, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        */
        
    }


    public void LookLower()
    {
        offset = new Vector3(0f, 0f, -10f);
        smoothTime = 0.5f;
    }

}
