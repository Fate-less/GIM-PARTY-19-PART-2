using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawnScript : MonoBehaviour
{
    public GameObject upgrade_Prefab;
    private float spawnTime;
    public float spawnDelay;

    private void Awake()
    {
        spawnDelay = 1 * Random.Range(15, 30);
        spawnTime = 1 * Random.Range(15, 30);
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
        temp.x = Random.Range(-9, 9);
        upgrade_Obj.transform.position = temp;
    }
}
