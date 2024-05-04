using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingFlowerScript : MonoBehaviour
{
    [SerializeField] private GameObject Stamen;
    [SerializeField] private GameObject Leaf;
    [SerializeField] private GameObject FruitingFlower;
    [SerializeField] private GameObject newLeaf;

   public Vector3 startSize = Vector3.zero;
    private Vector3 endSize = Vector3.one;
    private float duration = 1f;
    private float elapsedTime = 0f;
    public bool redFruiting = false;
 


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
            Stamen.transform.localScale = Vector3.Lerp(Vector3.zero, endSize, percentageTime);
            yield return null;
        }
        if(redFruiting)
        {
            FruitingFlower.SetActive(true);

            newLeaf.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            gameObject.SetActive(false);


        }

    }

  

    IEnumerator Shrink()
    {
        elapsedTime = 0f;
        duration = 0.3f;

        while (Stamen.transform.localScale != Vector3.zero)
        {

            elapsedTime += Time.deltaTime;
            float percentageTime = elapsedTime / duration;
            Stamen.transform.localScale = Vector3.Lerp(endSize, Vector3.zero, percentageTime);
            yield return null;
        }
    
        Stamen.SetActive(false);
        Leaf.SetActive(false);

    }

    public void ActivateLeaf()
    {
        Leaf.SetActive(true);
    }

}
