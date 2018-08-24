using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable {

	public int Health{ get; set;}

	// Used for Initilization
	public override void Init()
	{
		base.Init();

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
