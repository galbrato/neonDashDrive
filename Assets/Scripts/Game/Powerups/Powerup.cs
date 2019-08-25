using UnityEngine;

public class Powerup : MonoBehaviour
{
    float angularVelocity;
    public float maxVelocity;
    public float minVelocity;

    public float moveSpeed;

    public PowerupType myType;

    public enum PowerupType
    {
        SHOT,
        SHIELD,
        BOMB,
        LIFE
    }

    Transform child;

    private void Awake()
    {
        angularVelocity = Random.Range(minVelocity, maxVelocity);
        if(Random.value >= 0.5f)
        {
            angularVelocity = -angularVelocity;
        }
        child = transform.GetChild(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        child.Rotate(new Vector3(0, 0, 1), angularVelocity);
        transform.Translate(Vector3.down*moveSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            PlayerPowerupPickup pl = collision.GetComponent<PlayerPowerupPickup>();
            switch (myType)
            {
                case PowerupType.SHOT:
                    pl.IncrementShotLevel();
                break;
                case PowerupType.SHIELD:
                    pl.AddShield();
                break;
                case PowerupType.BOMB:
                    pl.AddBomb();
                break;
                case PowerupType.LIFE:
                    pl.AddLife();
                break;
            }
            Destroy(gameObject);
        }
    }
}
