using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITest : MonoBehaviour
{

    private Rigidbody2D rb2d;

    public float Health = 100f;
    public Vector3 moveDirection;
    public float knockback;
    public float knockbackLength;
    public float knockbackCount;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += moveDirection * Time.deltaTime;
        Move();
    }

    void Move()
    {
        transform.position += moveDirection * Time.deltaTime;
    }
}
