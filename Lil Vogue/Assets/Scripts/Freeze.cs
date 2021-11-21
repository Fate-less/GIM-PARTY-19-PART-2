using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    public Box abox;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            abox.frozen();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            Debug.Log("frozen");
            Invoke("buffDuration", 5f);
        }
    }

    public void buffDuration()
    {
        //abox.melt();
        Debug.Log("melt");
        Destroy(gameObject);
    }
}
