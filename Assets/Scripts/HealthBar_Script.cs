using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Script : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealthPlayer;
    private float MaxHealth = 100f;
    PlayerController Player_Script;


    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
        Player_Script = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealthPlayer = Player_Script.Health;
        HealthBar.fillAmount = CurrentHealthPlayer / MaxHealth; //i guess we would need two different lines for this to work
    }
}
