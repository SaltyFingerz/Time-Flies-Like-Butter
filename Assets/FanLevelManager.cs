using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanLevelManager : MonoBehaviour
{

    [SerializeField] private GameObject Fan;
    [SerializeField] private GameObject Leaf;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlowLeaf()
    {
        Leaf.GetComponent<Animator>().SetBool("Blow", true);
    }
}
