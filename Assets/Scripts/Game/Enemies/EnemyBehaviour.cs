using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    bool pointsGained = false;

    private void Awake()
    {
        GetComponent<TakeDamage>().OnTakeDamage += DestroyEnemy;
    }

    public void DestroyEnemy()
    {
        if (!pointsGained)
        {
            HUDManager.instance.UpdateScore(PointsLookupTable.instance.FetchPointValue("KillDrone"));
            EffectsController.instance?.PlayClip("Explosion");
            ExplosionSpawner.instance.SpawnPrefab(0, transform.position);
            pointsGained = true;
        }
        gameObject.SetActive(false);
    }
}
