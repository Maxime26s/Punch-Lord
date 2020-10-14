using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene2textbox : MonoBehaviour
{
    public GameObject textbox;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(textboxOpen());
    }

    IEnumerator textboxOpen()
    {
        yield return new WaitForSeconds(5f);
        textbox.SetActive(true);
        yield return new WaitForSeconds(2f);
        while (!Input.GetKeyDown(KeyCode.Space) && !Input.GetButtonDown("Jump"))
        {
            yield return null;
        }
        textbox.SetActive(false);
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
