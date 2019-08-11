using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] string takeDamageTag = null;

    public delegate void TakeDamageDelegate();
    public TakeDamageDelegate OnTakeDamage;

    public void OnHit()
    {
        OnTakeDamage?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(takeDamageTag))
        {
            Destroy(collision.gameObject);
            //print(name);
            OnHit();
        }
    }
}
