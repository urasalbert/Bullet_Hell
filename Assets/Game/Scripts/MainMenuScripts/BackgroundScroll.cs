using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour
{
     private RawImage img;
    [SerializeField] private float speedX, speedY;

    private void Awake()
    {
        img = GetComponent<RawImage>();
    }
    private void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(speedX, 0) * Time.deltaTime, img.uvRect.size);
    }
}

