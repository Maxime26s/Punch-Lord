using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<keeptrackofthings>().StartSewerMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
