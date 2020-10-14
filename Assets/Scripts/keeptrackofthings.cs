using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keeptrackofthings : MonoBehaviour
{
    public Vector2 velocity;
    public GameObject black;
    public AudioClip musicTuto;
    public AudioClip musicSewers;
    float music;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (FindObjectsOfType<keeptrackofthings>().Length > 1)
        {
            Destroy(this.gameObject);
        }
    }


    public void StartTutorialMusic()
    {
        gameObject.GetComponent<AudioSource>().clip = musicTuto;
        gameObject.GetComponent<AudioSource>().loop = true;
        gameObject.GetComponent<AudioSource>().Play();
    }

    IEnumerator StopMusic()
    {
        while (music > 0)
        {
            music -= 1f * Time.deltaTime;
            gameObject.GetComponent<AudioSource>().volume = music;
            yield return null;
        }
        music = 0;
        yield return null;
    }

    IEnumerator StartMusic()
    {
        while (music < 1)
        {
            music += 1f * Time.deltaTime;
            gameObject.GetComponent<AudioSource>().volume = music;
            yield return null;
        }
        music = 1;
        yield return null;
    }

    IEnumerator SewerMusic()
    {
        yield return StartCoroutine(StopMusic());
        gameObject.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().clip = musicSewers;
        gameObject.GetComponent<AudioSource>().loop = true;
        gameObject.GetComponent<AudioSource>().Play();
        yield return StartCoroutine(StartMusic());
    }


    public void StartSewerMusic()
    {
        StartCoroutine(SewerMusic());
    }

    public void saveVelocity()
    {
        velocity = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity;
    }

    IEnumerator FadeIn()
    {
        black = GameObject.FindGameObjectWithTag("Black");
        
        float alpha = 1;
        while (alpha > 0 && black != null)
        {
            alpha -= 0.05f;
            black.transform.GetChild(0).GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        yield return null;
    }

    IEnumerator applyVelocityRoutine()
    {
        bool looking = true;
        while (looking)
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                StartCoroutine(FadeIn());
                GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = velocity;
                looking = false;
            }
            yield return null;
        }
        yield return null;
    }

    public void applyVelocity()
    {
        StartCoroutine(applyVelocityRoutine());
    }

    // Update is called once per frame

    void Update()
    {
        black = GameObject.Find("Black");
    }
}
