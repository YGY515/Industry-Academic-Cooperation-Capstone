using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputsManager : MonoBehaviour
{
    public Vector2 move;
    public Vector2 look;

    public bool sprint = false;
    public bool jump = false;
    public bool interact = false;
    public bool dialogueTap = false;
    public bool cursorInputForLook = false;
    void OnLook(InputValue value)
    {
  
        look = value.Get<Vector2>();
       
     }
    void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }
    void OnSprint(InputValue value)
    {
        sprint = value.isPressed;
    }
    void OnJump(InputValue value)
    {
        jump = value.isPressed;
    }
    void OnInteract(InputValue value)
    {
        interact = value.isPressed;
    }
    void OnDialogueTap(InputValue value)
    {
        dialogueTap = value.isPressed;
    }
}

