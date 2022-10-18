using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController2D controller;
    private PlayerControls.PlayerActions playerMap;

    void Start () {
        playerMap = CoreManager.instance.playerMap;
        playerMap.Jump.performed += (context) => {
            controller.Jump(false);
        };
    }



    void Update () {
		// Tell our character how we want it to move
        // Debug.Log(controller);
        // Debug.Log(new PlayerControls().Player.Move);
        // Debug.Log(playerMap.Move);

		controller.MoveInput(playerMap.Move.ReadValue<Vector2>().x);
	}
}
