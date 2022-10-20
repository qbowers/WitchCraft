using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterJump jumpControls;
    public CharacterMovement movementControls;
    private PlayerControls.PlayerActions playerMap;

    void Start () {
        playerMap = CoreManager.instance.playerMap;
        playerMap.Jump.started += jumpControls.OnJumpAction;
        playerMap.Jump.canceled += jumpControls.OnJumpAction;
    }



    void Update () {
		// Tell our character how we want it to move
		movementControls.OnMovement(playerMap.Move);
	}
}
