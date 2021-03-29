using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class GameManager_s : MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefab;
    void Start()
    {
        Vector3 pos = new Vector3(Random.Range(-20f, 20f), 1, Random.Range(15f, 20f));
        PhotonNetwork.Instantiate(PlayerPrefab.name,pos,Quaternion.identity);
    }

    void Update()
    {
        
    }

    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        //Когда текущий игрок (мы) покидает комнату
        SceneManager.LoadScene(0);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player {0} entered room", newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player {0} left room", otherPlayer.NickName);
    }
}
