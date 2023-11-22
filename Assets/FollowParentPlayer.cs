using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParentPlayer : MonoBehaviour
{
    [SerializeField] GameObject parent;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (parent != null && parent.GetComponent<SpriteRenderer>().enabled)
        {
            transform.position = parent.transform.position;
        }
    }
}
