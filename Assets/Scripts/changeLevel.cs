using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changeLevel : MonoBehaviour
{
    public int currentLevel;
    public int nextLevel;
    public float minYSpeed;
    bool isShaking;
    public GameObject confinor;
    public GameObject cam;
    public GameObject black;
    public keeptrackofthings ktot;

    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator transitionCamera()
    {
        while (confinor.transform.position.y < gameObject.transform.position.y + 6)
        {
            confinor.transform.position += new Vector3(0, 10 * Time.deltaTime, 0);
            cam.transform.position += new Vector3(0, 10 * Time.deltaTime, 0);
            yield return null;
        }
        yield return null;
    }

    IEnumerator FadeOut()
    {
        black = GameObject.FindGameObjectWithTag("Black");
        if (black != null)
        {
            float alpha = 0;
            while (alpha < 1 && black != null)
            {
                alpha += 0.05f;
                black.transform.GetChild(0).GetComponent<Image>().color = new Color(0, 0, 0, alpha);
                yield return null;
            }
        }
        yield return null;
    }
    IEnumerator ChangeLevel()
    {
        StartCoroutine(ScreenShake(0.5f));
        StartCoroutine(transitionCamera());
        yield return StartCoroutine(FadeOut());
        SceneManager.LoadScene(nextLevel);
        yield return new WaitForEndOfFrame();
        ktot.applyVelocity();
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                ktot = FindObjectOfType<keeptrackofthings>();
                ktot.saveVelocity();
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                StartCoroutine(ChangeLevel());
        }
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
