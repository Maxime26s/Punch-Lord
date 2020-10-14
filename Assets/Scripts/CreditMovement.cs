using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditMovement : MonoBehaviour
{
    public float speed;
    public bool canMove;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void goRight()
    {
        gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        animator.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isWalking", false);
        if (canMove)
        {
            goRight();
        }
    }
}
