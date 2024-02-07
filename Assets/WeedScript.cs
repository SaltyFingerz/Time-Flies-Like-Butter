using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedScript : MonoBehaviour
{
    [SerializeField] private GameObject flowerVictim;
    // Start is called before the first frame update
    public void KillFlower()
    {
        flowerVictim.GetComponent<Animator>().SetBool("Dying", true);
    }

    public void NotKillingFlower()
    {
        flowerVictim.GetComponent<Animator>().SetBool("Dying", true);
    }
}
