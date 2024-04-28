using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelIconAppearance : MonoBehaviour
{
    private float duration = 1f;
    private float elapsedTime = 0f;
    private GameObject glow;

    private void Awake()
    {
        glow = GameObject.Find("Glow");
        if((PlayerPrefs.GetInt("Level") +1) == int.Parse(gameObject.tag))
        {
            StartCoroutine(AppearanceDuIcon());
        }
        else
            transform.localScale = Vector3.one;
    }
  
   
    public IEnumerator AppearanceDuIcon()
    {
    
        print("growing");
        transform.localScale = Vector3.zero;
        glow.GetComponent<Image>().color = new Color(1, 1, 0.75f, 0);
        glow.transform.position = gameObject.transform.position;
        while (transform.localScale.x < 1)
        {

            elapsedTime += Time.deltaTime;
            float percentageTime = elapsedTime / duration;
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, percentageTime);
            yield return null;
        }
        elapsedTime = 0f;
        while  (glow.GetComponent<Image>().color.a < 0.4f)
        {
            elapsedTime += Time.deltaTime;
            float percentageTime = elapsedTime / duration;
            glow.GetComponent<Image>().color = Color.Lerp(new Color(1, 1, 0.75f, 0), new Color(1, 1, 0.75f, 0.4f), percentageTime);
            yield return null;
        }


       // transform.localScale = Vector3.one;

    }
}
