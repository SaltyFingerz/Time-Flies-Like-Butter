using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingFlowerScript : MonoBehaviour
{
    [SerializeField] private GameObject Stamen;

   private Vector3 startSize = Vector3.zero;
    private Vector3 endSize = Vector3.one;
    private float duration = 1f;
    private float elapsedTime = 0f;


    private void Start()
    {
     
            Stamen.transform.localScale = startSize;
        
    }
    public void HideStamen()
    {
        
        StartCoroutine(Shrink());
    }

    public void ShowStamen()
    {
        Stamen.SetActive(true);
        StartCoroutine(Grow());
    }

    IEnumerator Grow()
    {
        elapsedTime = 0f;
        duration = 1f;
        while (Stamen.transform.localScale != endSize)
        {
            
            elapsedTime += Time.deltaTime;
            float percentageTime = elapsedTime / duration;
            Stamen.transform.localScale = Vector3.Lerp(startSize, endSize, percentageTime);
            yield return null;
        }

    }

    IEnumerator Shrink()
    {
        elapsedTime = 0f;
        duration = 0.3f;
        while (Stamen.transform.localScale != startSize)
        {

            elapsedTime += Time.deltaTime;
            float percentageTime = elapsedTime / duration;
            Stamen.transform.localScale = Vector3.Lerp(endSize, startSize, percentageTime);
            yield return null;
        }
        Stamen.SetActive(false);

    }


}
