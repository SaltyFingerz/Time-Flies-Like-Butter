using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script made by folliing tutorial:  https://www.youtube.com/watch?v=9dzBrLUIF8g&t=273s on re-creating hollow knight camera behaviour using cinemachine.
//This specific script is for making the camera's pivot towards the direction the player is facing, to be more gradual. 

public class CameraFollowObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform playerTransform;

    [Header("Flip rotation stats")]
    [SerializeField] private float flipRotationTime = 0.5f;

    private Coroutine turnCoroutine;
    private PlayerMovement pMovement;
    private bool isFacingRight;

    // Start is called before the first frame update
    private void Awake()
    {
        pMovement = playerTransform.gameObject.GetComponent<PlayerMovement>();
        isFacingRight = pMovement.isFacingRight;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position;
    }

    public void CallTurn()
    {
        turnCoroutine = StartCoroutine(FlipYLerp());
        print("call Turn");
    }

    private IEnumerator FlipYLerp()
    {
        float startRotation = transform.localEulerAngles.y;
        float endRotationAmount = DetermineEndRotation();
        float yRotation = 0f;

        float elapsedTime = 0f; 
        while (elapsedTime < flipRotationTime) 
        {
            elapsedTime += Time.deltaTime;

            yRotation = Mathf.Lerp(startRotation, endRotationAmount, (elapsedTime / flipRotationTime));
            transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
            yield return null;
        }
        
    }

    private float DetermineEndRotation()
    {
        isFacingRight = !isFacingRight;

        if(isFacingRight)
        {
            return 0f;
        }
        else
        {
            return 180f;
        }
    }
}
