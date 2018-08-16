using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Enemy : MonoBehaviour {
    [SerializeField]
    protected int health;
    [SerializeField]
	protected float speed;
    [SerializeField]
    protected int gems;
	[SerializeField]
	protected float attackRange = 2f;
	[SerializeField]
	protected Transform pointA, pointB;
	[SerializeField]
	protected Transform startPoint;

	protected Vector3 m_currentTarget;
	protected SpriteRenderer m_spriteRenderer;
	protected Animator m_anim;

	protected bool isHit = false;

	//variable to store player
	protected GameObject m_player;

	void Start(){
		Init();

		if (startPoint != null && pointA != null) {
			m_currentTarget = startPoint.position;
		} else {
			m_currentTarget = transform.position;
		}

		if (m_anim == null) {
			Debug.LogError("The Enemy Script component reguires a Animator component on the " + transform.name +"'s first child object");
			return;
		}

		if (m_spriteRenderer == null) {
			Debug.LogError("The Enemy Script component reguires a SpriteRenderer conponent on the " + transform.name + "'s first child object");
			return;
		}
	}

	public virtual void Init(){

		m_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		m_anim = GetComponentInChildren<Animator>();
		m_player = FindObjectOfType<Player>().gameObject;
	}

	public virtual void Update(){
		// enemy can only move if not in idle state or combat
		if (m_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && m_anim.GetBool("InCombat") == false) {
			return;
		}

		Move();
	}

	public virtual void Move(){

		// Set enemy sprite in direction to move
		if (pointA != null && m_currentTarget.x == pointA.position.x) {
			m_spriteRenderer.flipX = true;

		} else {
			m_spriteRenderer.flipX = false;
		}

		// move the player between to waypoints
		if (pointB != null && transform.position == pointA.position) {

			m_currentTarget = pointB.position;
			m_anim.SetTrigger("Idle");

		}
		else if (pointA != null && transform.position == pointB.position) {

			m_currentTarget = pointA.position;
			m_anim.SetTrigger("Idle");

		}

		// freezes enemy movement when hit by player
		// by only moving enemy when player is out of reach for attack
		if (isHit == false && m_anim.GetBool("InCombat") == false) {
			transform.position = Vector3.MoveTowards(transform.position, m_currentTarget, speed * Time.deltaTime);
		}

		// check for distance between player and enemy
		// if distance > then float unfreeze enemy movement
		float _distance = Vector2.Distance(m_player.transform.localPosition, transform.localPosition);

		if (_distance >= attackRange) {
			isHit = false;
			m_anim.SetBool("InCombat", false);
		}

		//Flip Enemy sprite when in combat with player
		Vector2 _direction = m_player.transform.localPosition - transform.localPosition;

		if (m_anim.GetBool("InCombat") == true && _direction.x < 0f) {
			m_spriteRenderer.flipX = true;

		} else if (m_anim.GetBool("InCombat") == true && _direction.x > 0f) {
			m_spriteRenderer.flipX = false;
		}
	}

}
