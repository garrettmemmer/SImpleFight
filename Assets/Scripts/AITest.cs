using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITest : MonoBehaviour
{

    public static AITest instance;

    private Rigidbody2D rb2d;

    public float Health = 100f;
    public Vector3 moveDirection;
    public float moveSpeed = 5;
    public float knockback;
    public float knockbackLength;
    public float knockbackCount;


    void Awake()
    {
        instance = this;
    }

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
        rb2d.velocity = moveDirection * moveSpeed;
        //transform.position += moveDirection * Time.deltaTime;
    }

    public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Transform obj)
    {
        float timer = 0;

        while (knockbackDuration > timer)
        {
            timer +=Time.deltaTime;
            Vector3 direction = (obj.transform.position - this.transform.position).normalized;
            rb2d.AddForce(-direction * knockbackPower);
        }

        yield return 0;
    }
}
