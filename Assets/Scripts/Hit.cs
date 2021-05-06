using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField]
    GameObject hitParticles;
    AITest AI_Script;
    ShakeBehaviour ScreenShake;

   public float newHealthAI; //i think this line is deprecated



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

            //screenshake
            ScreenWiggle();

            //play Hurt animation

            //Knockback

            //hit stun


            //adjust health
            DecreaseHealth();
        }
    }

    void DecreaseHealth()
    {
        AI_Script.Health -= 20;
    }

    void Knockback()
    {
        //when a fighter gets hit, they should be knocked back a certain amount
        //this will be expanded on in the future 

        //for now we will do a set distance
    }

    void ScreenWiggle()
    {
        //found an article to read on how to do this
        // SkakeBehaviour.TriggerShake();

        //ShakeBehaviour.TriggerShake();
        //ScreenShake.GetComponent<ShakeBehaviour>().TriggerShake();
        ScreenShake.shakeMe = true;
        Debug.Log("ScreenWiggle() called");

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
