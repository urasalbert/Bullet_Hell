using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFlipper : MonoBehaviour
{
    // Item flipper for better animations 
    PlayerMovement pm;
    internal SpriteRenderer spriteRenderer;

    public List<GameObject> items = new List<GameObject>(); // List of items
    private Dictionary<GameObject, Vector3> initialLocalPositions = new Dictionary<GameObject, Vector3>(); // Initial positions of items
    private Dictionary<GameObject, SpriteRenderer> itemSpriteRenderers = new Dictionary<GameObject, SpriteRenderer>(); // SpriteRenderers of items

    private void Awake()
    {
        pm = FindObjectOfType<PlayerMovement>();

        // Save the initial positions of all items and their SpriteRenderers
        foreach (var item in items)
        {
            if (item != null)
            {
                initialLocalPositions[item] = item.transform.localPosition;

                // Check if the item has a SpriteRenderer component
                SpriteRenderer sr = item.GetComponent<SpriteRenderer>();
                if (sr == null)
                {
                    // If not, check its children for a SpriteRenderer component
                    sr = item.GetComponentInChildren<SpriteRenderer>();
                }

                if (sr != null)
                {
                    itemSpriteRenderers[item] = sr;
                }
            }
        }
    }

    private void Start()
    {
        // Temporarily set lastHorizontalVector for the initial setup
        float initialHorizontalVector = pm.lastHorizontalVector;
        pm.lastHorizontalVector = -1;

        // Ensure items are in the correct initial position and rotation at the start
        SpriteDirectionChecker();

        // Restore the original lastHorizontalVector value
        pm.lastHorizontalVector = initialHorizontalVector;
    }

    private void Update()
    {
        SpriteDirectionChecker();
    }

    void SpriteDirectionChecker()
    {
        if (pm.lastHorizontalVector < 0) // x < 0 left 
        {
            UpdateItemsPositionAndRotation(false); // Moving left
        }
        else
        {
            UpdateItemsPositionAndRotation(true); // Moving right
        }
    }

    void UpdateItemsPositionAndRotation(bool facingLeft)
    {
        foreach (var item in items)
        {
            if (item != null)
            {
                // Flip the item's SpriteRenderer
                if (itemSpriteRenderers.ContainsKey(item))
                {
                    itemSpriteRenderers[item].flipX = facingLeft;
                }

                // Update the item's position
                Vector3 initialPosition = initialLocalPositions[item];
                item.transform.localPosition = new Vector3(
                    facingLeft ? -Mathf.Abs(initialPosition.x) : Mathf.Abs(initialPosition.x),
                    initialPosition.y,
                    initialPosition.z
                );
            }
        }
    }
}
