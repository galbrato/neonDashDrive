using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCannonBehaviour : MonoBehaviour
{
    public float ChargeDuration = 0.5f;
    public float ShootDuration = 0;
    bool isShooting;
    [SerializeField] SpriteRenderer Sprite;

    [SerializeField] float MaxLaserSize = 20f;

    private void Awake() {
    }
    
    // Update is called once per frame
    void Update(){
        /*
        if (ShootDuration > 0) {
            if (!isShooting) {
                isShooting = true;
                ShootDuration += ChargeDuration;
            }
            if (isShooting) {
                
            }
            
        }
        */
        Lazer();
    }

    void Lazer() {
        RaycastHit2D hit = Physics2D.Raycast(
          this.transform.position,
          this.transform.right,
          MaxLaserSize
        );
        if (hit.collider != null) {
            Sprite.size = new Vector2(1f, Vector2.Distance(hit.point, transform.position));
        } else {
            Sprite.size = new Vector2(1f, MaxLaserSize);
        }

    }
}
