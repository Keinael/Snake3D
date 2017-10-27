using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailMovement : MonoBehaviour {

	public float speed;

	public Vector3 tailTarget;   //Указывается позиция последнего элемента хвоста, за 
                                    //которым будет двигаться новый элемент
	public SnakeMovement mainSnake;
    
	public GameObject tailTargetObj;

	public int indx;
	// Use this for initialization
	void Start () 
	{		
		
        mainSnake = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<SnakeMovement>();
		speed = mainSnake.speed+1;
		tailTargetObj = mainSnake.tailObjects [mainSnake.tailObjects.Count - 2];
		indx = mainSnake.tailObjects.IndexOf (gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		tailTarget = tailTargetObj.transform.position;
		transform.LookAt (tailTarget);
		transform.position = Vector3.Lerp (transform.position, tailTarget, Time.deltaTime * speed);
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("SnakeHead")) {
			if (indx > 2) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
}
