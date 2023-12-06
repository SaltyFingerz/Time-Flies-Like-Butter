using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{

    public PlayerMovement pMovement;
    [SerializeField] private GameObject deathOfAge;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if(pMovement.lifeStage == PlayerMovement.LifeStage.butterfly)
        {
            deathOfAge.SetActive(true);
        }

        else
        {
            deathOfAge.SetActive(false);
        }
    }
}
