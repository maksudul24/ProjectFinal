using UnityEngine;
using Photon.Pun;
public class NetworkDriver : MonoBehaviour
{
	public Transform spawnPoint;
	public GameObject playerPref;

	public GameObject cam;
	void Start()
	{	
			cam.SetActive(false);
			spawnPlayer();
	}

    public void spawnPlayer(){
	    GameObject pl =  PhotonNetwork.Instantiate (playerPref.name, spawnPoint.position, spawnPoint.rotation, 0) as GameObject;
		pl.GetComponent<RigidbodyFPSWalker> ().enabled = true;
		pl.GetComponent<PlayerMotor>().enabled = true;
		// pl.GetComponent<Animation>().enabled = true;
		// pl.GetComponent<AnimControl>().enabled = true;
		pl.transform.GetChild(0).gameObject.SetActive(true);
		pl.transform.GetChild(1).gameObject.SetActive(false);
		
 
	}
}
