using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpsandDowns
{
    platformEnlarge,
    characterAccelerate
}

public class PowerUp : MonoBehaviour
{
    public PowerUpsandDowns powerUporDownType;
    public float Multiplier;
    public float Duration;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("masuk");
        if (other.tag == "Player")
        {
            Debug.Log("yey");
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D Player)
    {

        PlayerScript stats = Player.GetComponent<PlayerScript>();

        switch(powerUporDownType)
        {
            case PowerUpsandDowns.characterAccelerate:
                stats.speed *= Multiplier;

                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<CircleCollider2D>().enabled = false;

                yield return new WaitForSeconds(Duration);

                stats.speed /= Multiplier;

                Destroy(gameObject);

                break;
        }

    }
}
