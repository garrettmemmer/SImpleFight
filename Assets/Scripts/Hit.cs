using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField]
    GameObject hitParticles;

    public float newHealthAI;
    AITest AI_Script;

    void Start()
    {
        AI_Script = FindObjectOfType<AITest>();
    }



    void OnTriggerEnter2D(Collider2D col) //wjen the computer gets hit
    {
        if (col.gameObject.name.Equals("SimpleFighterAI"))
        {
            //particle effect
            Instantiate(hitParticles, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), Quaternion.identity);
            Debug.Log("enemy hit");

            //screenshake

            //play Hurt animation

            //Knockback

            //adjust health
            DecreaseHealth();
        }
    }

    void DecreaseHealth()
    {
        AI_Script.Health -= 20;
    }

}
