using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
	int time = 0;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Timer", 0, 1);
	}

	void Timer () {
		time++;
		Debug.Log(time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
