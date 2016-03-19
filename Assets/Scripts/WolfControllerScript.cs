using UnityEngine;
using System.Collections;


public class WolfControllerScript : MonoBehaviour {

  [SerializeField] float speed = 400f;
  [SerializeField] float m_MovingTurnSpeed = 360;
  [SerializeField] float m_StationaryTurnSpeed = 180;
  [SerializeField] float jumpForce = 400f;
  [SerializeField] LayerMask whatIsGround;
  [SerializeField] float m_GravityMultiplier = 2f;

  Rigidbody m_Rigidbody;
  Transform m_Trans;
  Vector3 movement;

  public float move = 1f;
  public float sideMove = 0.6f;
  float m_TurnAmount;
  float m_ForwardAmount;
  
	bool grounded = false;
	Transform groundCheck;
	float groundRadius = 0.2f;
	bool doubleJump = false;

  Vector3 sideDirection;

  void Awake() 
  {
    m_Trans = transform;
    groundCheck = transform.Find("GroundCheck");
    m_Rigidbody = GetComponent<Rigidbody>();
  }

  public void JumpButton(bool jump)
  {
    if ((grounded || !doubleJump) && jump)
    {
      m_Rigidbody.AddForce(new Vector3(0, jumpForce, 0));

      if (!grounded)
      {
        doubleJump = true;
      }
    }
  }

  public void Move(float horizontalInput)
  {
    movement = m_Rigidbody.velocity;
    if (grounded)
    {
      movement.x = horizontalInput * speed * Time.deltaTime;
    }
    m_Rigidbody.velocity = movement;
  }

  public void MoveLeft(bool moveLeft)
  {
    if (moveLeft)
    {

      transform.Translate(Vector3.left * 30 * Time.deltaTime);
    }
  }

  public void MoveRight(bool moveRight)
  {
    if (moveRight)
    {
      transform.Translate(Vector3.right * 30 * Time.deltaTime);
      //float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
      //m_Rigidbody.velocity = new Vector3(sideMove * speed * Time.fixedDeltaTime, m_Rigidbody.velocity.y, m_Rigidbody.velocity.z);
      //transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
    }
  }

  void FixedUpdate()
  {
    //grounded = Physics.Linecast(m_Trans.position, groundCheck.transform.position, );
    grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    m_ForwardAmount = move * speed * Time.fixedDeltaTime;
    m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_Rigidbody.velocity.y, m_ForwardAmount);
    transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));


    if (grounded)
    {
      doubleJump = false;
    }
    else
    {
      HandleAirborneMovement();
    }
      
  }

  void HandleAirborneMovement()
  {
    // apply extra gravity from multiplier:
    Vector3 extraGravityForce = (Physics.gravity * m_GravityMultiplier) - Physics.gravity;
    m_Rigidbody.AddForce(extraGravityForce);

   // m_GroundCheckDistance = m_Rigidbody.velocity.y < 0 ? m_OrigGroundCheckDistance : 0.01f;
  }

}
