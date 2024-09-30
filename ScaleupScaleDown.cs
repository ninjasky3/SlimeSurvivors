using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleupScaleDown : MonoBehaviour
{
    public float scaleAmount = 1f; // The amount by which to increase the size
    public float duration = 0.5f;  // Duration to reach the scaleAmount and return to the original size

    private Vector3 originalScale; // To store the original scale of the object

    void Start()
    {
        originalScale = transform.localScale; // Store the original scale
        StartCoroutine(ScaleRoutine()); // Start the scaling coroutine
    }

    private IEnumerator ScaleRoutine()
    {
        // Smoothly increase the size to the specified amount
        yield return StartCoroutine(SmoothScale(originalScale, originalScale + Vector3.one * scaleAmount, duration));

        // Smoothly return to the original size
        yield return StartCoroutine(SmoothScale(originalScale + Vector3.one * scaleAmount, originalScale, duration));
    }

    private IEnumerator SmoothScale(Vector3 startScale, Vector3 endScale, float time)
    {
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        transform.localScale = endScale; // Ensure the final scale is set precisely
    }
}
