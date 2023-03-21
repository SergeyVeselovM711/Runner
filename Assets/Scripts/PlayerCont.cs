using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    public float moveSpeed;
    private float movespeedStore;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public float jumpForce;

    public float jumpTime;
    private float jumpTimeCounter;

    private bool stopJump;

    Rigidbody2D rb;
    //Collider2D col;

    public bool isTouched;
    public LayerMask border;
    public Transform groundCheck;
    public float groundCheckRadius;

    public GameManager theGameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // col = GetComponent<Collider2D>();

        speedMilestoneCount = speedIncreaseMilestone;

        speedIncreaseMilestoneStore = speedIncreaseMilestone;

        movespeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;

        jumpTimeCounter = jumpTime;

        stopJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        //isTouched = Physics2D.IsTouchingLayers(col, border); //проверка касания земли
        isTouched = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, border);


        if (transform.position.x > speedMilestoneCount) //постепенное увеличение скорости
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

        rb.velocity = new Vector2 (moveSpeed, rb.velocity.y); //постоянное движение вправо

        if (Input.GetKeyDown(KeyCode.Space)) //прыжок
        {
            if (isTouched)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                stopJump = false;

            }
        }

        if (Input.GetKey (KeyCode.Space) && !stopJump)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {

            jumpTimeCounter = 0;
            stopJump = true;

        }
        if (isTouched) 
        {
            jumpTimeCounter = jumpTime;
        }
           
    }
    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "killbox")
        {
            theGameManager.RestartGame();
            moveSpeed = movespeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }
    }
}
