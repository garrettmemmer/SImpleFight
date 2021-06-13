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

    void OnTriggerEnter2D(Collider2D col) //when the computer gets hit
    {
        if (col.gameObject.name.Equals("SimpleFighterAI"))
        {
            //particle effect
            Instantiate(hitParticles, new Vector3(transform.position.x, transform.position.y +1, transform.position.z), Quaternion.identity);
            hit = true;

            //play Hurt animation
            HurtAnim();

            //screenshake
            ScreenWiggle();

            //hit stun ///not yet in the game

            //adjust health
            DecreaseHealth();
        }

        if (col.gameObject.name.Equals("SimpleFighter"))
        {
            Debug.Log("playerhit");
            //particle effect
            Instantiate(hitParticles, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            hit = true;

            //play Hurt animation
            //HurtAnimPlayer();

            //screenshake
            ScreenWiggle();

            //hit stun ///not yet in the game

            //adjust health
            //DecreaseHealthPlayer();
        }


        hit = false;
    }

    void DecreaseHealth()
    {
        AI_Script.Health -= 10;
    }

    void ScreenWiggle()
    {
        ScreenShake.shakeMe = true;
    }

    void HurtAnim()
    {
        AI_Script.isInputting = true;
        AI_Script.isAttacking = true;
        AI_Script.isHit = true;
    }

    void HitStun()
    {
        // lock the player in the Hurt animation
        //this may be incorporated with HurtAnim()
    }
}
