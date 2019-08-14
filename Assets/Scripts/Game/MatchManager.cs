using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    [SerializeField] PlayerSpawner playerSpawner = null;

    [SerializeField] EnemySpawner enemySpawner = null;
    [SerializeField] HUDManager hudManager = null;
    [SerializeField] Countdown countdown = null;
    //[SerializeField] PlayerAttributes playerAttributes = new PlayerAttributes();

    GameObject playerReference;

    bool shield = false; //temp
    int shotLevel = 1; //temp

    [Space(20)]
    [SerializeField] ScreenShake screenShake;

    // Start is called before the first frame update
    void Start()
    {
        //get player info
        int index = 0; //temp

        playerReference = playerSpawner.SpawnPlayer(index);

        PlayerPowerupPickup powerupScript = playerReference.GetComponent<PlayerPowerupPickup>();
        powerupScript.OnShotPickup += IncrementShotLevel;
        powerupScript.OnShieldPickup += AddShield;
        powerupScript.OnBombPickup += AddBomb;
        powerupScript.OnLifePickup += AddLife;

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

    //player methods
    
    public void PlayerDeath()
    {

        ExplosionSpawner.instance.SpawnPrefab(0, playerReference.transform.position);

        screenShake.Shake(0.5f);
#if UNITY_ANDROID
        Handheld.Vibrate();
#endif

        playerReference.SetActive(false);
        StartCoroutine(DeathDelay());
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(0.5f);
        playerSpawner.RespawnPlayer(playerReference);
    }

    //change this to inside the player behaviour
    public void PlayerTakeDamage()
    {
        //if (playerAttributes.shield)
        if (shield)
        {
            shield = false;
            //disable shield
        }
        else
        {
            PlayerDeath();
        }
    }

    public void IncrementShotLevel()
    {
        hudManager.UpdateScore(PointsLookupTable.instance.FetchPointValue("GetShot"));
        if(shotLevel < 5) shotLevel++;
        //change shot
    }

    public void AddShield()
    {
        hudManager.UpdateScore(PointsLookupTable.instance.FetchPointValue("GetShield"));
        //playerAttributes.shield = true;
        shield = true;
        //enable shield
    }

    public void AddBomb()
    {
        hudManager.UpdateScore(PointsLookupTable.instance.FetchPointValue("GetBomb"));
        hudManager.UpdateBombs(1);
    }

    public void AddLife()
    {
        hudManager.UpdateScore(PointsLookupTable.instance.FetchPointValue("GetLife"));
        hudManager.UpdateLives(1);
    }
}
