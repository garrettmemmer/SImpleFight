using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_AI : MonoBehaviour
{
    private Image HealthBar;
   // public float CurrentHealthPlayer;
    public float CurrentHealthAI;
    private float MaxHealth = 100f;
    //PlayerController Player_Script;
    AITest AI_Script;



    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
    //    Player_Script = FindObjectOfType<PlayerController>();
        AI_Script = FindObjectOfType<AITest>();
    }

    // Update is called once per frame
    void Update()
    {
     //   CurrentHealthPlayer = Player_Script.Health;
        CurrentHealthAI = AI_Script.Health;

        HealthBar.fillAmount = CurrentHealthAI / MaxHealth; //i guess we would need two different lines for this to work


    }
}