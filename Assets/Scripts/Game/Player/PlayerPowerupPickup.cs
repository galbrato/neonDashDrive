using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerupPickup : MonoBehaviour
{
    public delegate void PlayerPowerupDelegate();
    public PlayerPowerupDelegate OnShotPickup;
    public PlayerPowerupDelegate OnShieldPickup;
    public PlayerPowerupDelegate OnBombPickup;
    public PlayerPowerupDelegate OnLifePickup;

    public void IncrementShotLevel()
    {
        OnShotPickup?.Invoke();
    }

    public void AddShield()
    {
        OnShieldPickup?.Invoke();
    }

    public void AddBomb()
    {
        OnBombPickup?.Invoke();
    }

    public void AddLife()
    {
        OnLifePickup?.Invoke();
    }
}
