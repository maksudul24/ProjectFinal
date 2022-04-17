using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class NetworkManager : MonoBehaviour {

	[SerializeField] List<GameObject> players = new List<GameObject>();
	public GameObject playerpref;
	public GameObject OfflinePlayerPref;
	public Transform spawnPoint;
	public GameObject enemySpawner;
	public GameObject lobbyCam;
	public GameObject lobbyUI;
	public GameObject inGameUI;
	public Text statusText;
	public PhotonView pv;
	public GameObject CentralObjective;
	// public List<GameObject> Players {
	// 	get {
	// 		return players;
	// 	}
	// }

	// public List<GameObject> playerlist;

	void Start() {

		Transform spawnPoint = PlayerSpawnScript.Instance.GetSpawnpoint();
		inGameUI.SetActive(true);
		if(CommonScript.isMultiplayer){
			lobbyCam.SetActive(false);
			lobbyUI.SetActive(false);
			GameObject pl = PhotonNetwork.Instantiate(playerpref.name, spawnPoint.position, spawnPoint.rotation, 0) as GameObject;
			pl.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
			pl.GetComponent<HealthManager>().enabled = true;
			pl.GetComponent<RewardText>().enabled = true;
			pl.GetComponent<LevelSystem>().enabled = true;
			pl.GetComponent<FundSystem>().enabled = true;
			pl.GetComponent<Player>().enabled = true;
			pl.transform.GetChild(0).gameObject.SetActive(true);
			if(CommonScript.isCO_Op){
				// if(pv.IsMine){
				// 	playerlist.Add(pl);
				// }
				Transform pnt = AntiVirusSpawnerArray.Instance.GetSpawnpoint();
       	 		PhotonNetwork.Instantiate(CentralObjective.name,pnt.position,pnt.rotation);
				enemySpawner.GetComponent<EnemySpawner>().target = CentralObjective;
				if(PhotonNetwork.IsMasterClient){
					enemySpawner.SetActive(true);

				}
			}
		}
		else{
			Debug.Log("game starting");
			lobbyCam.SetActive(false);
			lobbyUI.SetActive(false);
			GameObject playerObj = Instantiate(OfflinePlayerPref, spawnPoint.position, spawnPoint.rotation);
			// GameObject player = PhotonNetwork.Instantiate(playerName, spawnPoint.position, spawnPoint.rotation, 0);
			// players.Add(player);

			enemySpawner.SetActive(true);
			enemySpawner.GetComponent<EnemySpawner>().target = playerObj;
		}
	}

	// void Update() {
	// 	statusText.text = PhotonNetwork.connectionStateDetailed.ToString();
	// }
}
