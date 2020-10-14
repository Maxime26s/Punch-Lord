using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    public float timeFactor;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        Time.timeScale = timeFactor;
        // Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Time.timeScale = 1f;
    }
}
