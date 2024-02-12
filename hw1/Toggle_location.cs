using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
public class Toggle_location : MonoBehaviour
{
    public InputActionReference action;
    public GameObject startObject;
    public GameObject toggleObject;
    private bool toggleOn;

    // Start is called before the first frame update
    void Start()
    {
        action.action.Enable();
        toggleOn = false;
    }

    // Update is called once per frame
    void Update()
    {

        action.action.performed += (ctx) =>
        {
            toggleOn = !toggleOn;
            if (toggleOn) {
                Debug.Log("Click righthand secondary");
                transform.position = toggleObject.transform.position;
                
            } else {
                transform.position = startObject.transform.position;

            }
        };
    }
}
