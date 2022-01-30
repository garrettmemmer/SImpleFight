using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//main character controller + state machine
public class MovementSM : StateMachine2
{
    //[HideInInspector]
    //public static MovementSM instance;
    //public Idle idleState;
    //[HideInInspector]
    //public Moving movingState;
    //public Jumping jumpingState;
    public LowKick lowKick;
/////////////////////////////////////////////////////////////////////////
    //public SpriteRenderer spriteRenderer;
    public Animator anim;
    //internal Rigidbody2D rigidbody;
    public Rigidbody2D rigidbody;
    public SpriteRenderer spriteRenderer;
///////////////////////////////////////////////////////////////////
//ANIMATIONS
    private string currentAnimaton;
    public const string Player_LK = "SFLK";
    const string Player_idle = "PlayerIdle";
    const string Player_HK = "SfHkFull";
    //const string Player_dodge = "SFDodge";
    //const string Player_Hit = "SFHit";

///////////////////////////////////////////////////////////////////
//VARIABLES////////////////////////////////////////////////////////
    internal string currentAnimState;
    public bool isAnimated;
    public bool isLowKicking;
    public bool isHeavyKicking;
    public bool animationCompleted;
   // public bool isHit;
    //public float knockbackPower = 100;
   // public float knockbackDuration = 1;
    //public float speed = 4f;
    //public float jumpForce = 10f;


    public float speed = 4f;
    public float jumpForce = 14f;


    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Moving movingState;
    [HideInInspector]
    public Jumping jumpingState;

    private void Awake()
    {
        //instance = this;
        idleState = new Idle(this);
        movingState = new Moving(this);
        jumpingState = new Jumping(this);
        lowKick = new LowKick(this);
    }
    protected override BaseState GetInitialState()
    {
        return idleState;
    }
    ///*
   // void Start()
  //  {
     //           print("start called");

    //    anim = GetComponent<Animator>();
        //rigidbody = GetComponent<Rigidbody2D>();
  //  }


    internal void ChangeAnimationState(string newAnimationState)
    {
        if (currentAnimState == newAnimationState) return;
        anim.Play(newAnimationState);
        currentAnimState = newAnimationState;
    }
    public void AnimationComplete() 
    {
        isAnimated = false;
        isLowKicking = false;
        //lowKick.Exit();
        animationCompleted = true;
        //ChangeState(idleState);
    }

    public void AnimationFinished()
    {
        ChangeState(idleState);
        animationCompleted = false;
    }
    
    public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Transform obj)
    {
        float timer = 0;

        while (knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector3 direction = (obj.transform.position - this.transform.position).normalized;
            rigidbody.AddForce(-direction * knockbackPower);
        }
        yield return 0;
    }
    
}