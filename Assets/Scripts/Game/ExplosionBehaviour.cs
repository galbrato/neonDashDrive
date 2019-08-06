using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    public float destructDelay;

    private void Awake()
    {
        StartCoroutine(ExplosionDelay());
    }

    IEnumerator ExplosionDelay()
    {
        yield return new WaitForSeconds(destructDelay);
        Destroy(gameObject);
    }
}
