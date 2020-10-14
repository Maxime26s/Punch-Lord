using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddUsure : MonoBehaviour
{
    public Sprite rock1;
    public Sprite rock2;
    public Sprite rock3;

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<Interactible>().lives == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = rock1;
        }
        if (this.gameObject.GetComponent<Interactible>().lives == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = rock2;
        }
        if (this.gameObject.GetComponent<Interactible>().lives == 3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = rock3;
        }
    }
}
