using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour{

	public int m_diamonds = 1;
	private Player m_player;

	void Start(){

		m_player = FindObjectOfType<Player>();

	}

	//Get number of diamond value from enemy script
	//OnTriggerEnter to collect
	void OnTriggerEnter2D(Collider2D other){
		//Check for player
		ICollectable hit = other.GetComponent<ICollectable>();

		if(hit != null && m_player != null){
			Debug.Log("Add Value of Diamond to player");
			//add the value of the diamond to the player using ICollectable interface
			m_player.AddDiamonds(m_diamonds);

			//TODO: Play Sound

			//Destroy Diamond
			Destroy(this.gameObject);
		}
	}


}
