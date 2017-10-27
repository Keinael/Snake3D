using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneration : MonoBehaviour {

	public GameObject foodPrefab;

	public float xSize = 8.9f;

	public float zSize = 8.9f;

	public GameObject curFood;

	public Vector3 curPos;


	void AddNewFood() {
		curPos = new Vector3 (Random.Range(xSize*-1,xSize),0.2f,Random.Range(zSize*-1,zSize));
		curFood = GameObject.Instantiate (foodPrefab, curPos, Quaternion.identity) as GameObject;	
	}

	void Update () {
		if (!curFood) {
			AddNewFood ();
		} else {
			return;
		}
	}
}
