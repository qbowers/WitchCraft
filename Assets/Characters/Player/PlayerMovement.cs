using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController2D controller;
    private PlayerControls.PlayerActions playerMap;

    void Awake () {
        playerMap = new PlayerControls().Player;
    }

    void OnEnable() {
        playerMap.Enable();
        playerMap.Jump.performed += (context) => {
            controller.Jump(false);
        };
    }

    void OnDisable() {
        playerMap.Disable();
    }

    void Update () {
		// Tell our character how we want it to move
		controller.MoveInput(playerMap.Move.ReadValue<Vector2>().x);
	}
}
