using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // The object that the camera should follow
    public float distance = 5.0f; // The distance between the camera and the target
    public float height = 2.0f; // The height of the camera above the target
    public float damping = 5.0f; // The damping factor for the smooth follow effect
    public bool smoothRotation = true; // Should the camera rotate smoothly towards the target?
    public bool followBehind = true; // Should the camera follow behind the target?

    private void LateUpdate()
    {
        // Calculate the position of the camera
        Vector3 wantedPosition;
        if (followBehind)
        {
            wantedPosition = target.TransformPoint(0, height, distance);
        }
        else
        {
            wantedPosition = target.TransformPoint(0, height, -distance);
        }

        // Dampen the movement of the camera towards the position
        transform.position = Vector3.Lerp(transform.position, wantedPosition, damping * Time.deltaTime);

        // Rotate the camera to face the target
        if (smoothRotation)
        {
            Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, damping * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(target.position - transform.position, target.up);
        }
    }
}
