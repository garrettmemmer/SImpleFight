using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//HAHA FUCK YOU KNOCKBACK, IT FINALLY WORKS
public class Knockback : MonoBehaviour
{
    public float knockbackPower = 100;
    public float knockbackDuration = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Computer"))
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                StartCoroutine(AITest.instance.Knockback(knockbackDuration, knockbackPower, this.transform));
                //StartCoroutine(KnockCoroutine(enemy));
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("knockingback");
            Rigidbody2D player = collision.GetComponent<Rigidbody2D>();
            if (player != null)
            {
                StartCoroutine(BeanController.instance.Knockback(knockbackDuration, knockbackPower, this.transform));
                //StartCoroutine(KnockCoroutine(enemy));
            }
        }
    }
}

//There is an issue here that this looks for tags of player and calls a specific script to start the coroutine

//possibly fix tag issue by dynamically setting tags for AI and player? 

//possiblly fix the specific script problem by using bean controller for all fighters?
//^^^^probs wont work
//but maybe we can move a lot of the functionality to the Fighter class.