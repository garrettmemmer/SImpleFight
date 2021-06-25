using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animator;

    public static PlayerController instance;

    private float xAxis;
    public float walkSpeed = 5f;

    public float Health = 100f;
    public float newHealth = 100f;

    public bool invicible = false;
    private string currentAnimaton;
    public bool isInputting = false;
    public bool isDodgeing = false;
    public bool isLowKicking = false;
    public bool isHkStarted = false;
    public bool isHkCharging = false;
    public bool isHkReleased = false;
    private bool isAttackPressed;
    private bool isAttacking;
    public float knockbackPower = 100;
    public float knockbackDuration = 1;



    [SerializeField]
    private float attackDelay = 1f; // do we need different attack delays?

    //Animation States
    const string Player_idle = "PlayerIdle";
    const string Player_dodge = "SFDodge";
    const string Player_LK = "SFLK";
    const string Player_Hit = "SFHit";



    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checking for inputs
        xAxis = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftShift)) //Dodge
        {
            isInputting = true;
            isLowKicking = true;
        }

        if (Input.GetKeyDown(KeyCode.Space)) //Dodge
        {
            isInputting = true;
            isDodgeing = true;
        }
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * walkSpeed;
    }

    private void FixedUpdate()
    {
        //best for movement and physics
        //regular update show just be for input checking

        if (!isAttacking)
        {
            ChangeAnimationState(Player_idle);
        }


        //input
        if (isInputting)
        {
            isInputting = false;

            if (!isAttacking)
            {
                isAttacking = true;

                if (isLowKicking)
                {  //low kick
                    ChangeAnimationState(Player_LK);
                    
                }
                else if (isDodgeing) //dodge
                {
                    ChangeAnimationState(Player_dodge);   
                }

                Invoke("AttackComplete", attackDelay);
            }
        }

        //getting hit
        if (Health < newHealth)
        {
            ChangeAnimationState(Player_Hit); 
            newHealth = Health;
            Invoke("AttackComplete", attackDelay);
            //Debug.Log(Health);
            //Debug.Log(newHealth);
            isAttacking = true;
        }
    }


    void AttackComplete()
    {
        isAttacking = false;
        isDodgeing = false;
        isLowKicking = false;
        isHkStarted = false;
        isHkCharging = false;
        isHkReleased = false;
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;
        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

    public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Transform obj)
    {
        float timer = 0;

        while (knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector3 direction = (obj.transform.position - this.transform.position).normalized;
            rb2d.AddForce(-direction * knockbackPower);
        }

        yield return 0;
    }
}
