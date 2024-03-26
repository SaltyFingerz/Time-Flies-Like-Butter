using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollisionScript : MonoBehaviour
{
    bool collided = false;
    [SerializeField] private GameObject explosion;
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.name.Contains("Cloud") && !collided )
        {
            collided = true;
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
            coll.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            // Spawn an explosion at each point of contact
            Vector2 hitPoint = coll.contacts[0].point;
            Instantiate(explosion, new Vector3(hitPoint.x, hitPoint.y, 0), Quaternion.identity);

           /* foreach (ContactPoint2D missileHit in coll.contacts)
                {
             

       
                    Vector2 hitPoint = missileHit.point;
                    Instantiate(explosion, new Vector3(hitPoint.x, hitPoint.y, 0), Quaternion.identity);
                }
           */
        }
      
    }
}
