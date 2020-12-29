using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animator;

    private float xAxis;
    public float walkSpeed = 5f;

    public bool invicible = false;
    private string currentAnimaton;
    public bool isInputting = false;
    public bool isDodgeing = false;
    public bool isLowKicking = false;
    private bool isAttackPressed;
    private bool isAttacking;

    [SerializeField]
    private float attackDelay = 1f;

    //Animation States
    const string Player_idle = "PlayerIdle";
    const string Player_dodge = "SFDodge";
    const string Player_LK = "SFLK";

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
            Debug.Log("LK pressed");
        }

        if (Input.GetKeyDown(KeyCode.Space)) //Dodge
        {
            isInputting = true;
            isDodgeing = true;
            Debug.Log("dodge pressed");
        }



        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * walkSpeed;
        /*
        if (Input.GetKey(KeyCode.D)) //Right
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
        }

        if (Input.GetKey(KeyCode.A)) // Left
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
        }
        */
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
                    Debug.Log("low kicked");
                    
                }
                else if (isDodgeing) //dodge
                {
                    ChangeAnimationState(Player_dodge);
                    Debug.Log("dodged");
                
                }

                // else if () //heavy kick
                //this will need the hold and release
                // { } //ChangeAnimationState(PLAYER_ATTACK);


                Invoke("AttackComplete", attackDelay);


            }
        }


    }



    void AttackComplete()
    {
        isAttacking = false;
        isDodgeing = false;
        isLowKicking = false;
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

}
