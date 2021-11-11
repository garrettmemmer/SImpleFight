using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    [SerializeField]
    internal MovementSM _sm;
    internal GroundAttack groundAttack;
    public static Player1Controller instance;

    

    internal Animator anim;
    internal Rigidbody2D rb2d;

    internal string currentState;
    public bool isAnimated;
    public bool isHit;

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
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        _sm = new MovementSM();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void ChangeState(string newState)
    {
        if (currentState == newState) return;
        anim.Play(newState);
        currentState = newState;
    }
    
    
    public void AnimationComplete()
    {
        isAnimated = false;
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
