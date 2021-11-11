using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    internal BeanController beanScript;

    internal Player1Controller playerscript;

    void Update()
    {
        //Check the input manager for button press state
        //simple movement buttons
        if (beanScript.inputScript.isLeftPressed)
        {
            MovePlayerLeft();
        }
        else if (beanScript.inputScript.isRightPressed)
        {
            MovePlayerRight();
        }
        else
        {
            StopMovement();
        }
        //if (beanScript.inputScript.isJumpPressed)
       //{
        //    MovePlayerJump();
       //}
    }


    private void MovePlayerLeft()
    {
        beanScript.rb2d.velocity = new Vector2(-beanScript.walkSpeed, 0);
    }
    private void MovePlayerRight()
    {
        beanScript.rb2d.velocity = new Vector2(beanScript.walkSpeed, 0);
    }
    private void StopMovement()
    {
        beanScript.rb2d.velocity = new Vector2(0, 0);
    }
  //  private void MovePlayerJump()
  //  {
   //     beanScript.rb2d.velocity = new Vector2(0, beanScript.jumpHeight);
  //  }

    private void ForwardTilt()
    {
        beanScript.ChangeState("SFLK");
    }
}
