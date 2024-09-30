using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateMe : MonoBehaviour
{
    public float rotationSpeed = 20f; // Degrees per frame

    void Update()
    {
        // Rotate the object around the Y axis
        transform.Rotate(0, rotationSpeed, 0);
    }
}
