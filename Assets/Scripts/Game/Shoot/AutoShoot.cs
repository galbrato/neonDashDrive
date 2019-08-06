using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    [SerializeField] float shootRate = 0;
    [SerializeField] float shootMultiplier = 0;

    [SerializeField] Vector3[] spawnPositions = null;
    [SerializeField] Vector3[] velocities = null;

    [SerializeField] GameObject projectilesPrefab = null;

    Transform projectilesParent;

    float currentTime;
    GameObject obj;
    [SerializeField] bool canShoot = false;

    void Awake()
    {
        projectilesParent = GameObject.Find("_Projectiles").transform;

        currentTime = shootRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShoot) return;

        currentTime -= Time.deltaTime;

        if(currentTime <= 0)
        {
            for (int i = 0; i < spawnPositions.Length; i++)
            {
                obj = Instantiate(projectilesPrefab, transform.position + spawnPositions[i], Quaternion.identity, projectilesParent);
                obj.GetComponent<Rigidbody2D>().velocity = velocities[i];
                //obj.GetComponent<ProjectileBehaviour>().myShooter = gameObject;
            }

            currentTime = shootRate;
        }
    }

    public void ToggleShoot()
    {
        canShoot = !canShoot;
    }

    /*public void ChangeFormation(Player.ShotFormation newFormation)
    {
        spawnPositions = newFormation.positions;
        velocities = newFormation.velocities;
    }*/


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            Gizmos.DrawWireCube(transform.position + spawnPositions[i], new Vector3(0.1f, 0.1f, 0));
        }
    }
}
