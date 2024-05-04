using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{

    public PlayerMovement pMovement;
    [SerializeField] private GameObject death;
    [SerializeField] private GameObject age;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(pMovement.lifeStage == PlayerMovement.LifeStage.butterfly)
        {
            death.SetActive(true);
            age.SetActive(true);
        }

        else
        {
            death.SetActive(false);
            age.SetActive(false);
        }
    }
}
