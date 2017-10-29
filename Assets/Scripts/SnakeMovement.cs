using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SnakeMovement : MonoBehaviour {

	public float speed;
	float speedOld;

	public float rotationSpeed;
	public List<GameObject> tailObjects = new List<GameObject>();
	public GameObject tailPrefab;
	Vector3 newTailPos;

	public int accelTime;
	public int decelTime;

	void Start () {
		speedOld = speed;
	}

	void Update () {
		
		transform.Translate (Vector3.forward * speed * Time.deltaTime);

		if (Input.GetKey (KeyCode.D)) 
		{			
			transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.A)) 
		{
			transform.Rotate (Vector3.down * rotationSpeed * Time.deltaTime);
		}
	}

    public void AddTail() {	
		
		if (tailObjects.Count == 1) {					 
			newTailPos = GameObject.FindGameObjectWithTag("SnakeHead").transform.position;
		}
		else {			
			newTailPos = tailObjects [tailObjects.Count-1].transform.position;
		}
		tailObjects.Add(GameObject.Instantiate(tailPrefab, newTailPos, Quaternion.identity) as GameObject);
	}	

	void AccelTimer() {		
		accelTime++;
		if (accelTime == 5) {
			CancelInvoke ("AccelTimer");
			speed -= 2;
		}
	}

	public void DecelTimer() {			
		decelTime++;
		if (decelTime == 5) {
			CancelInvoke ("DecelTimer");
			speed += 2;
		}
	}

	public void Acceleration() {
		accelTime = 0;
		speed += 2;
		InvokeRepeating ("AccelTimer", 0, 1);			
	}

	public void Deceleration() {
		decelTime = 0;	
		Debug.Log (decelTime);
		speed -= 2;
		InvokeRepeating ("DecelTimer", 0, 1);
	}
}
