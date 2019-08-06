using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] playerPrefab = null;
    [SerializeField] Vector3 spawnPosition = new Vector3(0,0,0);
    [SerializeField] Transform spawnParent = null;

    public GameObject SpawnPlayer(int index)
    {
        return Instantiate(playerPrefab[index], spawnPosition, Quaternion.identity, spawnParent);
    }
}
