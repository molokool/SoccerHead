using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float shootSpeed = 300f;
    public float jumpForce = 15f;
    public bool isGrounded = false;
    public float isRight = 1f;

    [SerializeField]
    private Transform foot;
    [SerializeField]
    private PhotonView PV;

    private Quaternion startRotation;

    private void Start()
    {
        startRotation = foot.rotation;
        PV = GetComponent<PhotonView>();
    }

    void Update()
    {
        Jump();
        Shoot();
        if (PV.IsMine)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * moveSpeed * Time.deltaTime;
        }
    }

    private void Jump()
    {
        if (PV.IsMine)
        {
            if (Input.GetButtonDown("Jump") && isGrounded == true)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    private void Shoot()
    {
        if (PV.IsMine)
        {
            if (Input.GetButton("Fire1"))
            {
                foot.Rotate(Vector3.forward, isRight * Time.deltaTime * shootSpeed);
            }
            if (Input.GetButtonUp("Fire1"))
            {
                foot.rotation = startRotation;
            }
        }
    }
}
