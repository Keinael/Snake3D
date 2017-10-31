using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SnakeMovement : MonoBehaviour {

	public float speed;
	public float rotationSpeed;
	public List<GameObject> tailObjects = new List<GameObject>();
	public GameObject tailPrefab;
	Vector3 newTailPos;
	public int accelTime;
	public int decelTime;

	void Start () {
		tailObjects.RemoveAt(0);
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

    public void AddTail () {
			if (tailObjects.Count == 0) {					 
				newTailPos = GameObject.FindGameObjectWithTag ("SnakeHead").transform.position;
			} else {			
				newTailPos = tailObjects [tailObjects.Count - 1].transform.position;
			}
		tailObjects.Add(GameObject.Instantiate(tailPrefab, newTailPos, Quaternion.identity) as GameObject);
	}	
		
	public void DecreaseTail () {
		Destroy(tailObjects[tailObjects.Count - 1]);        
		tailObjects.RemoveAt (tailObjects.Count - 1);        
	}
		
	public void TrigerChanger (GameObject myobject) {
		myobject.GetComponent<SphereCollider> ().isTrigger = !myobject.GetComponent<SphereCollider> ().isTrigger;
	}

	public void Redirection () {
		if (tailObjects.Count == 0) {
			gameObject.transform.Rotate (new Vector3 (0, 180f, 0));
		} else {
		Vector3 secondObjPosition = tailObjects [tailObjects.Count - 1].transform.position;
		TrigerChanger (gameObject);
		TrigerChanger (tailObjects [tailObjects.Count - 1]);
		gameObject.transform.position = secondObjPosition;
		gameObject.transform.Rotate(new Vector3(0, 180f, 0));
		TrigerChanger (gameObject);
		TrigerChanger (tailObjects [tailObjects.Count - 1]);
		tailObjects.Reverse();
		}
	}

	void AccelTimer () {		
		accelTime++;
		if (accelTime == 5) {
			CancelInvoke ("AccelTimer");
			speed -= 2;
		}
	}

	void DecelTimer () {			
		decelTime++;
		if (decelTime == 5) {
			CancelInvoke ("DecelTimer");
			speed += 2;
		}
	}

	public void Acceleration () {
		accelTime = 0;
		speed += 2;
		InvokeRepeating ("AccelTimer", 0, 1);			
	}

	public void Deceleration () {
		decelTime = 0;	
		Debug.Log (decelTime);
		speed -= 2;
		InvokeRepeating ("DecelTimer", 0, 1);
	}
}
