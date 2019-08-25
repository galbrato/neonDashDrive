using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] string[] takeDamageTag = null;

    public delegate void TakeDamageDelegate();
    public TakeDamageDelegate OnTakeDamage;

    public void OnHit()
    {
        OnTakeDamage?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < takeDamageTag.Length; i++)
        {
            if (collision.CompareTag(takeDamageTag[i]))
            {
                //collision.GetComponent<TakeDamage>().OnHit();
                //print(name);
                OnHit();
            }
        }
    }
}
