using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("SnakeHead")) {
			other.GetComponent<SnakeMovement> ().Acceleration();
			Destroy (gameObject);
		}
	}
}
