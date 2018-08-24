using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable {

	public int Health{ get; set;}
	public int m_height = 5;

	// Used for Initilization
	public override void Init()
	{
		base.Init();
		//Debug.Log("MossGiant Collider: " + m_collider.GetType().ToString()); 
		Health = base.m_health;
	}

	public override void Move(){
		base.Move();
	}

	public void Damage(){

		Health--;
		m_anim.SetTrigger("Hit");
		isHit = true;
		m_anim.SetBool("InCombat", true);

		if (Health < 1) {
			m_anim.SetTrigger("Death");
			isDead = true;
			m_collider.enabled = false;
			//Destroy(this.gameObject);
		}
	}
}
