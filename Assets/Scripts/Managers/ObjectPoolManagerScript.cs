using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PooledObjects
{
	PLAYER_BULLET = 0,
	ENEMY_BULLET,
}

[System.Serializable]
public class ObjectPool
{
	public int poolStartSize = 20;
	public int poolLimit = 40;
	public bool canExpand = false;

	public PooledObjects poolType;
	public GameObject poolObj;

	[HideInInspector]
	public List<GameObject> pooledObjects = new List<GameObject>();
}

public class ObjectPoolManagerScript : MonoBehaviour 
{
	private static ObjectPoolManagerScript mInstance;

	public static ObjectPoolManagerScript Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject[] tempObjectList = GameObject.FindGameObjectsWithTag("ObjectPoolManager");

				if(tempObjectList.Length > 1)
				{
					Debug.LogError("You have more than 1 Object Pool Manager in the Scene");
				}
				else if(tempObjectList.Length == 0)
				{
					GameObject obj = new GameObject("_ObjectPoolManager");
					mInstance = obj.AddComponent<ObjectPoolManagerScript>();
					obj.tag = "ObjectPoolManager";
				}
				else
				{
					if(tempObjectList[0] != null)
					{
						Debug.Log("Found a Object Pool manager");
						mInstance = tempObjectList[0].GetComponent<ObjectPoolManagerScript>();
					}
				}
				DontDestroyOnLoad(mInstance.gameObject);
			}
			return mInstance;
		}
	}

	public static ObjectPoolManagerScript CheckInstanceExist()
	{
		return mInstance;
	}

	public List<ObjectPool> objectPoolList = new List<ObjectPool>();

	// Use this for initialization
	void Start () 
	{
		ObjectPoolManagerScript.CheckInstanceExist();
		InitializeObjectPools();
	}

	public void InitializeObjectPools()
	{
		for (int i = 0; i < objectPoolList.Count; i++) 
		{
			ObjectPool curPool = objectPoolList[i];
			for( int j = 0; j < curPool.poolStartSize; j++)
			{
				GameObject obj = (GameObject)Instantiate(curPool.poolObj, Vector3.zero, Quaternion.identity);

				curPool.pooledObjects.Add(obj);
				obj.SetActive(false);
				DontDestroyOnLoad(obj);
			}
		}
	}

	//! Get your thing
	public GameObject GetPooledObject(PooledObjects findType)
	{
		for (int i = 0; i < objectPoolList.Count; i++) 
		{
			ObjectPool curPool = objectPoolList[i];
			if(curPool.poolType == findType)
			{
				for( int j = 0; j < curPool.pooledObjects.Count; j++)
				{
					if(curPool.pooledObjects[j].activeInHierarchy == false)
					{
						return curPool.pooledObjects[j];
					}
				}

				//! canExpand = true && count < limit
				if(curPool.canExpand == false)
				{
					return null;
				}
				else if(curPool.canExpand == true && curPool.pooledObjects.Count < curPool.poolLimit)
				{


					GameObject obj = (GameObject)Instantiate(curPool.poolObj, Vector3.zero, Quaternion.identity);
					curPool.pooledObjects.Add(obj);
					return obj;
				}
				else if(curPool.canExpand == true && curPool.pooledObjects.Count >= curPool.poolLimit)
				{
					return null;
				}

			}
		}

		Debug.LogError("Cannot find " + findType + " Pool");
		return null;
	}

	// Update is called once per frame
	void Update () 
	{

	}
}
