using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject square_Prefab;
    public float numbers;
    public Rigidbody2D rb;
    public bool glue;

    // Start is called before the first frame update

    public void SpawnBox()
    {
        GameObject square_Obj = Instantiate(square_Prefab);
        square_Obj.name = "building";
        Vector3 temp = transform.position;
        temp.z = 0f;
        square_Obj.transform.position = transform.position;
        
    }

}
