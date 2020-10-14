using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public GameObject empty;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.gameObject.GetComponent<Player>().grabbing)
        {
            collision.gameObject.GetComponent<Player>().grabbing = false;
            GameObject point = Instantiate(empty, collision.gameObject.transform.position, Quaternion.identity, gameObject.transform);
            Destroy(point, 3);
            IEnumerator Ungrab(GameObject lol)
            {
                yield return new WaitForSeconds(3);
                if(collision.gameObject.GetComponent<Player>().rope == point)
                    collision.gameObject.GetComponent<Player>().holdRope = false;
                Destroy(lol);
            }
            StartCoroutine(Ungrab(point));
            collision.gameObject.GetComponent<Player>().rope = point;
            collision.gameObject.GetComponent<Player>().holdRope = true;
        }

    }
}
