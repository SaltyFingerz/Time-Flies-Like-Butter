using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddingManager : MonoBehaviour
{
    [SerializeField] private GameObject FacesObject;

    public void StartConversation()
    {
        FacesObject.GetComponent<Animator>().SetTrigger("Talk");
    }
}
