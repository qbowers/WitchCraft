using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController2D controller;
    private PlayerControls playerControls;
    private PlayerControls.PlayerActions playerMap;
    private float horizontalMove = 0f;
	bool crouch = false;
    
    void Awake (){
        playerControls = new PlayerControls();
        playerMap = playerControls.Player;
    }

    void OnEnable(){
        playerMap.Enable();
        playerMap.Jump.performed += (context) => {
            controller.jump(controller.m_JumpForce, false);
        };
        playerMap.Crouch.performed += (context) => {
            if (controller.m_Grounded) {
                crouch = true;
            }
        };
        playerMap.Crouch.canceled += (context) => {
            crouch = false;
        };

    }

    void OnDisable(){
        playerControls.Player.Disable();
    }

    // Update is called once per frame
    void FixedUpdate (){
		// Move our character
        horizontalMove = playerMap.Move.ReadValue<Vector2>().x * controller.runSpeed;
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch);
	}
}
