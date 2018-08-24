using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable{

	public int Health{ get; set;}

	[SerializeField]
	private GameObject m_acidEffectPrefab;
	[SerializeField]
	private Transform m_spawnPoint;

	// Used for Initilization
	public override void Init()
	{
		base.Init();
		Health = base.m_health;
	}

	public override void Update(){
		//Override the enemy update function

	}

	public override void Move(){
		//Stay Still
	}

	public void Damage(){

		Health--;
		m_anim.SetBool("InCombat", true);

		if (Health < 1) {
			m_anim.SetTrigger("Death");
			isDead = true;
			m_collider.enabled = false;
			//Destroy(this.gameObject);
		}
	}

	public void Attack(){

		// Instantiate AcidEffect attack
		Instantiate(m_acidEffectPrefab, m_spawnPoint.position, Quaternion.identity);
	}

}
