using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] enum ProjectileType
    {
        STRAIGHT
    }

    [SerializeField] ProjectileType projectileType;
    Rigidbody2D rigid;

    [SerializeField] Vector2 velocity = new Vector2(0,0);

    [HideInInspector] public GameObject myShooter = null;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        switch(projectileType)
        {
            case ProjectileType.STRAIGHT:
                rigid.velocity = velocity;
                break;
        }
    }
}
