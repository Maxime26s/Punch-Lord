using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptAventuredebut : MonoBehaviour
{
    public GameObject murinvis, player, black;
    // Start is called before the first frame update

    IEnumerator FadeIn()
    {
        black = GameObject.FindGameObjectWithTag("Black");
        float alpha = 1;
        while (alpha > 0 && black != null)
        {
            alpha -= 0.01f;
            black.transform.GetChild(0).GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        yield return null;
    }

    IEnumerator beginAdventure()
    {
        player.GetComponent<Player>().canJump = false;
        player.GetComponent<Player>().enabled = false;
        yield return StartCoroutine(FadeIn());
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.3f * 1000, 0.3f * 1000));
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<Player>().enabled = true;
        player.GetComponent<Player>().canJump = true;
        murinvis.SetActive(true);
        yield return null;
    }

    void Start()
    {
        black = GameObject.FindGameObjectWithTag("Black");
        StartCoroutine(beginAdventure());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
