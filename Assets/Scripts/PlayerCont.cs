using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    Rigidbody2D rb;
    Collider2D col;

    public bool isTouched;
    public LayerMask border;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouched = Physics2D.IsTouchingLayers(col, border); //проверка касания земли

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y); //постоянное движение вправо

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Space)) //прыжок
        {
            if (isTouched)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            }
        }
    }
}
