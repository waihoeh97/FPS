using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject player;
	public GameObject enemyBullet;

	float health = 50f;
	float speed = 2.0f;
	float delta = 1.5f;
	float shootDelay = 0.5f;
	float lastShoot;

	Vector3 startPos;

	void Start ()
	{
		startPos = transform.position;
		speed = Random.Range (1.0f, 5.0f);
	}

	public void TakeDamage (float amount)
	{
		health -= amount;
		if (health <= 0f)
		{
			Die();
		}
	}

	public void Die ()
	{
		SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_DAMAGE);
		this.gameObject.SetActive(false);
	}

	void Update ()
	{
		// Movement
		Vector3 v = startPos;
		v.x += delta * Mathf.Sin (Time.time * speed);
		transform.position = v;

		// Shoot
		if (Time.time > shootDelay + lastShoot)
		{
			Instantiate (enemyBullet, transform.position, transform.rotation);
			lastShoot = Time.time;
		}

	}	
}
