using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable {

	public int Health{ get; set;}
	public int height = 5;

	// Used for Initilization
	public override void Init()
	{
		base.Init();
		Health = base.health;
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
			Destroy(this.gameObject);
		}
	}
}
