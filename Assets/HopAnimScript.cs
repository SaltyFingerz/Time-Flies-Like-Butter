using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopAnimScript : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private SpriteRenderer sprite;
    public PlayerMovement pMovement; 
    // Start is called before the first frame update

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void EndHopEvent(int hopNo)
    {
        if (hopNo == 1 || hopNo == 2)
        {
            Player.transform.position = new Vector3(16.3f, 5.7f ,0);
            
        }

        else if (hopNo == 3) 
        {
            Player.transform.position = new Vector3(18.76f, 14.2f, 0);
        }

        else if (hopNo == 4)
        {
            Player.transform.position = new Vector3(17.99f, -1.91f, 0);

        }

        
        
           // Player.transform.localScale = gameObject.transform.localScale;
        
        sprite.enabled = false;
        Player.GetComponent<SpriteRenderer>().enabled = true;

    }

    public void CaterpillarEvent()
    {
        pMovement.CaterpillarEvent();
    }
}
