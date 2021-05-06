using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_AI : MonoBehaviour
{
    private Image HealthBar;
    private float MaxHealth = 100f;
    public float CurrentHealthAI;

    AITest AI_Script;


    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
        AI_Script = FindObjectOfType<AITest>();


    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealthAI = AI_Script.Health;
        HealthBar.fillAmount = CurrentHealthAI / MaxHealth; 
    }


}