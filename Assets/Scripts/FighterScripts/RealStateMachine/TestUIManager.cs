using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUIManager : MonoBehaviour
{
    public enum TestAlignment
    {
    Left,
    Right
    }

    public static TestUIManager Instance;

    [SerializeField]
    private Text leftText = null;
    [SerializeField]
    private Text rightText = null;
    [SerializeField]
    private string textToTrim = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        //print("test FUCK awake");
    }

    public void Display(StateObject enteredState, TestAlignment testAlignment)
    {
        var name = enteredState.ToString();
        //name = name.Remove(name.IndexOf(textToTrim), textToTrim.Length);
        //name = name.Remove(name.IndexOf("StateObject"), 5);
        print("test entered state: " + name);

        if (testAlignment == TestAlignment.Left)
        {
             leftText.text = name;
             print("Test left");
        }
        else
        {
            rightText.text = name;
            print("test right");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
