using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    public float jump;
    public bool canMove;
    public bool canJump;
    public float characterHeight;
    Rigidbody2D rb;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    public void goRight()
    {
        gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        animator.SetBool("isWalking", true);
        gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }

    public void goLeft()
    {
        gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        animator.SetBool("isWalking", true);
        gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }

    public void Jump()
    {
        rb.AddForce(new Vector2(0,jump));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.A)|| Input.GetAxis("Horizontal") < 0) && canMove)
        {
            goLeft();
            animator.SetBool("isWalking", true);
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0) && canMove)
        {
            goRight();
            animator.SetBool("isWalking", true);
        } 
    }

    void Update()
    {
        Vector2 position2d = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y); 
        if (Physics2D.Raycast(position2d - new Vector2(0,characterHeight/2), Vector2.down, 0.01f))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")) && canJump && canMove)
        {
            Jump();
        }
        if ((!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) && (Input.GetAxis("Horizontal") == 0))
        {
            animator.SetBool("isWalking", false);
        }
    }
}
