using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeDecrease : MonoBehaviour {
	
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("SnakeHead")) {
			other.GetComponent<SnakeMovement>().DecreaseTail();
			Destroy (gameObject);
		}
	}
}
