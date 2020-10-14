using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float endTime, timer;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        endTime = Time.time + timer;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (endTime - Time.time).ToString("F2");
    }
}
