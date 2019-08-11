﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    [SerializeField] PlayerSpawner playerSpawner = null;
    [SerializeField] EnemySpawner enemySpawner = null;
    [SerializeField] HUDManager hudManager = null;
    [SerializeField] Countdown countdown = null;
    [SerializeField] PlayerAttributes playerAttributes = new PlayerAttributes();

    GameObject playerReference;

    // Start is called before the first frame update
    void Start()
    {
        //get player info
        int index = 0; //temp

        playerReference = playerSpawner.SpawnPlayer(index);

        hudManager.InitializeHUD();

        //delegate subscriptions
        playerReference.GetComponent<TakeDamage>().OnTakeDamage += PlayerTakeDamage;

        //start briefing
            //subscribe to onBriefingEnd

        EndBriefing(); //temp
    }

    public void EndBriefing()
    {
        //remove subscribe

        StartCountdown();
    }

    public void StartCountdown()
    {
        countdown.OnCountdownEnd += EndCountdown;
        countdown.StartCountdown();
    }

    public void EndCountdown()
    {
        countdown.OnCountdownEnd -= EndCountdown;

        enemySpawner.StartSpawn();
        //allow player inputs
        playerReference.GetComponent<TileMovement>().canMove = true;
        playerReference.GetComponent<AutoShoot>().ToggleShoot(); 
    }
    
    public void PlayerPickupLife()
    {

    }
    
    public void PlayerDeath()
    {
        ExplosionSpawner.instance.SpawnPrefab(0, playerReference.transform.position);
        Destroy(playerReference);
    }

    //change this to inside the player behaviour
    public void PlayerTakeDamage()
    {
        if (playerAttributes.shield)
        {
            //lose shield
        }
        else
            PlayerDeath();
    }

    void RespawnPlayer()
    {
        //enable player
        //disable input and shoot
        //play respawn animation
        //on end, enable input and shoot
    }
}
