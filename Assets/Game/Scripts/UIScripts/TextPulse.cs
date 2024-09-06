using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPulse : MonoBehaviour
{
    public float pulseSpeed = 1f;
    public float minScale = 0.8f;
    public float maxScale = 1.2f;

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        float scale = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f);

        rectTransform.localScale = new Vector3(scale, scale, 1f);
    }
}