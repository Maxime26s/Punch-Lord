using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Arm : MonoBehaviour
{
    public ParticleSystem particles;
    public ParticleSystem particles2;
    public bool isShaking;
    public bool isPunching;
    public bool isEmitting;
    public bool canPunch;
    public bool punch;
    public CinemachineVirtualCamera cinecam;
    public CinemachineBasicMultiChannelPerlin perlin;
    public float amplitude, frequency;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        cinecam = FindObjectOfType<CinemachineVirtualCamera>();
        perlin = cinecam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            Vector2 aim = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            float angle = Mathf.Atan2(-aim.y, -aim.x) * Mathf.Rad2Deg; ;
            transform.eulerAngles = new Vector3(0, 0, angle - 90);
        }

        else if (this.gameObject.GetComponentInParent<Player>().isMouse)
        {
            var pos = Camera.main.WorldToScreenPoint(transform.position);
            Vector2 aim = new Vector2(Input.mousePosition.x - pos.x, Input.mousePosition.y - pos.y);
            float angle = Mathf.Atan2(-aim.y, -aim.x) * Mathf.Rad2Deg; ;
            transform.eulerAngles = new Vector3(0, 0, angle - 90);
            if(angle + 180 < 90 || angle + 180 > 240){
                GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        if (Input.GetButtonDown("Jump") && canPunch)
        {
            StartCoroutine(Punch());
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnEnable()
    {
        
    }

    public IEnumerator Punch()
    {
        isPunching = true;
        yield return new WaitForSeconds(0.3f);
        isPunching = false;
    }

    IEnumerator ScreenShake()
    {
        isShaking = true;
        perlin.m_AmplitudeGain = amplitude;
        perlin.m_FrequencyGain = frequency;
        yield return new WaitForSeconds(0.2f);
        isShaking = false;
        perlin.m_FrequencyGain = 0;
        perlin.m_AmplitudeGain = 0;
        yield return null;
    }

    IEnumerator Particles()
    {
        audioSource.Play();
        isEmitting = true;
        particles.Play();
        particles2.Play();
        yield return new WaitForSeconds(0.2f);
        isEmitting = false;
        yield return null;
    }

    public void startCoroutineParticle()
    {
        StartCoroutine(Particles());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Vent") && !collision.gameObject.CompareTag("TimeZone") && isPunching && !isEmitting)
        {
            StartCoroutine(Particles());
        }
        
        if (collision.gameObject.tag == "Button" && isPunching)
        {
            collision.gameObject.GetComponent<ButtonDisable>().onAction();
        }

        if (collision.gameObject.tag == "ButtonE" && isPunching)
        {
            collision.gameObject.GetComponent<ButtonEnable>().onAction();
        }

        if (punch && !collision.gameObject.CompareTag("Vent") && !collision.gameObject.CompareTag("TimeZone") && !isShaking)
        {
            StartCoroutine(ScreenShake());
        }
        if (punch && !collision.gameObject.CompareTag("Vent") && !collision.gameObject.CompareTag("TimeZone"))
        {
            GetComponentInParent<Player>().Jump();
            if (collision.gameObject.CompareTag("Interactible"))
            {
                collision.gameObject.GetComponent<Interactible>().lives--;
                
            }
            else if (collision.gameObject.CompareTag("Boss"))
            {
                collision.gameObject.GetComponent<Boss>().lives--;
            }
            punch = false;
        }
    }

}
