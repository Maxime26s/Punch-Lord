using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject other;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject != collision.gameObject.GetComponent<Player>().portalCD)
        {
            collision.gameObject.GetComponent<Player>().portalCD = other;
            collision.gameObject.transform.position = other.transform.position;
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = other.transform.up.normalized*rb.velocity.magnitude;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject == collision.gameObject.GetComponent<Player>().portalCD)
        {
            collision.gameObject.GetComponent<Player>().portalCD = null;
        }
    }
}
