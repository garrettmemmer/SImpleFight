using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter 
{

    private Rigidbody2D rb2d;
    private Animator animator;

    private float xAxis;
    public float walkSpeed = 5f;

    public float Health = 100f;
    public float newHealth = 100f;

    public void Chop()
    {
       // Debug.Log("The fruit has been chopped.");
    }
}
