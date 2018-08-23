using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable{

	public int Health{ get; set;}

	[SerializeField]
	private GameObject acidEffectPrefab;
	[SerializeField]
	private Transform spawnPoint;

	// Used for Initilization
	public override void Init()
	{
		base.Init();
		Health = base.health;
	}

	public override void Move(){
		//Stay Still
	}

	public void Damage(){

		Health--;

		if (Health < 1) {
			Destroy(this.gameObject);
		}
	}

	public void Attack(){

		// Instantiate AcidEffect attack
		Instantiate(acidEffectPrefab, spawnPoint.position, Quaternion.identity);
	}

}
