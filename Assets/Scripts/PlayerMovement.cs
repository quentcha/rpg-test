using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public string border = "unknown";
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
        // movement because reapeated more times
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (GetComponent<Rigidbody2D>().position.x > 4.8)
        {
            border = "x right";
        }
        else if (GetComponent<Rigidbody2D>().position.x < -3.9)
        {
            border = "x left";
        }
        /*
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        */
        

    }
}
