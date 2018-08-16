using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	public float hitDelay = 0.5f;
	// variable to determine if the damage function can be called
	private bool _canDamage = true;


	void OnTriggerEnter2D(Collider2D other){
		
		Debug.Log("hit: " + other.name);
		IDamageable hit = other.GetComponent < IDamageable>();

		if (hit != null) {
			// if can attack
			if (_canDamage == true) {
				hit.Damage();
				_canDamage = false;
				StartCoroutine(damagePause());
			}
		}
	}

	// Coroutine to switch variable back to true after 0.5 seconds
	IEnumerator damagePause(){
		
		yield return new WaitForSeconds(hitDelay);
		_canDamage = true;
	}
}
