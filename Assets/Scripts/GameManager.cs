using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    AITest AI_Script;
    Freezer freeze_Script;
    float duration = 1f;
    public bool matchOver = false;
    bool rematchMenu = false;
    bool firstPass = false;

    void Start()
    {
        AI_Script = FindObjectOfType<AITest>();
        freeze_Script = FindObjectOfType<Freezer>();

        //rb2d = GetComponent<Rigidbody2D>();  //get the child component of KO Message set to active
    }

    void Update()
    {
        if (AI_Script.Health <= 0 && !firstPass )
        {

            //freeze the screen
            freeze_Script.Freeze();  //so we want this to work, and it does, but it breaks the reset
            
            //set variable to true
            matchOver = true;

            StartCoroutine(waiter());

        }
    }

    // enable ko message here probably
    // if aihealthbar <= 0 
    //screen freeze
    //then KO message Active
    //wait one second
    //reset/quit menu active


    IEnumerator waiter()
    {
        if (matchOver = true)
        {
            transform.GetChild(2).gameObject.SetActive(true);
            //Wait for 2 seconds
            yield return new WaitForSecondsRealtime(2);
            transform.GetChild(2).gameObject.SetActive(false);
            firstPass = true;
            rematchMenu = true;
        }

        matchOver = false;

        transform.GetChild(3).gameObject.SetActive(true);
    }
}
