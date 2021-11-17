using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpsandDowns
{
    buildingEnlarge,
    characterAccelerate
}

public class PowerUp : MonoBehaviour
{
    public PowerUpsandDowns powerType;
    public float Multiplier;
    public float Duration;
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
        switch(powerType)
        {
            case PowerUpsandDowns.characterAccelerate:
                PlayerScript stats = Player.GetComponent<PlayerScript>();
                stats.speed *= Multiplier;

                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<CircleCollider2D>().enabled = false;

                yield return new WaitForSeconds(Duration);

                stats.speed /= Multiplier;

                Destroy(gameObject);

                break;
            case PowerUpsandDowns.buildingEnlarge:
                GameObject box = GameObject.Find("Square");
                if(box != null)
                {
                    Box x = box.GetComponent<Box>();
                    x.move_Speed *= Multiplier;

                    GetComponent<SpriteRenderer>().enabled = false;
                    GetComponent<CircleCollider2D>().enabled = false;

                    yield return new WaitForSeconds(Duration);

                    x.move_Speed /= Multiplier;

                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("sadge");
                }

                break;
        }
        
    }
}
