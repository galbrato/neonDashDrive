using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    [SerializeField] PlayerSpawner playerSpawner = null;
    [SerializeField] HUDManager hudManager = null;

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
                      
    }


    public void EndBriefing()
    {
        //remove subscribe

        StartCountdown();
    }

    public void StartCountdown()
    {
        
        //start countdown script
            //subscribe to onCountdownEnd
    }

    public void EndCountdown()
    {
        //remove subscribe

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
