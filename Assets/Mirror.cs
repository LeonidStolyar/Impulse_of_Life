using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class StringSprite
{
    [SerializeField] public string dir;
    [SerializeField] public Sprite sprite;
}
public class Mirror : MonoBehaviour
{
    
    // Start is called before the first frame update
    [SerializeField] private string mirrorDir; // TR TL DR DL
    [SerializeField] private List<StringSprite> stringSpritesList;

    private SpriteRenderer spriteRenderer;
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();

        ChangeMirrorSprite();
    }
    void Start()
    {
        Debug.Log(1234);
    }

    public void ChangeMirrorDir()
    {
        var indexDir = stringSpritesList.FindIndex(sprite => sprite.dir == mirrorDir);
        if (indexDir != -1)
        {
            if (indexDir == stringSpritesList.Count - 1)
            {
                mirrorDir = stringSpritesList[0].dir;
            }
            else
            {
                mirrorDir = stringSpritesList[indexDir + 1].dir;
            }
            ChangeMirrorSprite();
        }
        
    }
    public void ChangeMirrorSprite()
    {
        spriteRenderer.sprite = stringSpritesList[stringSpritesList.FindIndex(sprite => sprite.dir == mirrorDir)].sprite;
    }
    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Object")
        {
            var light = other.gameObject.GetComponent<LightMovement>();
            if (light != null)
            {
                var lightDir = light.direction;
                if(lightDir == "top")
                {
                    if (mirrorDir == "DL") light.direction = "left";
                    else if (mirrorDir == "DR") light.direction = "right";
                    else DestroyLight(light);
                    
                }
                else if(lightDir == "right")
                {
                    if (mirrorDir == "TL") light.direction = "top";
                    else if (mirrorDir == "DL") light.direction = "down";
                    else DestroyLight(light);
                    
                }
                else if(lightDir == "down")
                {
                    if (mirrorDir == "TR") light.direction = "right";
                    else if (mirrorDir == "TL") light.direction = "left";
                    else DestroyLight(light);
                    
                }
                else if(lightDir == "left")
                {
                    if (mirrorDir == "TR") light.direction = "top";
                    else if (mirrorDir == "DR") light.direction = "down";
                    else DestroyLight(light);
                }
            }
            
        }
    }
    private void DestroyLight(LightMovement light)
    {
        Destroy(light.gameObject);
    }
}
