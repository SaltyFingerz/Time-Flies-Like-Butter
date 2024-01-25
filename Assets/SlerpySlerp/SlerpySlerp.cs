using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class SlerpySlerp : MonoBehaviour {
        [SerializeField] private Transform _start, _center, _end;
        [SerializeField] private int _count = 15;
        [SerializeField] private GameObject dot;
    private Transform lastStart;
    public bool drawing = false;
    

 
    private void Update () 
    { 
        if (!drawing)
        {
            DestroyDots();
        }
    }
    
       public void DestroyDots()
    {
        GameObject[] dots = GameObject.FindGameObjectsWithTag("Dot");
        foreach(GameObject dot in dots)
        {
            Destroy(dot);
        }
    }

        public void ShowTrajectory() 
        {

        // if (_start.position != _start.position)
        //  {
 
            StartCoroutine(DrawDots());
        }

          
     //   }

           // Gizmos.color = Color.red;
          //  Gizmos.DrawSphere(_center.position, 0.2f);
        


    IEnumerator DrawDots()
    {
        GameObject[] dots = GameObject.FindGameObjectsWithTag("Dot");


        if (dots.Length <15)
        {
           

            foreach (var point in EvaluateSlerpPoints(_start.position, _end.position, _center.position, _count))
            {
                // Gizmos.DrawSphere(point, 0.1f); //just replace the draw sphere.

                Instantiate(dot, point, transform.rotation);
                yield return null;
            }

        }

      
        


    }








    IEnumerable<Vector3> EvaluateSlerpPoints(Vector3 start, Vector3 end, Vector3 center,int count = 10) {
            var startRelativeCenter = start - center;
            var endRelativeCenter = end - center;

            var f = 1f / count;

            for (var i = 0f; i < 1 + f; i += f) {
                yield return Vector3.Slerp(startRelativeCenter, endRelativeCenter, i) + center;
            }
        }
    }
