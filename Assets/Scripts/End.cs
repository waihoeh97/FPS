using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour {

	public bool reached;

	// Use this for initialization
	void Start () {
		reached = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			Debug.Log("Player");
			reached = true;
		}
	}
}
