using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabList;

    public void SpawnPrefab(int index, Vector3 position, Transform parent)
    {
        Instantiate(prefabList[index], position, Quaternion.identity, parent);
    }
}
