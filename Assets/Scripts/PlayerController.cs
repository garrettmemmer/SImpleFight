using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animator;

    private float xAxis;
    public float walkSpeed = 5f;

    public float Health = 100f;

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
    const string Player_HkStart = "SfHkStart";
    const string Player_HkCharge = "SfHkCharge";
    const string Player_HkRelease = "SfHkRelease";
    const string Player_HkFull = "SfHkFull";

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

               // else if (isHkStarted) //heavy kick
                //this will need the hold and release
               // { 
               //     ChangeAnimationState(Player_HkFull);

               // } 
               // else if (isHkCharging)
               // {
               //     ChangeAnimationState(Player_HkCharge);
               // }
               // else if (isHkReleased)
               // {
               //     ChangeAnimationState(Player_HkRelease);
               // }

                Invoke("AttackComplete", attackDelay);
            }
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


   // public void OnCollisionEnter2D(Collision2D other)
   // {
   //     if(other.gameObject.tag == "Computer")
   //     {
   //         StartCoroutine(AITest.instance.Knockback(knockbackDuration, knockbackPower, this.transform));
   //     }
 //   }

}
