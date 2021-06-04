using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITest : MonoBehaviour
{
    private Animator animator;
    public static AITest instance;

    private Rigidbody2D rb2d;

    private float xAxis;
    public float walkSpeed = 5f;

    public float Health = 100f;
    public Vector3 moveDirection;
    public float moveSpeed = 5;
    public float knockback;
    public float knockbackLength;
    public float knockbackCount;

    public bool invicible = false;
    private string currentAnimaton;
    public bool isInputting = false;
    public bool isDodgeing = false;
    public bool isLowKicking = false;
    public bool isHit = false;

    [SerializeField]
    private float attackDelay = 1f; // do we need different attack delays?

    private bool isAttackPressed;
    public bool isAttacking;
    public float knockbackPower = 100;
    public float knockbackDuration = 1;

    //Animation States
    const string AI_idle = "PlayerIdle";
    const string AI_dodge = "SFDodge";
    const string AI_LK = "SFLK";
    const string AI_HkStart = "SfHkStart";
    const string AI_Hit = "SFHit";

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
    }

    private void FixedUpdate()
    {
        //best for movement and physics
        //regular update show just be for input checking
        float newHealth = 100;

        if (!isAttacking)
        {
           ChangeAnimationState(AI_idle);
        }


        //input
        if (isInputting)
        {
            isInputting = false;
            //Debug.Log("made it here");
            
            if(Health < newHealth)
            {
                    ChangeAnimationState(AI_Hit); // there is some issue with how the animator is set up
                    //Debug.Log("made it here 3");
                newHealth = Health;
                Invoke("AttackComplete", attackDelay);
            }
            //if (!isAttacking)
            //{
            //    isAttacking = true;
            //    Debug.Log("made it here 2");
            //    if (isLowKicking)
            //    {  //low kick
            //        ChangeAnimationState(AI_LK);

            //    }
            //    else if (isDodgeing) //dodge
            //    {
            //        ChangeAnimationState(AI_dodge);
            //    }
            //    else if (isHit = true)
            //    {
            //        ChangeAnimationState(AI_Hit);
            //        Debug.Log("made it here 3");
            //    }
            //    Invoke("AttackComplete", attackDelay);
            //}
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
        isAttacking = false;
        isDodgeing = false;
        isLowKicking = false;
        isHit = false;
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;
        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }
}
