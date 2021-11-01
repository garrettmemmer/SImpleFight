using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{

    public GameObject[] characters;

    public GameObject p2selection;

    public int selectedCharacter;

    void Start(){



        selectedCharacter = 0;
        characters[selectedCharacter].SetActive(true);
        print("FUCK! p1: " + selectedCharacter);
        //print("FUCK" + );
    }



    public void NextCharacter()
    {

        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
        print("FUCK p1: " + selectedCharacter);

    }

    public void PreviosCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void NextPlayer2()
    {

    }

    public void PreviousPlayer2()
    {

    }

    public void NextStage()
    {

    }

    public void PreviousStage()
    {

    }



    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        //PlayerPrefs.SetInt("P2selectedCharacter", P2selectedCharacter);
        PlayerPrefs.SetInt("P2selectedCharacter", selectedCharacter);
        
        SceneManager.LoadScene("GameScene");
    }
}
