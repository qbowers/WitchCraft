using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;
    public float dashSpeed = 2;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
    bool dash = false;
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} 
        else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

        if (Input.GetButtonDown("Dash"))
		{
			dash = true;
		} 
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        if (dash) {
            controller.Move(horizontalMove * dashSpeed * Time.fixedDeltaTime, false, false);
        }
        dash = false;
		jump = false;
	}
}