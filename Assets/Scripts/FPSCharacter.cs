using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCharacter : MonoBehaviour {

	public float walkSpeed = 3f;

	const float maxHealth = 20f;
	public static float curHealth;

	public Text healthUI;
	string healthText;

	void Start ()
	{
		curHealth = maxHealth;
	}

	public void Move (Vector3 _direction)
	{
		this.transform.Translate (_direction * Time.deltaTime * walkSpeed, Space.Self);
	}

	public void TakeDamage ()
	{
		curHealth -= 2.0f;
	}

	void Update ()
	{
		healthUI.text = "" + curHealth;
	}
}
