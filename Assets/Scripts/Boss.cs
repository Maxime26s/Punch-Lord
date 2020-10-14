using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bosded, bosnotded;
    public Rigidbody2D rb;
    float startTime, time;
    public float speed,amp,frequence;
    public int cycle;
    Vector2 startPos;
    public Transform transform;
    bool reverse = false;
    public int lives;
    public int initialLives;
    public SpriteRenderer spriteRenderer;
    public

    // Start is called before the first frame update
    void Start()
    {
        initialLives = lives;
        startPos = transform.position;
        startTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsAlive())
        {
            time = Time.time - startTime;
            if (time <= cycle*(2*Mathf.PI/frequence))
            {
                if (!reverse)
                {
                    rb.MovePosition(new Vector2(startPos.x + time * speed, startPos.y + amp * Mathf.Sin(frequence * time)));
                    spriteRenderer.flipX = true;
                }
                else if (reverse)
                {
                    rb.MovePosition(new Vector2(startPos.x - time * speed, startPos.y + amp * Mathf.Sin(frequence * time)));
                    spriteRenderer.flipX = false;
                }  
            }
            else
            {
                reverse = !reverse;
                startTime = Time.time;
                startPos = transform.position;
            }
        }
 
        else
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("Die");
            GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.Find("TpPos").transform.position;
            bosded.SetActive(true);
            bosnotded.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public bool IsAlive()
    {
        return (lives > 0);
    }

    public void DisableInstance()
    {
        // Removes this script instance from the game object
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
