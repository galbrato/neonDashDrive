using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawner : Spawner
{
    public static ExplosionSpawner instance = null;

    [SerializeField] Transform explosionParent = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SpawnPrefab(int index, Vector3 position)
    {
        Instantiate(prefabList[index], position, Quaternion.identity, explosionParent);
    }
}
