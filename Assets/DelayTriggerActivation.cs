using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayTriggerActivation : MonoBehaviour
{
    private Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void Awake()
    {
        col.enabled = false;
        StartCoroutine(WaitToActivate());
    }


    IEnumerator WaitToActivate()
    {
        yield return new WaitForSeconds(1);
        col.enabled = true;

    }

  
}
