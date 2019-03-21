using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour 
{
	private static GameManagerScript mInstance;

	public static GameManagerScript Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject[] tempObjectList = GameObject.FindGameObjectsWithTag("GameManager");

				if(tempObjectList.Length > 1)
				{
					Debug.LogError("You have more than 1 Game Manager in the Scene");
				}
				else if(tempObjectList.Length == 0)
				{
					GameObject obj = new GameObject("_GameManager");
					mInstance = obj.AddComponent<GameManagerScript>();
					obj.tag = "GameManager";
				}
				else
				{
					if(tempObjectList[0] != null)
					{
						Debug.Log("Found a game manager");
						mInstance = tempObjectList[0].GetComponent<GameManagerScript>();
					}
				}
			}
			return mInstance;
		}
	}

	public GameObject gameOver;
	public GameObject win;
	public End endScript;

	// Use this for initialization
	void Start () 
	{
		SoundManagerScript.Instance.PlayBGM (SoundManagerScript.AudioClipID.BGM_MAINLEVEL);
		gameOver.SetActive (false);
		win.SetActive (false);
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit ();
		}

		if (FPSCharacter.curHealth <= 0) 
		{
			gameOver.SetActive (true);
		}
		if (endScript.reached == true) 
		{
			win.SetActive (true);
		}
	}
}
