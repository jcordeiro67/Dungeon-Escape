using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerAnimation))]

public class Player : MonoBehaviour, IDamageable, ICollectable{

	[SerializeField]
	private int m_diamonds = 0;

	[SerializeField]
	private int m_health = 10;
	// variable for move speed
	[SerializeField]
	private float m_speed = 5f;
	// variable for jump force
	[SerializeField]
	private float m_jumpForce = 5f;
	// layer of ground objects used for detection
	[SerializeField]
	private LayerMask m_groundLayer;

	// get handle for rigidbody
	private Rigidbody2D m_rBody2D;
	private Animator m_anim;
	private PlayerAnimation m_playerAnim;
	private SpriteRenderer m_playerSprite;
	private SpriteRenderer m_swordArcSprite;

	private bool m_resetJump = false;
	private bool m_isGrounded = false;

	public int Health { get; set;}
	public int Diamonds { get; set;}

	// Use this for initialization
	void Start () {

		Health = m_health;
		Diamonds = m_diamonds;
		Debug.Log("Player Health = " + Health.ToString());
		Debug.Log("Player Diamonds = " + Diamonds.ToString());
		// assign handle of rigidbody
		m_rBody2D = GetComponent<Rigidbody2D>();
		m_anim = GetComponentInChildren<Animator>();
		m_playerAnim = GetComponent<PlayerAnimation>();
		m_playerSprite = GetComponentInChildren<SpriteRenderer>();
		m_swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
		
		Move();
		Attack();
	}

	void Move() {
		// horizontal input for left/right
		float move = Input.GetAxisRaw("Horizontal");
		// check if player is grounded
		//TODO: move to update function so IsGrounded is only called once per frame 
		m_isGrounded = IsGrounded();

		// Flip Sprite in X if move is < 0
		if (move > 0) {
			FlipSprite(true);
		} else 
			if (move < 0) {
			FlipSprite(false);
		}
		

		// Jump
		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
			
			m_rBody2D.velocity = new Vector2(m_rBody2D.velocity.x, m_jumpForce);
			m_playerAnim.Jump(true);
			StartCoroutine(ResetJumpRoutine());
		}

		m_rBody2D.velocity = new Vector2(move * m_speed, m_rBody2D.velocity.y);
		m_playerAnim.Move(move);

	}

	void Attack()
	{
		if (Input.GetMouseButtonDown(0) && IsGrounded()) {
			m_playerAnim.Attack();
		}
	}

	void FlipSprite(bool faceRight)
	{
		if (m_playerSprite != null) {
			// facing right
			if (faceRight == true) {
				m_playerSprite.flipX = false;
				m_swordArcSprite.flipX = false;
				m_swordArcSprite.flipY = false;

				Vector3 newPos = m_swordArcSprite.transform.localPosition;
				newPos.x = Mathf.Abs(newPos.x);
				m_swordArcSprite.transform.localPosition = newPos;

				// faceing left
			} else if (faceRight == false) {
				m_playerSprite.flipX = true;
				m_swordArcSprite.flipX = false;
				m_swordArcSprite.flipY = true;

				Vector3 newPos = m_swordArcSprite.transform.localPosition;
				newPos.x = -0.8f;
				//newPos.x = newPos.x * -1;
				m_swordArcSprite.transform.localPosition = newPos;
			}
		}
	}

	bool IsGrounded(){
		
		RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, m_groundLayer);
		Debug.DrawRay(transform.position, Vector2.down, Color.green);
		if (hitInfo.collider != null) {
			if (!m_resetJump) {
				m_playerAnim.Jump(false);
				return true;
			}
		}

		return false;
	}

	IEnumerator ResetJumpRoutine(){

		m_resetJump = true;
		yield return new WaitForSeconds(0.2f);
		m_resetJump = false;
	}

	public void Damage()
	{
		Debug.Log("Player Hit: Damage() called");

		Health--;

		Debug.Log("Player Health = " + Health.ToString());

		if(Health < 1){
			m_anim.SetTrigger("Death");

		}

	}

	public void AddDiamonds(int value){

		Diamonds += value;
		Debug.Log("Player Diamonds = " + Diamonds.ToString());
	}
}
