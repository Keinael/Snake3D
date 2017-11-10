using UnityEngine;

public class Redirection : MonoBehaviour {

	private void Start() {
		Destroy (gameObject, 10);
	}
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("SnakeHead"))
		{
			other.GetComponent<SnakeMovement>().Redirection();
			Destroy(gameObject);
		}
	}
}
