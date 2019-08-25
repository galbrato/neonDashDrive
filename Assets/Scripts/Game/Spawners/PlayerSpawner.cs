using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] playerPrefab = null;
    [SerializeField] Vector3 spawnPosition = new Vector3(0,0,0);
    [SerializeField] Transform tilesGrid = null;
    [SerializeField] int spawnTileIndex = 0;
    [SerializeField] Transform spawnParent = null;

    AutoShoot shootScript;
    PlayerBehaviour behaviourScript;
    TileMovement movementScript;
    Animator animator;

    [Header("Initial Values")]
    [Header("1. AutoShoot")]
    public float shootRate = 3;
    public float shootMultiplier = 1;

    [Header("2. Spawn Animation Durations")]
    [SerializeField] float spawnDuration;
    [SerializeField] float respawnDuration;

    public GameObject SpawnPlayer(int index)
    {
        GameObject obj = Instantiate(playerPrefab[index], spawnPosition, Quaternion.identity, spawnParent);
        movementScript = obj.GetComponent<TileMovement>();
        movementScript.ActualTile = tilesGrid.GetChild(spawnTileIndex).GetComponent<Tile>();
        //set initial attributes
        shootScript = obj.GetComponent<AutoShoot>();
        behaviourScript = obj.GetComponent<PlayerBehaviour>();
        shootScript.SetParameters(shootRate, shootMultiplier, false);

        animator = obj.GetComponent<Animator>();
        return obj;
    }

    public void RespawnPlayer(GameObject obj)
    {
        obj.transform.position = spawnPosition;
        obj.GetComponent<TileMovement>().ActualTile = tilesGrid.GetChild(spawnTileIndex).GetComponent<Tile>();
        //set initial attributes
        obj.SetActive(true);
        shootScript.SetParameters(shootRate, shootMultiplier, false);

        //play spawn animation then set canShoot to true
        animator.SetTrigger("Respawn");
        StartCoroutine(RespawnAnimationPlaying());
    }

    IEnumerator RespawnAnimationPlaying()
    {
        yield return new WaitForSeconds(respawnDuration);
        movementScript.playerAlive = true;
        shootScript.ToggleShoot(true);
        behaviourScript.ToggleSpecial();
    }
}
