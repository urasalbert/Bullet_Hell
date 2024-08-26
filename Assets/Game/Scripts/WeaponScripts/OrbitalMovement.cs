using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalMovement : MonoBehaviour
{
    private Transform target;
    public float orbitSpeed = 50f;
    public float orbitRadius = 2f;
    private float currentAngle = 0f;
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        MoveOrbital();
    }
    public void MoveOrbital()
    {
        currentAngle += orbitSpeed * Time.deltaTime;

        float x = target.position.x + Mathf.Cos(currentAngle * Mathf.Deg2Rad) * orbitRadius;
        float y = target.position.y + Mathf.Sin(currentAngle * Mathf.Deg2Rad) * orbitRadius;

        transform.position = new Vector3(x, y, transform.position.z);
    }
}

