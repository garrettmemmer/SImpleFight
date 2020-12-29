using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField]
    GameObject hitParticles;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("SimpleFighterAI"))
        {
            Instantiate(hitParticles, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), Quaternion.identity);
            Debug.Log("enemy hit");
        }
    }

}
