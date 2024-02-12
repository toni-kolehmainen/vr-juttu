using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

// Puuttuu
// - 2 handed grabbing.
// both affections


public class CustomGrab : MonoBehaviour
{
    // This script should be attached to both controller objects in the scene
    // Make sure to define the input in the editor (LeftHand/Grip and RightHand/Grip recommended respectively)
    CustomGrab otherHand = null;
    public List<Transform> nearObjects = new List<Transform>();
    public Transform grabbedObject = null;
    public InputActionReference action;
    public InputActionReference actionMag;
    bool grabbing = false;
    bool steepUp = false;
    Vector3 deltaLocation;
    Quaternion deltaRotation;
    Vector3 last_position = Vector3.zero;
    Quaternion last_rotation;
    float mag = 1f;

    private void Start()
    {
        action.action.Enable();
        actionMag.action.Enable();

        // Find the other hand
        foreach(CustomGrab c in transform.parent.GetComponentsInChildren<CustomGrab>())
        {
            if (c != this)
                otherHand = c;
        }
    }

    void Update()
    {
        grabbing = action.action.IsPressed();

        steepUp = actionMag.action.IsPressed();
        
        if (grabbing)
        {
            // Grab nearby object or the object in the other hand
            // 
            if (!grabbedObject)
                grabbedObject = nearObjects.Count > 0 ? nearObjects[0] : otherHand.grabbedObject;
            if (grabbedObject)
            {
                
                Quaternion.Inverse (last_rotation);
                deltaRotation = transform.rotation  * Quaternion.Inverse (last_rotation);

                deltaLocation = transform.position - last_position;
      
                if (steepUp) {
                    mag = 2f;
                } else {
                    mag = 1f;
                }

                deltaRotation.ToAngleAxis(out var angle, out var axis);

                grabbedObject.position = grabbedObject.position + deltaLocation;
                grabbedObject.RotateAround(transform.position, axis, angle*mag);
                
                // Change these to add the delta position and rotation instead
                // Save the position and rotation at the end of Update function, so you can compare previous pos/rot to current here
            }
        }
        // If let go of button, release object
        else if (grabbedObject)
            grabbedObject = null;

        // Should save the current position and rotation here
        last_position = transform.position;
        last_rotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Make sure to tag grabbable objects with the "grabbable" tag
        // You also need to make sure to have colliders for the grabbable objects and the controllers
        // Make sure to set the controller colliders as triggers or they will get misplaced
        // You also need to add Rigidbody to the controllers for these functions to be triggered
        // Make sure gravity is disabled though, or your controllers will (virtually) fall to the ground

        Transform t = other.transform;
        if(t && t.tag.ToLower()=="grabbable")
            nearObjects.Add(t);
    }

    private void OnTriggerExit(Collider other)
    {
        Transform t = other.transform;
        if( t && t.tag.ToLower()=="grabbable")
            nearObjects.Remove(t);
    }
}
