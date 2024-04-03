using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddingManager : MonoBehaviour
{
    [SerializeField] private GameObject FacesObject;
    [SerializeField] private GameObject Polaroids;

    public void StartConversation()
    {
        FacesObject.GetComponent<Animator>().SetTrigger("Talk");
    }

    public void PlayPolaroids()
    {
        Polaroids.SetActive(true);
    }
}
