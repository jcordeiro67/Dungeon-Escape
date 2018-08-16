using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable {

	public int Health{ get; set;}

	// Used for Initilization
	public override void Init()
	{
		base.Init();

		Health = base.health;

	}

	public void Damage(){
		
		Health--;
		m_anim.SetTrigger("Hit");
		isHit = true;
		m_anim.SetBool("InCombat", true);

		if (Health < 1) {
			Destroy(this.gameObject);
		}
	}

	public override void Move(){
		base.Move();
	}

	public void Death(){

		m_anim.SetTrigger("Death");
		Destroy(this.gameObject);
	}
}
