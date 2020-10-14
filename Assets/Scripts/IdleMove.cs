using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMove : MonoBehaviour
{

    public float translateX, translateY;
    public Interactible inter;
    public float moveTime;
    private bool reversed;
    private Vector3 posInit;
    // Start is called before the first frame update
    void Start()
    {
        //StartMove();
        posInit = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x <= posInit.x && transform.position.y <= posInit.y)
        {
            reversed = false;
        }
        if (transform.position.x >= posInit.x+translateX && transform.position.y >= posInit.y+translateY)
        {
            reversed = true;
        }
        if (!reversed)
        {
            transform.Translate((new Vector3(translateX / 5, translateY / 5, 0))*Time.deltaTime*moveTime);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (reversed)
        {
            transform.Translate((new Vector3(-translateX / 5, -translateY / 5, 0)) * Time.deltaTime*moveTime);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    /*
    IEnumerator StartMove()
    {

        yield return new WaitForSeconds(1);
        //MoveToTarget(this.transform.position + new Vector3(-translateX, -translateY, 0));
        transform.Translate((transform.position + new Vector3(translateX, translateY, 0))*Time.deltaTime);
    }

    IEnumerator StartMoveRight()
    {
        yield return new WaitForSeconds(1);
        MoveToTarget(this.transform.position + new Vector3(translateX,translateY,0));
    }

    void MoveToTarget(Vector3 targetPosition)
    {
        Vector3 currentPosition = this.transform.position;
        
            Vector3 directionOfTravel = targetPosition - currentPosition;
            directionOfTravel.Normalize();
            this.transform.Translate(
                            (directionOfTravel.x * inter.idleSpeed * Time.deltaTime),
                            (directionOfTravel.y * inter.idleSpeed * Time.deltaTime),
                            (directionOfTravel.z * inter.idleSpeed * Time.deltaTime),
                            Space.World);
    }
    */
}
