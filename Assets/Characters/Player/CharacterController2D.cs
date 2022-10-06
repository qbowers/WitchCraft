using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour {
	// Amount of force added when the player jumps.
	[SerializeField] public float jumpForce = 400f;

    [SerializeField] public float runSpeed = 0f;

	// How much to smooth out the movement
	[SerializeField] [Range(0, .3f)] float movementSmoothing = .05f;

	// Whether or not a player can steer while jumping;
	[SerializeField] bool airControl = false;

	// A mask determining what is ground to the character
	[SerializeField] LayerMask whatIsGround;

	// A position marking where to check if the player is grounded.
	[SerializeField] Transform groundCheck;



	// Radius of the overlap circle to determine if grounded
	const float groundedRadius = .2f;
	// Whether or not the player is grounded.
	public bool grounded;

	// new indicates we override the given rigidbody2D
	private new Rigidbody2D rigidbody2D;
	// private Vector3 velocity = Vector3.zero;

	// For determining which way the player is currently facing.
	// public bool m_FacingRight = true;
	public Vector3 directionScaleVector;
	public Vector3 leftScaleVector = new Vector3(-1,1,1);
	public Vector3 rightScaleVector = new Vector3(1,1,1);

	
	void Start() {
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	bool CheckGrounded() {
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
		for (int i = 0; i < colliders.Length; i++) {
			if (colliders[i].gameObject != gameObject) {
				return true;
			}
		}

		return false;
	}

	void FixedUpdate() {
		grounded = CheckGrounded();
		Move();
	}


	Vector2 targetVelocity = Vector2.zero;
	public void MoveInput(float move) {
		targetVelocity = new Vector2(move * runSpeed * Time.fixedDeltaTime, rigidbody2D.velocity.y);

		if (Mathf.Abs(move) > 0) FaceRight(move > 0);
	}
	public void Move() {
		//only control the player if grounded or airControl is turned on
		if (grounded || airControl) {
			rigidbody2D.velocity = Vector3.Lerp(rigidbody2D.velocity, targetVelocity, Time.fixedDeltaTime/movementSmoothing);
		}
	}

    public void Jump(bool canJump) {
        if (grounded || canJump) {
			// Add a vertical force to the player.
			grounded = false;
			ApplyForce(new Vector2(0f, jumpForce));
		}
    }

	public void ApplyForce(Vector2 force) {
		rigidbody2D.AddForce(Vector3.Scale(force, directionScaleVector));
	}


	void FaceRight(bool right) {
		float factor = right ? 1:-1;
		Vector3 scale =  transform.localScale;
		scale.x = Mathf.Abs(scale.x) * factor;

		transform.localScale = scale;
		directionScaleVector = right ? rightScaleVector:leftScaleVector;
	}
}