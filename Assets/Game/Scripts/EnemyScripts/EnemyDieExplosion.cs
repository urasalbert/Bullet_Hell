using System.Collections;
using UnityEngine;

public class EnemyDieExplosion : MonoBehaviour
{
    [SerializeField] internal GameObject[] fragments;
    internal int numberOfFragments = 3;
    internal float explosionForce = 300f;
    internal float explosionRadius = 2f;
    private GameObject parentObject;

    private void Awake()
    {
        //For better hierarchy
        parentObject = GameObject.FindWithTag("Environment");
    }
    public void GoreExplosion()
    {
        // Ensure numberOfFragments does not exceed the length of fragments array
        // int fragmentsToSpawn = Mathf.Min(numberOfFragments, fragments.Length);

        for (int i = 0; i < numberOfFragments; i++)
        {
            GameObject fragmentPrefab = fragments[i];

            GameObject fragment = Instantiate(fragmentPrefab, transform.position, Quaternion.identity, parentObject.transform);

            // Add a Rigidbody component and launch it in a random direction
            Rigidbody rb = fragment.GetComponent<Rigidbody>();

            if (rb == null) // Null check if there is no rb add rb
            {
                rb = fragment.AddComponent<Rigidbody>();
            }

            Vector3 randomDirection = Random.insideUnitSphere.normalized;
            rb.AddForce(randomDirection * explosionForce);

            StartCoroutine(DestroyFragmentAfterTime(fragment, 3f));
        }
    }

    private IEnumerator DestroyFragmentAfterTime(GameObject fragment, float delay) // Function to destroy gore objects 
    {
        yield return new WaitForSeconds(delay);
        Destroy(fragment);
    }
}

