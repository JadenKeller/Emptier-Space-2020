using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChangeOnHover : MonoBehaviour
{
    public Sprite OGsprite; 
    public Sprite NEWsprite; 
    public SpriteRenderer spriteRenderer;
    // Set your sprites. spriteRenderer is set to itself 

    void Start()
    {
        
    }
    void OnMouseOver()
    {
        // Change the sprite when the mouse is over GameObject
        spriteRenderer.sprite = NEWsprite; 
    }

    void OnMouseExit()
    {
        // Reset the sprite back to normal
        spriteRenderer.sprite = OGsprite; 
    }
    // Update is called once per frame (empty)
    void Update()
    {
        
        
    }
}
