using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float gravity = 300f;

    private static int goalRed = 0;
    private static int goalBlue = 0;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        rb.AddForce(collision.contacts[0].normal * gravity);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("GoalRed"))
        {
            Debug.Log("Blue => BUUUUUUUUUUUUUUUUUUUUUT");
            MoveBallToCountBlue();
            goalBlue++;
            Debug.Log(goalBlue);
            GameManager.instance.InitializeBall();
        }
        if (collision.gameObject.tag.Equals("GoalBlue"))
        {
            Debug.Log("Red => BUUUUUUUUUUUUUUUUUUUUUT");
            MoveBallToCountRed();
            goalRed++;
            Debug.Log(goalRed);
            GameManager.instance.InitializeBall();
        }
    }

    private void MoveBallToCountRed()
    {
        float posX = 20 - 1.5f * goalRed;
        transform.position = new Vector3(posX, 14, 0);
        Destroy(rb);
        Destroy(GetComponent<PhotonTransformView>());
        Destroy(GetComponent<PhotonView>());
    }

    private void MoveBallToCountBlue()
    {
        float posX = -20 + 1.5f * goalBlue;
        transform.position = new Vector3(posX, 14, 0);
        Destroy(rb);
        Destroy(GetComponent<PhotonTransformView>());
        Destroy(GetComponent<PhotonView>());
    }
}
