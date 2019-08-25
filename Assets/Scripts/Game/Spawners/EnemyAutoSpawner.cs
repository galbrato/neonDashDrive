using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAutoSpawner : MonoBehaviour
{
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] GameObject[] spawnPrefabs = null;
    [SerializeField] Transform enemiesParent = null;
    float[] spawnChance;
    [SerializeField] float initialSpawnDelay = 10f;
    [SerializeField] float spawnDelay = 3f;

    GameObject obj;

    bool canSpawn = true;

    [Header("Temporary")]
    public float difficultyIncreaseRate = 0.1f;
    public float minSpawnRate = 1f;

    private void Awake()
    {
        spawnChance = new float[spawnPrefabs.Length];
        float initialSpawnChance = 1f / spawnChance.Length;
        for(int i = 0; i < spawnChance.Length; i++)
        {
            spawnChance[i] = initialSpawnChance;
        }
    }

    public void StartSpawn()
    {
        StartCoroutine(InitialSpawnDelay());
    }

    IEnumerator InitialSpawnDelay()
    {
        yield return new WaitForSeconds(initialSpawnDelay);
        Spawn();
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(spawnDelay);
            Spawn();
        }
    }

    public void ToggleSpawn(bool toggleFalse = true)
    {
        if (!toggleFalse)
        {
            canSpawn = false;
            return;
        }
        canSpawn = !canSpawn;
    }

    void Spawn()
    {
        if(spawnDelay > minSpawnRate) spawnDelay -= difficultyIncreaseRate;
        obj = Instantiate(spawnPrefabs[ChooseRandomSpawnIndex()], spawnPosition, Quaternion.identity, enemiesParent);
    }

    int ChooseRandomSpawnIndex()
    {
        float randomValue = Random.value;
        float currentValue = 0;
        float maxValue = 0;
        for(int i = 0; i < spawnChance.Length; i++)
        {
            maxValue += spawnChance[i];
            if (randomValue >= currentValue && randomValue <= maxValue)
            {
                float distributeChance = spawnChance[i]/spawnChance.Length;
                spawnChance[i] = distributeChance;
                for(int j = 0; j < spawnChance.Length; j++)
                {
                    if(j != i)
                    {
                        spawnChance[j] += distributeChance;
                    }
                }

                return i;
            }
            else
            {
                currentValue += spawnChance[i];
            }
        }
        return 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(spawnPosition, new Vector3(1, 1, 1));
    }
}
