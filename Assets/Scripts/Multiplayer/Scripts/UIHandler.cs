using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class UIHandler : MonoBehaviourPunCallbacks
{
    public InputField createRoomTF;
    public InputField joinRoomTF;
    public string playerName = "Rabat";
    
    public void OnClick_CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoomTF.text,new RoomOptions{ MaxPlayers = 4},null);
    }

    public void OnClick_JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomTF.text,null);
    }
    
    public void OnClickBack(){
        SceneManager.LoadScene("StartMenu");
    }
    public override void OnJoinedRoom()
    {
        print("Room Join Success");
        PhotonNetwork.LoadLevel("Ingame");
        PhotonNetwork.NickName = playerName;
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("Room Join Failed " + returnCode +"Message: "+message);
    }

        //server list
    void OnGUI(){
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 250,Screen.height / 2 - 250,500,500));
        GUILayout.TextArea("Player Name(Optional)");
        playerName = GUILayout.TextArea(playerName);
        GUILayout.EndArea();
    }
}
