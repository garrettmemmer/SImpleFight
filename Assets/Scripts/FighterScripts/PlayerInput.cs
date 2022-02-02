using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    internal BeanController beanScript;
    internal bool isInputting;
    internal bool isLeftPressed;
    internal bool isRightPressed;
    internal bool isDodgePressed;
    internal bool isForwardTiltPressed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            isLeftPressed = true;
        } //if left pressed
        else
        {
            isLeftPressed = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            isRightPressed = true;
        } //if right
        else
        {
            isRightPressed = false;
        }


        if (Input.GetKey(KeyCode.Space)) //dodge
        {
            isDodgePressed = true;
            isInputting = true;
        } 
        else
        {
            isDodgePressed = false;
        }

        if (Input.GetKey(KeyCode.C)) //Low Kick
        {
            isForwardTiltPressed = true;
            isInputting = true;
        } 
        else
        {
            isForwardTiltPressed = false;
        }

        if (Input.GetKey(KeyCode.LeftShift)) //Heavy Kick
        {
            isForwardTiltPressed = true;
            isInputting = true;
        }
        else
        {
            isForwardTiltPressed = false;
        }
    }
}
