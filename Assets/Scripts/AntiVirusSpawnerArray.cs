using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiVirusSpawnerArray : MonoBehaviour
{
    public static AntiVirusSpawnerArray Instance;
    TempSpawnPoint2[] spawnpoints;

    void Awake()
	{
		Instance = this;
		spawnpoints = GetComponentsInChildren<TempSpawnPoint2>();
	}

	public Transform GetSpawnpoint()
	{
		return spawnpoints[Random.Range(0, spawnpoints.Length)].transform;
	}  

}
