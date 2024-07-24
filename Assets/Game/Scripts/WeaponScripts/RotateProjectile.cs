using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateProjectile : MonoBehaviour
{
    ArcherSkeleton skeleton;
    private float rotationSpeed = 40f;
    private float maxRotationAngle = 180f;

    private void Awake()
    {
        skeleton = FindObjectOfType<ArcherSkeleton>();

        if (skeleton == null)
        {
            Debug.LogWarning("ArcherSkeleton component not found in the scene!");
        }
    }

    void Update()
    {

        // Rotate the arrow
        float currentZAngle = transform.eulerAngles.z;

        if (Mathf.Abs(currentZAngle - maxRotationAngle) > 0.1f) // If there is still place to rotate keep rotating
        {
            float step = rotationSpeed * Time.deltaTime; // Rotation speed
            float newZAngle = Mathf.MoveTowards(currentZAngle, maxRotationAngle, step); // Rotate/move chosen x,y,z with speed
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, newZAngle);
        }
    }
}
