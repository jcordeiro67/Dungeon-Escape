using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AcidEffect : MonoBehaviour {
	[SerializeField]
	[Tooltip("Speed, Float, The Speed the object travels")]
	private float _speed = 5f;
	[SerializeField]
	[Tooltip("Destroy after Seconds, Float, Destroys the gameObject after n Seconds")]
	private float _destroyAfterSec = 2.5f;
	[SerializeField]
	[Tooltip("Scale Over Time, Float, Scales the gameObject over Time")]
	private float _scaleOverTime = 1f;
	[SerializeField]
	[Tooltip("UpScale, Vector3, Scales the gameObject Up over scaleOverTime")]
	private Vector3 _upScale = new Vector3(1, 1, 1);


	void Start(){
		//scale acidEffect over time
		StartCoroutine(ScaleOverTime(_destroyAfterSec));
		//destroy acidEffect after 5 sec
		Destroy(this.gameObject, _scaleOverTime);
	}

	void Update(){
		
		//move constantly to the right at 3 meters per second
		transform.Translate(Vector3.right * _speed * Time.deltaTime);

	}

	//detect player hit and apply damage (IDamagable interface)
	void OnTriggerEnter2D(Collider2D other){
		// if hit player
		if (other.gameObject.tag == "Player") {
			// get IDamagable contract
			IDamageable hit = other.GetComponent < IDamageable>();
			// if player has IDamagable call damage and destroy this gameobject
			if (hit != null) {
				Debug.Log("Hit: " + other.name);
				hit.Damage();
				Destroy(this.gameObject);
			}
		}
	}

	//Coroutine to Scale AcidEffect's transform over time
	IEnumerator ScaleOverTime(float time){
		//Variables for coroutine
		Vector3 originalScale = transform.localScale;
		Vector3 destinationScale = _upScale;

		float currentTime = 0.0f;

		do {
			transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);

			currentTime += Time.deltaTime;
			yield return null;

		} while (currentTime <= time);
	}

}
