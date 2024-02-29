using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class RewindSaturationManager : MonoBehaviour
{
    public Material BWMaterial;
    private Material InitialMat;
    private bool desaturated = false;
    public bool rewindable = false;
    bool spriteYesTileNo = true;
    private Color startColor;
    public bool colorChange = false;

    private void Start()
    {
        if(GetComponent<SpriteRenderer>() != null)
        {
            InitialMat = GetComponent<SpriteRenderer>().material;
            startColor = GetComponent<SpriteRenderer>().color;
            spriteYesTileNo = true;
        }
        else if(GetComponent<TilemapRenderer>() != null)
        {
            InitialMat = GetComponent<TilemapRenderer>().material;
            
            spriteYesTileNo = false;
        }

        
    }

    public void BecomeBW()
    {
        if (spriteYesTileNo)
        {
            gameObject.GetComponent<SpriteRenderer>().material = BWMaterial;
            if(colorChange)
            gameObject.GetComponent<SpriteRenderer>().color = new Color (0.5f, 0.5f, 0.5f, 1);
        }
        else
            gameObject.GetComponent<TilemapRenderer>().material = BWMaterial;

        desaturated = true;

    }

    public void GetColourful()
    {
        if (spriteYesTileNo)
        {
            gameObject.GetComponent<SpriteRenderer>().material = InitialMat;
            if(colorChange)
            gameObject.GetComponent<SpriteRenderer>().color = startColor;
        }
        else
            gameObject.GetComponent<TilemapRenderer>().material = InitialMat;

           desaturated = false;
    }

    private void Update()
    {
     

        if(RewindBySlider.isRewindRunning && !desaturated)
        {
            BecomeBW();
        }
       
        else if (!RewindBySlider.isRewindRunning & desaturated)
        { 
                GetColourful();
        }
    }

   


}
