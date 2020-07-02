using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject _controlPanel;
    [SerializeField]
    private GameObject _progressLabel;
    [SerializeField]
    private GameObject _startPanel;

    private string _gameVersion = "0.0.0";

    public void Start()
    {
        _controlPanel.SetActive(false);
        _progressLabel.SetActive(true);
        _startPanel.SetActive(false);

        PhotonNetwork.AutomaticallySyncScene = true;
        Debug.Log("Shearch connection...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        _progressLabel.SetActive(false);
        _controlPanel.SetActive(true);
        Debug.Log("Connected to Master.");
    }

    public void Connect()
    {
        _controlPanel.SetActive(false);
        _progressLabel.SetActive(true);

        PhotonNetwork.JoinOrCreateRoom("Game", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room Created.");
        _progressLabel.SetActive(false);
        _startPanel.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room Joined.");
        _progressLabel.SetActive(false);
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
