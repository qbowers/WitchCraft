using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour {
	// Amount of force added when the player jumps.
	[SerializeField] public float m_JumpForce = 400f;

    [SerializeField] public float runSpeed = 0f;

	// How much to smooth out the movement
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;

	// Whether or not a player can steer while jumping;
	[SerializeField] private bool m_AirControl = false;

	// A mask determining what is ground to the character
	[SerializeField] private LayerMask m_WhatIsGround;

	// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_GroundCheck;



	// Radius of the overlap circle to determine if grounded
	const float k_GroundedRadius = .2f;
	// Whether or not the player is grounded.
	public bool m_Grounded;

	private Rigidbody2D m_Rigidbody2D;
	private Vector3 m_Velocity = Vector3.zero;

	// For determining which way the player is currently facing.
	public bool m_FacingRight = true;

	
	private void Start() {
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate() {
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++) {
			if (colliders[i].gameObject != gameObject) {
				m_Grounded = true;
			}
		}
	}


	public void Move(float move) {
		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl) {

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			if (move > 0 && !m_FacingRight) {
				// If the input is moving the player right and the player is facing left...
				Flip();
			} else if (move < 0 && m_FacingRight) {
				// Otherwise if the input is moving the player left and the player is facing right...
				Flip();
			}
		}
	}

    public void Jump(float jumpForce, bool canJump) {
        if (m_Grounded || canJump) {
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, jumpForce));
		}
    }

	private void Flip()	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}