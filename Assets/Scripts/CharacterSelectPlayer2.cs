using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectPlayer2 : MonoBehaviour
{

    
    public GameObject[] P2characters;
    public int P2selectedCharacter;

    void Start(){

        //print("FUCK" + );
        P2selectedCharacter = 0;
        P2characters[P2selectedCharacter].SetActive(true);
        print("FUCK! p2: " + P2selectedCharacter);
    }



    public void NextCharacter()
    {

        P2characters[P2selectedCharacter].SetActive(false);
        P2selectedCharacter = (P2selectedCharacter + 1) % P2characters.Length;
        P2characters[P2selectedCharacter].SetActive(true);
        print("FUCK p2: " + P2selectedCharacter);

    }

    public void PreviosCharacter()
    {
        P2characters[P2selectedCharacter].SetActive(false);
        P2selectedCharacter--;
        if(P2selectedCharacter < 0)
        {
            P2selectedCharacter += P2characters.Length;
        }
        P2characters[P2selectedCharacter].SetActive(true);
    }

  



    public void StartGame()
    {
        PlayerPrefs.SetInt("P2selectedCharacter", P2selectedCharacter);
        SceneManager.LoadScene("GameScene");
    }
}


