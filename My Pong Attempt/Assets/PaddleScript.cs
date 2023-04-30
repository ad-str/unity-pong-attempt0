using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{

    public GameObject screenBound;
    private Rigidbody2D rb;
    public float speed = 5f;
    private Vector2 velocity;
    public bool alive = true;
    public GameObject ballObject;
    private BallMovementScript ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = ballObject.GetComponent<BallMovementScript>();
        rb = GetComponent<Rigidbody2D>();
        velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (alive) {
            if (!ball.movingUp && rb.position.y > -3.5f) {
                rb.position -= velocity * Time.deltaTime;
            } else if (ball.movingUp && rb.position.y < 3.5f) {
                rb.position += velocity * Time.deltaTime;
            }
        }
    }
}