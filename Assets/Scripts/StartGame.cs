using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
/////////////////////////////////////////////////
//Data from character select screen
////////////////////////////////////////////////
    CharacterSelection P1CharacterSelectionScript;

    CharacterSelectPlayer2 P2CharacterSelectionScript;
    
    StageSelection StageSelectionScript;
///////////////////////////////////////////////////






    // Start is called before the first frame update
    void Start()
    {
        P1CharacterSelectionScript = FindObjectOfType<CharacterSelection>();
        P2CharacterSelectionScript = FindObjectOfType<CharacterSelectPlayer2>();
        StageSelectionScript = FindObjectOfType<StageSelection>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTheGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", P1CharacterSelectionScript.selectedCharacter);
        PlayerPrefs.SetInt("P2selectedCharacter", P2CharacterSelectionScript.P2selectedCharacter);
        PlayerPrefs.SetInt("StageList", StageSelectionScript.selectedStage);

        SceneManager.LoadScene("GameScene");
    }
}
