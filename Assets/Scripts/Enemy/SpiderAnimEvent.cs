using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimEvent : MonoBehaviour {
	
	// Handle to Spider Script
	private Spider _spider;

	void Start(){
		// Handle assignment to Spider Script
		_spider = GetComponentInParent < Spider>();
	}

	public void fire(){

		//Tell Spider to fire
		Debug.Log("Spider should fire");
		// use handle to call Attack on spider
		_spider.Attack();
	}
}
