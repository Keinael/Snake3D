using UnityEngine;

public class SnakeDecrease : MonoBehaviour {
	
	private void Start() {
		Destroy (gameObject, 10);
	}
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("SnakeHead")) {
			other.GetComponent<SnakeMovement>().DecreaseTail();
			Destroy (gameObject);
		}
	}
}
