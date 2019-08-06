using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShootStraight : AutoShoot
{
    [SerializeField] Vector2[] velocities;

    /*public override void ControlVelocity(GameObject[] projectiles)
    {
        for (int i = 0; i < projectiles.Length; i++) {
            projectiles[i].GetComponent<Rigidbody2D>().velocity = velocities[i];
        }
    }*/
}
