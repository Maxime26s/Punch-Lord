using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class afficherNom : MonoBehaviour
{
    public GameObject particleFX;
    public AudioClip zonesound;

    IEnumerator afficherZone()
    {
        yield return new WaitForSeconds(1f);
        particleFX.SetActive(true);
        gameObject.GetComponent<AudioSource>().clip = zonesound;
        gameObject.GetComponent<AudioSource>().Play();
        yield return StartCoroutine(FadeIn());

        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(FadeOut());
        yield return null;
    }

    IEnumerator FadeIn()
    {
        float alpha;
        alpha = 0;
        while (alpha < 1)
        {
            alpha += 0.01f;
            Color textcolor = GameObject.FindGameObjectWithTag("zoneText").GetComponent<TextMeshProUGUI>().color;
            GameObject.FindGameObjectWithTag("zoneText").GetComponent<TextMeshProUGUI>().color = new Color(textcolor.r, textcolor.g, textcolor.b, alpha);
            yield return null;
        }
        yield return null;
    }

    IEnumerator FadeOut()
    {
        float alpha;
        alpha = 1;
        while (alpha > 0)
        {
            alpha -= 0.01f;
            Color textcolor = GameObject.FindGameObjectWithTag("zoneText").GetComponent<TextMeshProUGUI>().color;
            GameObject.FindGameObjectWithTag("zoneText").GetComponent<TextMeshProUGUI>().color = new Color(textcolor.r, textcolor.g, textcolor.b, alpha);
            yield return null;
        }
        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(afficherZone());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
