using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinmovement : MonoBehaviour
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
        gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }

    public void goLeft()
    {
        gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }

    public void Jump()
    {
        rb.AddForce(new Vector2(0,jump));
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void Update()
    {
        Vector2 position2d = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y); 
        if (Physics2D.Raycast(position2d - new Vector2(0,characterHeight/2), Vector2.down, characterHeight))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }
}
