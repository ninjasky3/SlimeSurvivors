using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMeAfterSec : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
