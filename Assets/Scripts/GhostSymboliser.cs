using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostSymboliser : MonoBehaviour
{
    Image image;
    [SerializeField] private Sprite ghost;

    // Start is called before the first frame update
    void Start()
    {
        image=GetComponent<Image>();
    }

    // Update is called once per frame
   public void SetGhostHUD()
   { 
            image.sprite = ghost;
   }
        
    
}
