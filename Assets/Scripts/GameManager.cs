using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    AITest AI_Script;
    Freezer freeze_Script;

    float duration = 1f;
    //public bool matchOver = false;
    //bool rematchMenu = false;
    bool firstPass = true;

    public GameObject gameOverGameObject;
    public GameObject gameOverMenu;

/////////////////////////////////////////////////
//Data from character select screen
////////////////////////////////////////////////
    CharacterSelection P1CharacterSelectionScript;
    CharacterSelectPlayer2 P2CharacterSelectionScript;
    StageSelection StageSelectionScript;
///////////////////////////////////////////////////

    void Start()
    {
        AI_Script = FindObjectOfType<AITest>();
        freeze_Script = FindObjectOfType<Freezer>();
    }

    void Update()
    {
        if (AI_Script.Health <= 0 && firstPass )
        {
            EndFight();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //freeze the game
            //pull up the reset/quit menu

            //if escape pressed again //resume the game
            //close the menu
            //unfreeze the game
        }
    }

    // if aihealthbar <= 0 and its first pass
        //call endfight
    //endfight
        //screen freeze
        //then KO message Active
    //invoke(postFightMenu, 1.5)
        //wait one.5 second
        //ko off
        //reset/quit menu active



    void EndFight()
    {
        firstPass = false;
        print("should be over"); 

        freeze_Script.Freeze();

        print("turing on KO");
        gameOverGameObject.SetActive(true);

        Invoke("PostFightMenu", 1.5f);
        //print("entering coroutine");
        //StartCoroutine(waiter());
        //print("exiting coroutine");

        //print("turning on menu");
        //gameOverMenu.SetActive(true);
    }

    void PostFightMenu()
    {
        print("freeze and ko should activate, then this text appears 1.5 seconds later");
        
        //turning off KO
        gameOverGameObject.SetActive(false);

        //print("turning on menu");
        gameOverMenu.SetActive(true);
    }



    IEnumerator waiter()
    {
        print("inside the couroutine");
        freeze_Script.Freeze();
        gameOverGameObject.SetActive(false);

        //Wait for 2 seconds
        yield return new WaitForSecondsRealtime(2);
    }
}
