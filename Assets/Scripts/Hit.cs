using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField]
    GameObject hitParticles;
    AITest AI_Script;
    ShakeBehaviour ScreenShake;
    PlayerController Player_Script;

   public float newHealthAI; //i think this line is deprecated

    public bool hit = false; 


    void Start()
    {
        AI_Script = FindObjectOfType<AITest>();
        ScreenShake = FindObjectOfType<ShakeBehaviour>();
    }

    void OnTriggerEnter2D(Collider2D col) //wjen the computer gets hit
    {
        if (col.gameObject.name.Equals("SimpleFighterAI"))
        {
            //particle effect
            Instantiate(hitParticles, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), Quaternion.identity);
            Debug.Log("enemy hit");
            hit = true;

            //screenshake
            ScreenWiggle();

            //Knockback
            Knockback();
            

            //play Hurt animation

            //hit stun


            //adjust health
            DecreaseHealth();


            
        }
        hit = false;
    }

    void DecreaseHealth()
    {
        AI_Script.Health -= 10;
    }


    void Knockback()
    {
        //when a fighter gets hit, they should be knocked back a certain amount
        //this will be expanded on in the future 
        //for now we will do a set distance

        if (hit == true)
        {
            //AI_Script.moveDirection.x = 10;
            AI_Script.moveDirection.x = 10;
            Debug.Log("we are in the loop");
            Debug.Log(hit);
            hit = false;
            
        }
        AI_Script.moveDirection.x = 0;  //orginal plan was have it jump up to 100 and then back down, but it never changes when doing it this way
        Debug.Log(hit);
    }

    void ScreenWiggle()
    {
        ScreenShake.shakeMe = true;
        //Debug.Log("ScreenWiggle() called");

    }

    void HurtAnim()
    {
        //play hurt animation (or at least tell the other script to

    }

    void HitStun()
    {
        // lock the player in the Hurt animation
        //this may be incorporated with HurtAnim()

    }
}
