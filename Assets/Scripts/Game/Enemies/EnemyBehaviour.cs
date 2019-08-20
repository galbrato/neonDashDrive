using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    private void Awake()
    {
        GetComponent<TakeDamage>().OnTakeDamage += DestroyEnemy;
    }

    public void DestroyEnemy()
    {
        ExplosionSpawner.instance.SpawnPrefab(0, transform.position);
        gameObject.SetActive(false);
    }
}
