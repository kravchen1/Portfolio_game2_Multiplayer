using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
public class LobbyManager_s : MonoBehaviourPunCallbacks
{
    public Text LogText;
    void Start()
    {
        PhotonNetwork.NickName = "Player " + Random.Range(1000, 9999);
        Log("Player`s name is set to " + PhotonNetwork.NickName);


        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        Log("Connected to Master");   
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null,new Photon.Realtime.RoomOptions { MaxPlayers = 5 });
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Log("Joined the room");

        PhotonNetwork.LoadLevel("Game");
    }

    private void Log(string message)
    {
        Debug.Log(message);
        LogText.text += "\n";
        LogText.text += message;
    }
}
