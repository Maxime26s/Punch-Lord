using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramoveup : MonoBehaviour
{
    public GameObject confinor;
    public GameObject vrcam;
    public Camera cam;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

  

    // Update is called once per frame
    void Update()
    {
        confinor.transform.position = player.transform.position + new Vector3(0, -10, 0);
    }
}
