using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public FPSCharacter player;

	float speed = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.back * speed * Time.deltaTime);
		Destroy(this.gameObject, 2f);
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Wall" || col.gameObject.tag == "EnemyBullet")
		{
			Destroy(gameObject);
		}
		if (col.gameObject.tag == "Player")
		{
			player.TakeDamage();
			Destroy(gameObject);
		}
	}
}
