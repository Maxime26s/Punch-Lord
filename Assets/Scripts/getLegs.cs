using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class getLegs : MonoBehaviour
{
    public GameObject black;
    public GameObject legs;
    public ParticleSystem ps;
    public bool exploded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !exploded) 
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(RollCredits());
        }
    }

    IEnumerator FadeOut()
    {
        float alpha = 0;
        while (alpha < 1)
        {
            alpha += 1.5f * Time.deltaTime;
            black.transform.GetChild(0).GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        yield return null;
    }

    IEnumerator RollCredits()
    {
        exploded = true;
        Time.timeScale = 0.2f;
        ps.Play();
        black.SetActive(true);
        StartCoroutine(FadeOut());
        legs.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().enabled = false;
        yield return new WaitForSecondsRealtime(3.5f);
        Time.timeScale = 1f;
        Destroy(FindObjectOfType<keeptrackofthings>().gameObject);
        SceneManager.LoadScene(12);
        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
