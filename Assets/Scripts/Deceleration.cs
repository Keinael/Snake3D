using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deceleration : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("SnakeHead")) {
			other.GetComponent<SnakeMovement> ().Deceleration();
			Destroy (gameObject);
		}
	}
}
