using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadTimedEvent : MonoBehaviour
{
    private Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();   
    }

    IEnumerator loadCollider()
    {
        yield return new WaitForSeconds(2f);
        col.enabled = true;
    }

    // Update is called once per frame
    private void Awake()
    {
        StartCoroutine(loadCollider());
    }
}
