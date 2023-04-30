using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    private Vector2 velocity;
    public bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && alive) {
            if (rb.position.y >= 3.5f) return; // do nothing
            rb.position += velocity * Time.deltaTime; // add
        } else if (Input.GetKey(KeyCode.DownArrow) && alive) {
            if (rb.position.y <= -3.5f) return; //do nothing
            rb.position -= velocity * Time.deltaTime; //subtract
        }

    }
}
