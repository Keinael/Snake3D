using UnityEngine;

public class Acceleration : MonoBehaviour {

	private void Start() {
		Destroy (gameObject, 10);
	}
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("SnakeHead")) {
			other.GetComponent<SnakeMovement>().Acceleration();
			Destroy(gameObject);
		}
	}
}
