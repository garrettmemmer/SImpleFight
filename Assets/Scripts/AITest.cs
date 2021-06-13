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
    //may need different attack delays for getting hit,
    //right now we are using attack delay for playing the hit animation and this may be problematic in the future.

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
        //
    }

    private void FixedUpdate()
    {
        //best for movement and physics
        //regular update should just be for input checking
        float newHealth = 100;

        

        if (!isAttacking)
        {
           ChangeAnimationState(AI_idle);
        } 
        
        if (Health < newHealth)
        {
            ChangeAnimationState(AI_Hit); // there is some issue with how the animator is set up;
            newHealth = Health;
            Invoke("AttackComplete", attackDelay);
        }
        else
        {
            MindLessAttack();
            Invoke("AttackComplete", attackDelay);
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
        //MindLessAttack();
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;
        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

    void MindLessAttack()
    {
        ChangeAnimationState(AI_LK);
        //Debug.Log("mindless");
        //AttackComplete();
        //Invoke("AttackComplete", attackDelay);
    }
}
