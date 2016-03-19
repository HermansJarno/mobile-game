using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

  [SerializeField] float m_GravityMultiplier = 1.5f;
  [SerializeField] LayerMask whatIsGround;
  public float forwardSpeed = 400;
  public float sideSpeed = 10, jumpForce = 400;
  Transform groundCheck;
  Transform myTrans;
  Rigidbody myBody;
  float hInput = 0;
  float m_ForwardAmount;

  public bool grounded = false;
  bool doubleJump = false;

	// Use this for initialization
	void Start () {
    groundCheck = transform.Find("GroundCheck");
    myBody = GetComponent<Rigidbody>();
    myTrans = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
    grounded = Physics.Linecast(myTrans.position, groundCheck.position, whatIsGround);
    if (grounded)
    {
      doubleJump = false;
    }
    else
    {
      HandleAirborneMovement();
    }

#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT
    //Move(Input.GetAxisRaw("Horizontal"));
    //if (Input.GetButtonDown("Jump"))
    //{
    //  Jump();
    //}
#else

    Move(hInput);
#endif
  }

  public void StartMovingSideWays(float horizontalInput)
  {
    hInput = horizontalInput;
  }

  public void Move(float horizontalInput)
  {
    Vector3 moveVel = myBody.velocity;
    moveVel.x = horizontalInput * sideSpeed;
    moveVel.z = forwardSpeed * Time.deltaTime;
    myBody.velocity = new Vector3(moveVel.x, myBody.velocity.y, moveVel.z);
    myBody.rotation = Quaternion.Euler(0, 0, 0);
  }

  void HandleAirborneMovement()
  {
    // apply extra gravity from multiplier:
    Vector3 extraGravityForce = (Physics.gravity * m_GravityMultiplier) - Physics.gravity;
    myBody.AddForce(extraGravityForce);

    // m_GroundCheckDistance = m_Rigidbody.velocity.y < 0 ? m_OrigGroundCheckDistance : 0.01f;
  }

  public void Jump()
  {
    if (grounded || !doubleJump)
    {
      myBody.AddForce(new Vector3(0, jumpForce, 0));

      if (!grounded)
      {
        doubleJump = true;
      }
    }
  }
}
