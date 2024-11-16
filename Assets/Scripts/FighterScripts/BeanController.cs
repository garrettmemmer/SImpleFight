using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanController : MonoBehaviour
{ 
    [SerializeField]
    internal PlayerInput inputScript;

    [SerializeField]
    internal PlayerMovement movementScript;

    [SerializeField]
    internal PlayerCollision collisionScript;

    public static BeanController instance;

    public RealStateMachine movementSM;
    public RealStandingState standing;
    public RealDuckingState ducking;
    public RealJumpingState jumping;
    public RealAttackingState attackingState;
    public RealHitStun dodging; //this is fucked
    //this state machine is so messed up


    [SerializeField]
    internal int health = 100;
    internal int newHealth = 100;

    [SerializeField]
    internal float walkSpeed = 1;
    [SerializeField]
    //internal float jumpHeight = 5;
    internal float movement;

    //component references
    internal Animator anim;
    internal Rigidbody2D rb2d;

    //other references
    internal string currentState;
    public bool isAnimated;
    public bool isHit;

    private bool isLeftPressed;
    private bool isRightPressed;
    private bool isDodgePressed;
    private bool isForwardTiltPressed;


    //animations
    private string currentAnimaton;
    public const string Player_LK = "SFLK";
    const string Player_idle = "PlayerIdle";
    const string Player_dodge = "SFDodge";
    const string Player_Hit = "SFHit";

    public float knockbackPower = 100;
    public float knockbackDuration = 1;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();


        movementSM = new RealStateMachine();

        standing = new RealStandingState(this, movementSM);
        ducking = new RealDuckingState(this, movementSM);
        jumping = new RealJumpingState(this, movementSM);
        attackingState = new RealAttackingState(this, movementSM);

        movementSM.Initialize(standing);
    }

    /////////////////
    //  STATE MANAGER
    /////////////////
    internal void ChangeState(string newState)
    {
        if (currentState == newState) return;
        anim.Play(newState);
        currentState = newState;
    }

    void Update()
    {
        movementSM.CurrentState.HandleInput();

        movementSM.CurrentState.LogicUpdate();

        if (health < newHealth)
        {
            ChangeState("SFHit");
            newHealth = health;
            Invoke("AnimationComplete", .5f); //this should be a variable for hit stun
            isAnimated = true;
            isHit = false;
        }
    }

    void FixedUpdate()
    {
        movementSM.CurrentState.PhysicsUpdate();

        if (!isAnimated)
        {
            ChangeState("PlayerIdle");
        }

        if (inputScript.isInputting)
        {
            inputScript.isInputting = false;
            if (!isAnimated)
            {
                isAnimated = true;
                if (inputScript.isForwardTiltPressed)
                {
                    ChangeState("SFLK");
                     //Debug.Log("this changed state: base script");
                    Invoke("AnimationComplete", .6f);
                }
                else if (inputScript.isDodgePressed)
                {
                    ChangeState("SFDodge");
                    //set the hurtbox to off
                    Invoke("AnimationComplete", 1f);
                }
                
            }
        }
    }

    public void AnimationComplete()
    {
        isAnimated = false;
        //isHit = false;
//         print("clear and ready for more inputs");
        //isDodgeing = false;
        //isLowKicking = false;
        //isHkStarted = false;
        //isHkCharging = false;
        //isHkReleased = false;
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
