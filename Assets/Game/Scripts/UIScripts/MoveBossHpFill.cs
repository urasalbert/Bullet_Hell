using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBossHpFill : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    private void Update()
    {
        transform.position = target.position + offset;
    }
}
