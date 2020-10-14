using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampo : MonoBehaviour
{
    Animator animator;
    public float bouncy;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            IEnumerator Stop()
            {
                yield return new WaitForSeconds(0.5009f);
                animator.Play("New State");
            }
            StopCoroutine(Stop());
            animator.Play("New State");
            animator.Play("interact");
            StartCoroutine(Stop());
            collision.gameObject.GetComponent<Player>().Jump(transform.up*bouncy);
        }

    }
}
