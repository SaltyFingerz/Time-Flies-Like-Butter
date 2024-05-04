using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToPlayer : MonoBehaviour
{

    [SerializeField] private Transform Player;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Player.position;
    }
}
