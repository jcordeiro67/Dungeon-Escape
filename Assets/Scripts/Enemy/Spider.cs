using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable{

	public int Health{ get; set;}

	// Used for Initilization
	public override void Init()
	{
		base.Init();
		Health = base.health;
	}

	public override void Move(){
		
	}

	public void Damage(){

		Health--;

		if (Health < 1) {
			Destroy(this.gameObject); 
		}
	}

}
