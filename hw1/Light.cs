using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Light : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.Light light;

    public InputActionReference action;
    Color color0 = Color.green;
    void Start()
    {
        Debug.Log("Started Light");
        light = GetComponent<UnityEngine.Light>();

        action.action.Enable();

    }

    // Update is called once per frame
    void Update()
    {

        action.action.performed += (ctx) =>
        {
            Debug.Log("Click righthand secondary");
            light.color =  color0;
        };
    }
}
