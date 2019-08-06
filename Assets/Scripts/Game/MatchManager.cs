using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    [SerializeField] PlayerSpawner playerSpawner = null;
    [SerializeField] HUDManager hudManager = null;
    [SerializeField] Countdown countdown = null;

    GameObject playerReference;



    // Start is called before the first frame update
    void Start()
    {
        //get player info
        int index = 0; //temp

        playerReference = playerSpawner.SpawnPlayer(index);

        hudManager.InitializeHUD();

        //subscribe to player ondeath

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

        //start enemy spawn
        //allow player inputs
        //allow player shoot  
    }

    public void PlayerPickupLife()
    {

    }

    public void PlayerDeath()
    {

    }
}
