using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailMovement : MonoBehaviour {

	public float speed;
	public Vector3 tailTarget;   
	public SnakeMovement mainSnake;    
	public GameObject tailTargetObj;
	public int indx;
	public bool currentDirection;



	void Start () {
		currentDirection = true;
		mainSnake = GameObject.FindGameObjectWithTag ("SnakeHead").GetComponent<SnakeMovement> ();	
		indx = mainSnake.tailObjects.IndexOf (gameObject);
		Direction ();
	}	

	void Update () {	
		speed = mainSnake.speed + 1;
		tailTarget = tailTargetObj.transform.position;
		transform.LookAt (tailTarget);
		transform.position = Vector3.Lerp (transform.position, tailTarget, Time.deltaTime * speed);
	}	

	void Direction () {
		if (mainSnake.tailObjects.Count <= 2) {
			tailTargetObj = GameObject.FindGameObjectWithTag ("SnakeHead");
		} else {
			tailTargetObj = mainSnake.tailObjects [mainSnake.tailObjects.Count - 2];
		}
	}

	public void DecreaseTail() {
		Destroy(mainSnake.tailObjects[mainSnake.tailObjects.Count - 1]);        
		mainSnake.tailObjects.RemoveAt (mainSnake.tailObjects.Count - 1);        
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("SnakeHead")) {
			if (indx > 2) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
}
