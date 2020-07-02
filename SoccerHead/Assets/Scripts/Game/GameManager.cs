using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private Ball ballPrefab;

    [SerializeField]
    private GameObject playerBluePrefab;
    [SerializeField]
    private GameObject playerRedPrefab;

    [SerializeField]
    private Transform spawnBall;
    [SerializeField]
    private Transform spawnBlue;
    [SerializeField]
    private Transform spawnRed;

    private void Start()
    {
        instance = this;
        InitializeAll();
    }

    public void InitializeAll()
    {
        InitializeBall();
        if (PhotonNetwork.IsMasterClient)
            PhotonNetwork.Instantiate(playerBluePrefab.name, spawnBlue.position, Quaternion.identity);
        else
            PhotonNetwork.Instantiate(playerRedPrefab.name, spawnRed.position, Quaternion.identity);
    }

    public void InitializeBall()
    {
        Instantiate(ballPrefab, spawnBall.position, Quaternion.identity);
    }
}
