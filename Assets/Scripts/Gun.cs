using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public Camera fpsCam;

	public float damage = 10f;
	public float range = 50f;
	public float impactForce = 30f;

	public GameObject impactEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Shoot ()
	{
		RaycastHit hit;
		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
		{
			Debug.Log(hit.transform.name);

			Enemy enemy = hit.transform.GetComponent<Enemy>();
			if (enemy != null)
			{
				enemy.TakeDamage(damage);
			}

			if (hit.rigidbody != null)
			{
				hit.rigidbody.AddForce(hit.normal * impactForce);
			}

			GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy (impactGO, 2f);

			Bullet bullet = hit.transform.GetComponent<Bullet>();
			if (bullet != null)
			{
				Destroy(bullet.gameObject);
			}
		}
		SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_SHOOT);
	}
}
