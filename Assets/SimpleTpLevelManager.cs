using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTpLevelManager : MonoBehaviour
{
    [SerializeField] private GameObject FirstPortal;
    [SerializeField] private GameObject PollenBubble; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FirstPortal.GetComponent<StamenScript>().portalState == StamenScript.PortalState.closed)
        {
            PollenBubble.SetActive(true);   
        }
        else
        {
            PollenBubble.SetActive(false);
        }
        
    }
}
