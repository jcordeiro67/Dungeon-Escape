using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	private Animator m_animator;
	private Animator m_swordAnim;

	// Use this for initialization
	void Start () {
		m_animator = GetComponentInChildren<Animator>();
		// Get the animator from a child object not first in the hierarchy
		m_swordAnim = transform.GetChild(1).GetComponent<Animator>();
	}
	
	public void Move(float speed){

		if (m_animator != null) {
			m_animator.SetFloat("Speed", Mathf.Abs(speed));
		}
	}

	public void Jump(bool jumping){

		m_animator.SetBool("Jumping", jumping);
	}

	public void Attack(){

		m_animator.SetTrigger("Attack");
		m_swordAnim.SetTrigger("SwordAnimation");
	}
}
