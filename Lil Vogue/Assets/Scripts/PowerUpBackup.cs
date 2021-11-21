using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpsandDowns
{
    buildingEnlarge,
    characterAccelerate,
    glue

}

public class PowerUpBackup : MonoBehaviour
{
    public PowerUpsandDowns powerType;
    public float Multiplier;
    public float boostDuration;
    public float enlargeDuration;
    public float glueDuration;
    private Box blox;
    private GameObject box;

    private void Update()
    {
        Destroy(gameObject, 3);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("duar");
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D Player)
    {
        switch (powerType)
        {
            case PowerUpsandDowns.characterAccelerate:
                PlayerScript stats = Player.GetComponent<PlayerScript>();
                stats.speed *= Multiplier;

                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<CircleCollider2D>().enabled = false;

                yield return new WaitForSeconds(boostDuration);

                stats.speed /= Multiplier;

                Destroy(gameObject);

                break;
            case PowerUpsandDowns.buildingEnlarge:
                GameObject box = GameObject.Find("Square");
                if (box != null)
                {
                    Box x = box.GetComponent<Box>();
                    x.move_Speed *= Multiplier;

                    GetComponent<SpriteRenderer>().enabled = false;
                    GetComponent<CircleCollider2D>().enabled = false;

                    yield return new WaitForSeconds(enlargeDuration);

                    x.move_Speed /= Multiplier;

                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("sadge");
                }
                break;
            case PowerUpsandDowns.glue:
                {
                    blox.frozen();
                    GetComponent<SpriteRenderer>().enabled = false;
                    GetComponent<CircleCollider2D>().enabled = false;
                    yield return new WaitForSeconds(glueDuration);
                    Destroy(gameObject);
                }
                break;
        }

    }
}
