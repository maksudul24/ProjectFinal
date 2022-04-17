using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class InvokeConnection : MonoBehaviourPunCallbacks
{
   public GameObject connectedScreen;
   public GameObject disConnectedScreen;
   public void OnClick_ConnectButton()
   {
       PhotonNetwork.ConnectUsingSettings();
       Debug.Log("Button is Clicked");
   }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        connectedScreen.SetActive(false);
        disConnectedScreen.SetActive(true);
    }
    public override void OnJoinedLobby()
    {
        if(disConnectedScreen.activeSelf){
            disConnectedScreen.SetActive(false);
        }
        connectedScreen.SetActive(true);
    }
    void Start()
    {
        connectedScreen.SetActive(false);
        disConnectedScreen.SetActive(true); 
    }


}
