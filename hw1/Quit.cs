using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Quit : MonoBehaviour
{
    public InputActionReference action;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Click quit");

        action.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {

        action.action.performed += (ctx) =>
        {
            # if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            # else 
                Application.Quit();
            # endif
        };
    }
}
