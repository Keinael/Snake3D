using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redirection : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("SnakeHead")) {
//			other.GetComponent<SnakeMovement> ().Redirection ();
			Destroy (gameObject);
		}
	}
}
