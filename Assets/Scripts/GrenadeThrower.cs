using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour {

	public float throwForce = 10f;
	public GameObject grenade;

	public Vector3 offset = new Vector3(0f, 2f, 0f);

	// Use this for initialization
	void Start () {
		
	}

	public void ThrowGrenade ()
	{
		GameObject grenadeGO = Instantiate (grenade, offset, transform.rotation);
		Rigidbody rb = grenadeGO.GetComponent<Rigidbody>();
		rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
