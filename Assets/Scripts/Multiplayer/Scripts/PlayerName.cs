using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public Text nameTag;
    
    [PunRPC]
    public void updateName(string name){
        nameTag.text = name;
    }

}
