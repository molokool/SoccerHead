using Photon.Pun;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float forceBounce = 20f;
    [SerializeField]
    private float forceShoot = 50f;

    private static int goalRed = 0;
    private static int goalBlue = 0;

    private Rigidbody2D rb;

    private Vector2 _velocity = Vector2.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    
    private void Update()
    {
        if (_velocity.magnitude < rb.velocity.magnitude)
        {
            _velocity = rb.velocity;
        }
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Ground collision");
            rb.AddForce(Vector2.up * _velocity.magnitude * forceBounce);
            _velocity = Vector2.zero;
        }
        else 
        {
            if (collision.gameObject.GetComponentInChildren<BoxCollider2D>().tag == "Foot")
            {
                Debug.Log("Foot collision");
                rb.AddForce(collision.contacts[0].normal * forceShoot);
            }
            else if (collision.gameObject.GetComponentInChildren<BoxCollider2D>().tag == "Head")
            {
                Debug.Log("Head collision");
                rb.AddForce(collision.contacts[0].normal * forceShoot);
            }
            else
            {
                Debug.Log("Collision with Unknown collider");
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("GoalRed"))
        {
            MoveBallToCountBlue();
            goalBlue++;
            GameManager.instance.InitializeBall();
        }
        if (collision.gameObject.tag.Equals("GoalBlue"))
        {
            MoveBallToCountRed();
            goalRed++;
            GameManager.instance.InitializeBall();
        }
    }

    private void MoveBallToCountRed()
    {
        float posX = 20 - 1.5f * goalRed;
        transform.position = new Vector3(posX, 14, 0);
        rb.simulated = false;
    }

    private void MoveBallToCountBlue()
    {
        float posX = -20 + 1.5f * goalBlue;
        transform.position = new Vector3(posX, 14, 0);
        rb.simulated = false;
    }
}
