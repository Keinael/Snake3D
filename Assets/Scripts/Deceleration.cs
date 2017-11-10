using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deceleration : MonoBehaviour {

	private void Start() {
		Destroy (gameObject, 10);
	}
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("SnakeHead")) {
			other.GetComponent<SnakeMovement> ().Deceleration();
			Destroy (gameObject);
		}
	}
}
