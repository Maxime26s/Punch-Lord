using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Poing : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public Vector3 start;

    public void onPunch()
    {
        StopCoroutine(Stop());
        animator.Play("poingStill");
        animator.Play("frapper");
        StartCoroutine(Stop());

    }

    IEnumerator Stop()
    {  
        while (gameObject.transform.position != GameObject.Find("TargetDoigt").transform.position)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, GameObject.Find("TargetDoigt").transform.position, speed);
        }
        yield return new WaitForSeconds(0.5009f);

        gameObject.transform.position = GameObject.Find("TargetPoing").transform.position;
        yield return null;
    }

    private void Update()
    {

    }
}
