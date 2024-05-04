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
    bool isTilemap = false;
    bool isParticleSystem = false;
    private Color startColor;
    public bool colorChange = false;
    public bool colorDark = false;
    private PlayerMovement pMove;

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
            isTilemap = true;
        }
        else if (GetComponent<ParticleSystem>() != null)
        {
            InitialMat = GetComponent<ParticleSystemRenderer>().material;
            var main = GetComponent<ParticleSystem>().main;

            startColor = main.startColor.color;
            isParticleSystem = true;
            spriteYesTileNo= false;
            isTilemap= false;
        }
        pMove = GameObject.Find("Player").GetComponent<PlayerMovement>();

    }

    public void BecomeBW()
    {
        if (spriteYesTileNo)
        {
            gameObject.GetComponent<SpriteRenderer>().material = BWMaterial;
            if (colorChange)
            {
                if(!colorDark) 
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                else
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 1);

            }
        }
        else if (isTilemap)
        {
            gameObject.GetComponent<TilemapRenderer>().material = BWMaterial;
        }
        else if (isParticleSystem)
        {
            gameObject.GetComponent<ParticleSystemRenderer>().material = BWMaterial;
            if (colorChange)
            {
                var main = gameObject.GetComponent<ParticleSystem>().main;
                main.startColor = new Color(0.5f, 0.5f, 0.5f, 1);
            }
        }
        desaturated = true;

    }

    public void GetColourful()
    {
        if (spriteYesTileNo)
        {
            gameObject.GetComponent<SpriteRenderer>().material = InitialMat;
            if (colorChange)
                gameObject.GetComponent<SpriteRenderer>().color = startColor;
        }
        else if (isTilemap)
        {
            gameObject.GetComponent<TilemapRenderer>().material = InitialMat;

           
        }
        else if (isParticleSystem)
        {
            gameObject.GetComponent<ParticleSystemRenderer>().material = InitialMat;
            if (colorChange)
            {
                var main = gameObject.GetComponent<ParticleSystem>().main;
                main.startColor = startColor;
            }
        }
        desaturated = false;
    }

    private void Update()
    {
     

        if((RewindBySlider.isRewindRunning || PlayerMovement.rewind) && !desaturated && pMove.rewindMode != PlayerMovement.RewindMode.voidtime)
        {
            BecomeBW();
        }
       
        else if ((!RewindBySlider.isRewindRunning && !PlayerMovement.rewind) & desaturated)
        { 
                GetColourful();
        }

       
    }


   


}
