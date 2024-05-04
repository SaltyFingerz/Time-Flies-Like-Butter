using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyMovement : MonoBehaviour
{
    [SerializeField] private float farLeft = -1f;
    [SerializeField] private float farRight = 3f;
    [SerializeField] private float speed = 1f;
    bool movingLeft = false;


    // Update is called once per frame
    void Update()
    {



         if (transform.position.x < farLeft)
        {
            movingLeft = false;

        }



        else if (transform.position.x > farRight)
        {
            movingLeft = true;

        }

        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);

        if (movingLeft)
        {
            Quaternion localRotation = transform.localRotation;
            localRotation.y = 180;
            transform.localRotation = localRotation;
        }

        else
        {
            Quaternion localRotation = transform.localRotation;
            localRotation.y = 0;
            transform.localRotation = localRotation;
        }



    }
}
