using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //go straight to test build
        SceneManager.LoadScene("CharacterSelection"); //go to character select
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("SampleScene"); //test scene
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
}
