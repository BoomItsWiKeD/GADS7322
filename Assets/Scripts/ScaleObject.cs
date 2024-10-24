using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    private Vector3 minScale;
    public Vector3 maxScale;
    public float speed = 2f;
    public float duration = 1f;

    public void OnScaleObjectClick()
    {
        minScale = transform.localScale;
        
        //lerp scale up and down
        RepeatLerp(minScale, maxScale, duration);
        RepeatLerp(maxScale, minScale, duration);
    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {
        float rate = (1.0f / time) * speed;
        
        for (float i = 0.0f; i < 1.0f; i += Time.deltaTime * rate)
        {
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
}
