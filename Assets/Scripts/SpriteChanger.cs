using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    public GameObject player1Tag;

    void ChangeSprite()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
 
   }

    public void Change()
    {
        //spriteRenderer.sprite = newSprite;
        //change size of newSprite so its visible
        //Debug.Log("test");
        //set position of selected fighter
        //x -153.5
        //y -111.8
        //scale X .08
        //scale Y .08
    }

    public void SetBean()
    {
        spriteRenderer.sprite = newSprite;
        
        //
    }

}
