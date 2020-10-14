using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class goblinIntro : MonoBehaviour
{
    public GameObject goblin;
    public GameObject player, realPlayer;
    public GameObject black;
    public Transform goblindesiredpos;
    public GameObject textbox1, textbox2, textbox3, textbox4;
    goblinmovement gmov;
    // Start is called before the first frame update
    void Start()
    {
        gmov = goblin.GetComponent<goblinmovement>();
        StartCoroutine(GoblinEscape());
    }

    IEnumerator FadeIn()
    {
        float alpha = 1;
        while (alpha > 0)
        {
            alpha -= 0.01f;
            black.transform.GetChild(0).GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        yield return null;
    }

    IEnumerator FadeOut()
    {
        float alpha = 0;
        while (alpha < 1)
        {
            alpha += 0.01f;
            black.transform.GetChild(0).GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        yield return null;
    }

    IEnumerator GoblinEscape()
    {
        yield return new WaitForSeconds(1.5f);
        yield return StartCoroutine(FadeIn());
        yield return new WaitForSeconds(1.5f);
        goblin.GetComponent<SpriteRenderer>().flipX = true;
        yield return new WaitForSeconds(0.5f);
        gmov.Jump();
        while(goblin.transform.position.x < goblindesiredpos.transform.position.x)
        {
            gmov.goRight();
            yield return null;
        }
        Destroy(goblin);
        yield return null;
        StartCoroutine(Beginning());
    }

    IEnumerator Beginning()
    {
        realPlayer.transform.Find("HitBox").GetComponent<Arm>().canPunch = false;
        yield return new WaitForSeconds(1f);
        textbox2.SetActive(true);
        player.SetActive(false);
        realPlayer.SetActive(true);
        realPlayer.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100));
        realPlayer.transform.Find("HitBox").GetComponent<Arm>().canPunch = true;
        FindObjectOfType<keeptrackofthings>().StartTutorialMusic();
        while (!Input.GetKeyDown(KeyCode.Space) && !Input.GetButtonDown("Jump"))
        {
            yield return null;
        }
        textbox2.SetActive(false);
        yield return new WaitForSeconds(1f);
        textbox3.SetActive(true);
        while (!Input.GetKeyDown(KeyCode.Space) && !Input.GetButtonDown("Jump"))
        {
            yield return null;
        }
        textbox3.SetActive(false);
        yield return new WaitForSeconds(1f);
        textbox4.SetActive(true);
        while (!Input.GetKeyDown(KeyCode.Space) && !Input.GetButtonDown("Jump"))
        {
            yield return null;
        }
        textbox4.SetActive(false);
        yield return new WaitForSeconds(1f);
        yield return null;
    }

    IEnumerator EndFirstRoomCoroutine()
    {
        yield return StartCoroutine(FadeOut());
        SceneManager.LoadScene(4);
        yield return null;
    }

    public void EndFirstRoom()
    {
        StartCoroutine(EndFirstRoomCoroutine());
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
