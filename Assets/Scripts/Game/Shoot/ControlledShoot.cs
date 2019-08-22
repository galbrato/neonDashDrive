using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledShoot : MonoBehaviour
{
    [SerializeField] Vector3[] spawnPositions = null;

    [SerializeField] GameObject projectilesPrefab = null;
    Transform projectilesParent;
    GameObject obj;

    bool canShoot = true;

    void Awake()
    {
        projectilesParent = GameObject.Find("_Projectiles").transform;
        GetComponent<TakeDamage>().OnTakeDamage += EnemyDead;
    }

    public void Shoot()
    {
        if (!canShoot)
        {
            return;
        }

        for (int i = 0; i < spawnPositions.Length; i++)
        {
            obj = Instantiate(projectilesPrefab, transform.position + spawnPositions[i], Quaternion.identity, projectilesParent);
            obj.GetComponent<ProjectileBehaviour>().myShooter = gameObject;
        }
    }

    public void EnemyDead()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        canShoot = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            Gizmos.DrawWireCube(transform.position + spawnPositions[i], new Vector3(0.1f, 0.1f, 0));
        }
    }
}
