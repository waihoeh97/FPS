using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class opening : MonoBehaviour {

	float time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		time = Time.time;

		if (time >= 1.0f) { 
			GetComponent<Text> ().enabled = false;
		}
	}
}
