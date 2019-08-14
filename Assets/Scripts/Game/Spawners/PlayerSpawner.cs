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

    public GameObject SpawnPlayer(int index)
    {
        GameObject obj = Instantiate(playerPrefab[index], spawnPosition, Quaternion.identity, spawnParent);
        obj.GetComponent<TileMovement>().ActualTile = tilesGrid.GetChild(spawnTileIndex).GetComponent<Tile>();
        return obj;
    }
}
