using UnityEngine;

public class PlayerSpawnScript : MonoBehaviour
{
    public static PlayerSpawnScript Instance;
    TempSpawnPoint1[] spawnpoint;

    void Awake()
	{
		Instance = this;
		spawnpoint = GetComponentsInChildren<TempSpawnPoint1>();
	}

	public Transform GetSpawnpoint()
	{
		return spawnpoint[Random.Range(0, spawnpoint.Length)].transform;
	}  


}