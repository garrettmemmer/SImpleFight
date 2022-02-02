using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    internal BeanController beanScript;
    
    [SerializeField]
    public GameObject hitParticles;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HitBox"))
        {
            beanScript.isHit = true;

            //particales
            Instantiate(hitParticles, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            
            //screenshake


            //hitstun


            //adjusthealth
            beanScript.health -= 10;

        }
    }


}
