using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] playerPrefab = null;
    [SerializeField] Vector3 spawnPosition = new Vector3(0,0,0);
    [SerializeField] Transform tilesGrid = null;
    [SerializeField] int spawnTileIndex;
    [SerializeField] Transform spawnParent = null;

    [Header("Initial Values")]
    [Header("1. AutoShoot")]
    public float shootRate = 3;
    public float shootMultiplier = 1;
    public bool canShoot = false;

    //[Header("2.")]

    public GameObject SpawnPlayer(int index)
    {
        GameObject obj = Instantiate(playerPrefab[index], spawnPosition, Quaternion.identity, spawnParent);
        obj.GetComponent<TileMovement>().ActualTile = tilesGrid.GetChild(spawnTileIndex).GetComponent<Tile>();
        //set initial attributes
        obj.GetComponent<AutoShoot>().SetParameters(shootRate, shootMultiplier, canShoot);
        return obj;
    }

    public void RespawnPlayer(GameObject obj)
    {
        obj.transform.position = spawnPosition;
        obj.GetComponent<TileMovement>().ActualTile = tilesGrid.GetChild(spawnTileIndex).GetComponent<Tile>();
        //set initial attributes
        obj.GetComponent<AutoShoot>().SetParameters(shootRate, shootMultiplier, canShoot);
        obj.SetActive(true);
    }
}
