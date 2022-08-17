using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField create;
    public InputField join;

    public void CreateRoom() {
        RoomOptions roomOption = new RoomOptions();
        roomOption.MaxPlayers = 10;
        PhotonNetwork.CreateRoom(create.text, roomOption);
    }
    public void JoinToRoom() {
        PhotonNetwork.JoinRoom(join.text);
    }
    public override void OnJoinedRoom() {
        PhotonNetwork.LoadLevel("MultyPlayer");
    }
}
