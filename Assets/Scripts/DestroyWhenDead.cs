using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenDead : MonoBehaviour
{
    [SerializeField] TakeDamage takeDamageScript = null;

    private void Awake()
    {
        takeDamageScript.OnTakeDamage += DestroyObject;
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
