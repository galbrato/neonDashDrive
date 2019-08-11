using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyTimeline = null;

    public void StartSpawn()
    {
        enemyTimeline.SetActive(true);

    }
}
