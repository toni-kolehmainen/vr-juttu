using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Magglass : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform mainCamera;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation; 
        rotation = mainCamera.transform.forward * -Input.GetAxis ("Horizontal");

        transform.Rotate(rotation);
    }
}
