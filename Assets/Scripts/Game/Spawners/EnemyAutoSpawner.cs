using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAutoSpawner : MonoBehaviour
{
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] GameObject[] spawnPrefabs;
    [SerializeField] Transform enemiesParent;
    float[] spawnChance;
    [SerializeField] float initialSpawnDelay;
    [SerializeField] float spawnDelay;

    GameObject obj;

    bool canSpawn = true;

    private void Awake()
    {
        spawnChance = new float[spawnPrefabs.Length];
        float initialSpawnChance = 1f / spawnChance.Length;
        for(int i = 0; i < spawnChance.Length; i++)
        {
            spawnChance[i] = initialSpawnChance;
        }
    }

    private void Start()
    {
        print("start");
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

    void Spawn()
    {
        print("spawn");
        obj = Instantiate(spawnPrefabs[ChooseRandomSpawnIndex()], spawnPosition, Quaternion.identity, enemiesParent);
    }

    int ChooseRandomSpawnIndex()
    {
        float randomValue = Random.value;
        print("Random value " + randomValue);
        float currentValue = 0;
        for(int i = 0; i < spawnChance.Length; i++)
        {
            if(randomValue >= currentValue && randomValue <= spawnChance[i])
            {
                print("Current value " + currentValue);

                float distributeChance = spawnChance[i]/spawnChance.Length;
                spawnChance[i] = distributeChance;
                for(int j = 0; j < spawnChance.Length; j++)
                {
                    if(j != i)
                    {
                        spawnChance[j] += distributeChance;
                        print("SpawnChance at " + j + " " + spawnChance[j]);
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
