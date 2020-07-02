using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Initialize();
    }

    public void Initialize()
    {
        InitializeBall();
        Instantiate(playerBluePrefab, spawnBlue.position, Quaternion.identity);
        Instantiate(playerRedPrefab, spawnRed.position, Quaternion.identity);
    }

    public void DestroyAll()
    {
        DestroyImmediate(ballPrefab);
        DestroyImmediate(playerBluePrefab);
        DestroyImmediate(playerRedPrefab);
    }

    public void InitializeBall()
    {
        Instantiate(ballPrefab, spawnBall.position, Quaternion.identity);
    }
}
