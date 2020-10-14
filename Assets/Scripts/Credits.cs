using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    CreditMovement mov;
    public Transform desiredPosition;
    public GameObject textBox;
    public GameObject lastBox;
    public GameObject newPlayer;
    public GameObject legs;
    public GameObject black;
    bool textboxon;
    // Start is called before the first frame update
    void Start()
    {
        mov = GameObject.FindGameObjectWithTag("Player").GetComponent<CreditMovement>();
        StartCoroutine(FadeIn());
        StartCoroutine(Introduction());
    }

    IEnumerator Introduction()
    {
        mov.canMove = false;
        yield return new WaitForSeconds(0.1f);
        while (mov.gameObject.transform.position.x < desiredPosition.position.x)
        {
            mov.goRight();
            yield return null;
        }
        textBox.SetActive(true);
        mov.animator.SetBool("isWalking", false);
        while (!Input.GetKeyDown(KeyCode.Space) && !Input.GetButtonDown("Jump"))
        {
            yield return null;
        }
        textBox.SetActive(false);
        mov.canMove = true;
        GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Follow = GameObject.FindGameObjectWithTag("Player").transform;
        yield return null;
    }

    public void endGame()
    {
        StartCoroutine(End());
    }

    IEnumerator End()
    {
        Debug.Log("what");
        mov.canMove = false;
        yield return new WaitForSeconds(0.5f);
        lastBox.SetActive(true);
        while (!Input.GetKeyDown(KeyCode.Space) && !Input.GetButtonDown("Jump"))
        {
            yield return null;
        }
        lastBox.SetActive(false);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject noLegs = Instantiate(newPlayer, player.transform.position, Quaternion.identity);
        Instantiate(legs, new Vector3(player.transform.position.x - 0.7f, player.transform.position.y - 1f, player.transform.position.z), Quaternion.identity);
        Destroy(player);
        noLegs.GetComponent<Player>().enabled = false;
        yield return new WaitForSeconds(0.4f);
        GameObject.Find("HitBox").transform.eulerAngles = new Vector3(0, 0, -45);
        GameObject.Find("HitBox").GetComponent<Arm>().startCoroutineParticle();
        GameObject.FindGameObjectWithTag("Poing").GetComponent<Poing>().onPunch();
        noLegs.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000, 1000));
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeOut());
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
        SceneManager.LoadScene(0);
        yield return null;
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

    // Update is called once per frame
    void Update()
    {
    
    }
}
