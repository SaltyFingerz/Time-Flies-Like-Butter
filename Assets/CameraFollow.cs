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
    [SerializeField] private Transform targetRew;
    private Camera cam;

    [SerializeField] private float InitialZoomDistance = 10;

    public Vector3 minValues, maxValues;
  



    // OR

    //  public float followSpeed = 2f;

    private void Start()
    {
        cam = GetComponent<Camera>();
       // cam.orthographicSize = InitialZoomDistance; 
    }
    void Update()
    {
        Vector3 targetPosition = target.position + offset;

        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValues.x, maxValues.x),
            Mathf.Clamp(targetPosition.y, minValues.y, maxValues.y),
            Mathf.Clamp(targetPosition.z, minValues.z, maxValues.z));

        transform.position = Vector3.SmoothDamp(transform.position, boundPosition, ref velocity, smoothTime);

       

        /*
        //OR
        Vector3 newPos = new Vector3(target.position.x, target.position.y +5f, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        */
        
    }

    public void ReduceSmoothTime()
    {
        smoothTime = 0.25f;
    }

    public void RestoreSmoothTime()
    {
        smoothTime = 0.5f;
    }

    public void LookLower()
    {
        offset = new Vector3(0f, -5f, -12f);
        smoothTime = 0.5f;
    }

    public void LookHigher()
    {
        offset = new Vector3(0f, 5f, -12f);
        smoothTime = 0.5f;
    }

    public void GreaterDistance()
    {

        offset = new Vector3(0f, 2f, -10f);
        smoothTime = 0.5f;
        StartCoroutine(ZoomOut());
       
    }

    public void GreaterDistanceWalk()
    {

        offset = new Vector3(0f, 5f, -10f);
        smoothTime = 0.5f;
        StartCoroutine(ZoomOut());

    }

    IEnumerator ZoomOut()
    {
        while (cam.orthographicSize < 12f)
        {
            cam.orthographicSize += 0.1f;
            yield return null;
        }
       
    }

    public void LookAtRewindablePlayer()
    {
        target = targetRew;
    }

}
