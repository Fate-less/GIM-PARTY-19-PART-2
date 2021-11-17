using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawnScript : MonoBehaviour
{
    public GameObject upgrade_Prefab;
    private float spawnTime = Random.Range(3, 10);
    public float spawnDelay;

    private void Awake()
    {
        spawnTime = Random.Range(3, 10);
    }
    private void Start()
    {
        InvokeRepeating("SpawnBuff", spawnTime, spawnDelay);
    }
    public void SpawnBuff()
    {
        GameObject upgrade_Obj = Instantiate(upgrade_Prefab);    
        Vector3 temp = transform.position;
        temp.z = 0f;
        temp.x = Random.Range(0f, 10f);
        temp.y = Random.Range(0f, 5f);

        upgrade_Obj.transform.position = transform.position * Random.Range(-8f, 8f);
    }
}
