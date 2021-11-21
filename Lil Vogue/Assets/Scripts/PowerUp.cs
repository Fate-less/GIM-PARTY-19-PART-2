using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffDebuff
{
    freeze
}

public class PowerUp : MonoBehaviour
{
    public BuffDebuff powerType;
    public float Multiplier;
    public float Duration;
    public Box abox;
    private GameObject box;

    private void Update()
    {
        Destroy(gameObject, 3);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("buff applied");
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D Player)
    {
        switch(powerType)
        {
            case BuffDebuff.freeze:
                abox.isFrozen = true;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<CircleCollider2D>().enabled = false;
                Debug.Log("frozen");
                yield return new WaitForSeconds(Duration);
                abox.isFrozen = false;
                break;
            
        }
        
    }
}
