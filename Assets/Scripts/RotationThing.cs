using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationThing : MonoBehaviour
{
    public float speed, initialRotation, limit, cosAnswer, maxDistance, launchSpeed;
    public Transform max;
    // Start is called before the first frame update
    void Start()
    {
        maxDistance = Vector2.Distance(transform.position,max.position);
        initialRotation = transform.eulerAngles.z;
    }
    // Update is called once per frame
    void Update()
    {
        cosAnswer = Mathf.Cos(Time.time * speed);
        transform.eulerAngles = new Vector3(0,0, initialRotation + Mathf.Sin(Time.time * speed) * limit);
    }
}
