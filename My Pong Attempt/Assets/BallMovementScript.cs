using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementScript : MonoBehaviour
{
    public float speed = 5f; 
    public Rigidbody2D rb;
    private Vector2 velocity;
    private LogicScript logic;
    public GameObject player;
    private PlayerMovementScript playerScript;
    public GameObject opponent;
    private PaddleScript opponentScript;
    private bool win;
    public bool movingUp;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerMovementScript>();
        opponentScript = opponent.GetComponent<PaddleScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        rb = GetComponent<Rigidbody2D>();

        // get a random angle
        float randAngle = Random.Range(Mathf.PI / 12, Mathf.PI / 4);
        Debug.Log(randAngle);

        // randomly pick between 1 or -1 for the sign
        int signX = Random.Range(0,2) == 0 ? -1 : 1;
        int signY = Random.Range(0,2) == 0 ? -1 : 1;

        // get x and y velocity
        float x = signX * Mathf.Cos(Mathf.PI / 6);
        float y = signY * Mathf.Sin(Mathf.PI / 6);
        
        // set velocity and boolean for moving up
        velocity = new Vector2(x, y) * speed;
        movingUp = y > 0;
    }

    // Update is called once per frame
    void Update()
    {
        // move body
        rb.position += velocity * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collision detected!");
        if (other.collider.CompareTag("HorizontalBound")) {
            Debug.Log("Change vertical velocity of ball");
            velocity.y *= -1;
            movingUp = !movingUp; // change boolean for vertical movement
        } else if (other.collider.CompareTag("VerticalBound")) {
            Debug.Log("Changed horizontal velocity of ball");
            velocity.x *= -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        velocity = new Vector2(0,0);
        playerScript.alive = false;
        opponentScript.alive = false;

        if (other.gameObject.tag == "LeftEndzone") {
            logic.win();
        } else {
            logic.lose();
        }
    }
}
