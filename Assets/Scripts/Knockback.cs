using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class Knockback : MonoBehaviour
{

    public float thrust;
    public float knockTime; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Computer"))
        {
            Debug.Log("enemy hit in knockback");
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if(enemy != null)
            {
                Debug.Log("enemy hit in knockback part2");
                enemy.isKinematic = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemy));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if(enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.isKinematic = true;
        }
    }

}
*/

///better? solution

//public class Knockback : MonoBehaviour
//{
//    [SerializeField] private float thrust;

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.CompareTag("Computer"))
//        {
//            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
//            if (enemy != null)
//            {
                
//                StartCoroutine(KnockCoroutine(enemy));  
//            }
//        }
//    }

//    private IEnumerator KnockCoroutine(Rigidbody2D enemy)
//    {
//        Debug.Log("enemy hit in knockback coroutine");
//        Vector2 forceDirection = enemy.transform.position - transform.position;
//        Vector2 force = forceDirection.normalized * thrust;

//        enemy.velocity = force;
//        yield return new WaitForSeconds(.5f);

//        enemy.velocity = new Vector2();
//    }
//}


//HAHA FUCK YOU KNOCKBACK, IT FINALLY WORKS
public class Knockback : MonoBehaviour
{
    [SerializeField] private float thrust;
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
    }
}

