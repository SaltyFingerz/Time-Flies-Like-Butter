using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
///  Example how to rewind time with key press
/// </summary>
public class RewindByKeyPress : MonoBehaviour
{
    bool isRewinding = false;
    [SerializeField] float rewindIntensity = 0.02f;          //Variable to change rewind speed
    [SerializeField] AudioSource rewindSound;
    float rewindValue = 0;

    PlayerInputActions inputActions;
    private PlayerInput input;
    bool canToggle;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();
    }

    private void Update()
    {
        if (inputActions.Player.Rewind.ReadValue<float>() > 0 && canToggle)
        {
            PlayerMovement.rewind = !PlayerMovement.rewind;
            canToggle = false;
        }

        if (inputActions.Player.Rewind.ReadValue<float>() == 0)
        {
            canToggle = true;
        }
    }
    void FixedUpdate()
    {
        if(PlayerMovement.rewind)                     //Change keycode for your own custom key if you want
        {
            rewindValue += rewindIntensity;                 //While holding the button, we will gradually rewind more and more time into the past

            if (!isRewinding)
            {
                RewindManager.Instance.StartRewindTimeBySeconds(rewindValue);
                rewindSound.Play();
            }
            else
            {
                if(RewindManager.Instance.HowManySecondsAvailableForRewind>rewindValue)      //Safety check so it is not grabbing values out of the bounds
                    RewindManager.Instance.SetTimeSecondsInRewind(rewindValue);
            }
            isRewinding = true;
        }
        else
        {
            if(isRewinding)
            {
                RewindManager.Instance.StopRewindTimeBySeconds();
                rewindSound.Stop();
                rewindValue = 0;
                isRewinding = false;
            }
        }
    }
}
