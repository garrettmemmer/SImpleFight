using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelection : MonoBehaviour
{

    
    public GameObject[] StageList;
    public int selectedStage;

    void Start(){

        //print("FUCK" + );
        selectedStage = 0;
        StageList[selectedStage].SetActive(true);
        print("FUCK! stage: " + selectedStage);
    }



    public void NextCharacter()
    {

        StageList[selectedStage].SetActive(false);
        selectedStage = (selectedStage + 1) % StageList.Length;
        StageList[selectedStage].SetActive(true);
        print("FUCK stage: " + selectedStage);

    }

    public void PreviosCharacter()
    {
        StageList[selectedStage].SetActive(false);
        selectedStage--;
        if(selectedStage < 0)
        {
            selectedStage += StageList.Length;
        }
        StageList[selectedStage].SetActive(true);
    }

  



    public void StartGame()
    {
        PlayerPrefs.SetInt("StageList", selectedStage);
        SceneManager.LoadScene("GameScene");
    }
}
