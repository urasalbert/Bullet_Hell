using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPetProjectileMove : MonoBehaviour
{
    public float speed = 3f;
    public GameObject projectilePrefab;
    private Vector3 direction;
    private GameObject parentObject;

    private void Awake()
    {
        // Get player movement direction for shooting direction
        PlayerMovement playerMovement = FindAnyObjectByType<PlayerMovement>();
        parentObject = GameObject.FindWithTag("Environment");

        // Determine the initial direction based on the player's last movement
        if (playerMovement.lastHorizontalVector > 0)
        {
            direction = Vector3.right; // Move right
        }
        else
        {
            direction = Vector3.left; // Move left
        }
    }

    void Update()
    {
        StartCoroutine(ShootandShatterProjectiles());
    }

    void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void Shatter()
    {
        Vector3 up, down, diagonalDown, diagonalUp,
            diagonalBackUp, diagonalBackDown, left, right;

        up = Vector3.up.normalized;
        down = Vector3.down.normalized;
        diagonalUp = (Vector3.right + Vector3.up).normalized;
        diagonalDown = (Vector3.right + Vector3.down).normalized;
        diagonalBackUp = (Vector3.left + Vector3.up).normalized;
        diagonalBackDown = (Vector3.left + Vector3.down).normalized;
        right = Vector3.right.normalized;
        left = Vector3.left.normalized;

        GameObject upProc = Instantiate(projectilePrefab, transform.position,
           Quaternion.identity, parentObject.transform);
        GameObject downProc = Instantiate(projectilePrefab, transform.position,
           Quaternion.identity, parentObject.transform);
        GameObject diagonalUpProc = Instantiate(projectilePrefab, transform.position,
           Quaternion.identity, parentObject.transform);
        GameObject diagonalDownProc = Instantiate(projectilePrefab, transform.position,
           Quaternion.identity, parentObject.transform);
        GameObject diagonalBackUpProc = Instantiate(projectilePrefab, transform.position,
           Quaternion.identity, parentObject.transform);
        GameObject diagonalBackDownProc = Instantiate(projectilePrefab, transform.position,
           Quaternion.identity, parentObject.transform);
        GameObject leftProc = Instantiate(projectilePrefab, transform.position,
           Quaternion.identity, parentObject.transform);
        GameObject rightProc = Instantiate(projectilePrefab, transform.position,
           Quaternion.identity, parentObject.transform);

        upProc.GetComponent<Rigidbody>().velocity = up * speed;
        downProc.GetComponent<Rigidbody>().velocity = down * speed;
        diagonalUpProc.GetComponent<Rigidbody>().velocity = diagonalUp * speed;
        diagonalDownProc.GetComponent<Rigidbody>().velocity = diagonalDown * speed;
        diagonalBackUpProc.GetComponent<Rigidbody>().velocity = diagonalBackUp * speed;
        diagonalBackDownProc.GetComponent<Rigidbody>().velocity = diagonalBackDown * speed;
        leftProc.GetComponent<Rigidbody>().velocity = left * speed;
        rightProc.GetComponent<Rigidbody>().velocity = right * speed;
    }

    IEnumerator ShootandShatterProjectiles()
    {
        Move();
        yield return new WaitForSeconds(5f);
        Shatter();
    }
}
