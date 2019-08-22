using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledEnemyShoot : MonoBehaviour
{
    [SerializeField] ControlledShoot[] EnemyChildren = null;

    public void MakeEnemyShoot(int index)
    {
        EnemyChildren[index].Shoot();
    }

    public void MakeAllEnemiesShoot()
    {
        for(int i = 0; i < EnemyChildren.Length; i++)
        {
            EnemyChildren[i].Shoot();
        }
    }
}
