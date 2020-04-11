using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public string collision;
    float position_x;
    float position_y;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        // input because reapeated less times
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
       
    }

    void FixedUpdate()
    {
        position_x = GetComponent<Rigidbody2D>().position.x;
        position_y = GetComponent<Rigidbody2D>().position.y;
        // movement because reapeated more times
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (position_x > 4.8)
        {
            transform.position = new Vector3(4.8f, position_y, 1f);
        }
        else if (position_x < -3.9)
        {
            transform.position = new Vector3(-3.9f, position_y, 1f);
        }
        else if (position_y > 3.68)
        {
            transform.position = new Vector3(position_x, 3.67f, 1f);
        }
        else if (position_y < -2.26)
        {
            transform.position = new Vector3(position_x, -2.26f, 1f);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {

        collision = col.gameObject.name;
    }
}
