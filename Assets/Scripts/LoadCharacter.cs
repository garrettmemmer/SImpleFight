using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] P1Fighters;
    public GameObject[] P2Fighters;

    public GameObject[] StageList;
    public GameObject[] Stage;
    public Transform p1SpawnPoint;
    public Transform p2SpawnPoint;
    public Transform stagePoint;
    int p1Selection;
    int p2Selection;
    int stageSelection;


    // Start is called before the first frame update
    void Start()
    {
        p1Selection = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = P1Fighters[p1Selection];
        GameObject clone = Instantiate(prefab, p1SpawnPoint.position, Quaternion.identity);
        //label.text = prefab.name;

        p2Selection = PlayerPrefs.GetInt("P2selectedCharacter");
        GameObject prefabP2 = P2Fighters[p2Selection];
        GameObject cloneP2 = Instantiate(prefabP2, p2SpawnPoint.position, Quaternion.identity);
        //label.text = prefab.name;

        stageSelection = PlayerPrefs.GetInt("selectedStage");
        GameObject prefabStage = StageList[stageSelection];
        GameObject cloneStage = Instantiate(prefabStage, stagePoint.position, Quaternion.identity);
        //label.text = prefab.name;

    }


}
