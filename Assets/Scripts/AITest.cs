using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITest : MonoBehaviour
{
    private Animator animator;
    public static AITest instance;

    private Rigidbody2D rb2d;

    public float Health = 100f;
    public float newHealth = 100;

    private float xAxis;
    public float walkSpeed = 5f;
    public Vector3 moveDirection;
    public float moveSpeed = 5;

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public float knockbackPower = 100;
    public float knockbackDuration = 1;

    public bool invicible = false;
    private string currentAnimaton;
    public bool isInputting = false;
    public bool isDodgeing = false;
    public bool isLowKicking = false;
    public bool isHit = false;

    [SerializeField]
    private float attackDelay = 1f; // do we need different attack delays?
    //may need different attack delays for getting hit,
    //right now we are using attack delay for playing the hit animation and this may be problematic in the future.

    private bool isAttackPressed;
    public bool isAttacking;

    //Animation States
    const string AI_idle = "PlayerIdle";
    const string AI_dodge = "SFDodge";
    const string AI_LK = "SFLK";
    const string AI_Hit = "SFHit";

    //Timer for AI moving
    public float nextActionTime = 0.0f;
    public float period = 0.1f;
    public float moveTime = 0.1f;
    public float movingDirection = 0f;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rb2d.velocity = moveDirection * moveSpeed;



        if (moveTime > .3) // we may need some different kinda timer 
        {
            //move back and forth
            Vector3 movement = new Vector3(movingDirection, 0f, 0f); 
            transform.position += movement * Time.deltaTime * walkSpeed;
            
            Debug.Log(movement);
            if (moveTime > 1)
            {
                moveTime = 0;
                movingDirection = (Random.Range(0, 2) * 2 - 1);
            }
        }
        moveTime += UnityEngine.Time.deltaTime;
        Debug.Log(moveTime);

        if (period > 2) // could change this time interval to anything
        {
            isInputting = true;
            isLowKicking = true;
            period = 0;
        }
        period += UnityEngine.Time.deltaTime;
    }

    private void FixedUpdate()
    {
        //best for movement and physics
        //regular update should just be for input checking




        if (!isAttacking)
        {
            ChangeAnimationState(AI_idle);
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
                    ChangeAnimationState(AI_LK);

                }
                else if (isDodgeing) //dodge
                {
                    ChangeAnimationState(AI_dodge);
                }

                Invoke("AttackComplete", attackDelay);
            }
        }
    

        if (Health < newHealth)
        {
            ChangeAnimationState(AI_Hit); 
            newHealth = Health;
            Invoke("AttackComplete", attackDelay);
                //Debug.Log(Health);
                //Debug.Log(newHealth);
                isAttacking = true;
        }

        
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

    void AttackComplete()
    {
        isInputting = false;
        isAttacking = false;
        isDodgeing = false;
        isLowKicking = false;
        isHit = false;
        nextActionTime = Time.time + period;
        
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;
        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

    void MindLessAttack()
    {
        isAttacking = true;
        ChangeAnimationState(AI_LK);
        Debug.Log("mindless");
        AttackComplete();
        Invoke("AttackComplete", attackDelay);
    }
}
