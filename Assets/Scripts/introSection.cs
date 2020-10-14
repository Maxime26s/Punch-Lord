using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introSection : MonoBehaviour
{
    movement mov;
    public Transform desiredPosition;
    public GameObject inviswalls;
    public GameObject textBox;
    bool isShaking;
    bool textboxon;
    // Start is called before the first frame update
    void Start()
    {
        mov = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>();
        StartCoroutine(Introduction());
    }

    IEnumerator Introduction()
    {
        yield return new WaitForSeconds(0.1f);
        while (mov.gameObject.transform.position.x < desiredPosition.position.x)
        {
            mov.goRight();
            yield return null;
        }
        textBox.SetActive(true);
        while (!Input.GetKeyDown(KeyCode.Space) && !Input.GetButtonDown("Jump"))
        {
            yield return null;
        }
        textBox.SetActive(false);
        inviswalls.SetActive(true);
        mov.canMove = true;
        yield return null;
    }

    public void StartCollapse()
    {
        StartCoroutine(Collapse());
    }

    IEnumerator Collapse()
    {
        mov.canMove = false;
        yield return StartCoroutine(ScreenShake(2f));
        SceneManager.LoadScene(2);
        yield return null;
    }

    IEnumerator ScreenShake(float duration)
    {
        Vector3 original = Camera.main.transform.position;
        isShaking = true;
        yield return new WaitForSeconds(duration);
        isShaking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShaking)
        {
            Camera.main.transform.position = Camera.main.transform.position + Random.insideUnitSphere * 0.1f;
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -10);
        }
    }
}
