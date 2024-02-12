using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    // Start is called before the first frame update
    public float degreesPerSecond = 2.0f;
    

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, degreesPerSecond * Time.deltaTime, 0);
    }
}
