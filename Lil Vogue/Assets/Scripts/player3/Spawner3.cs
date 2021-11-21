using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3 : MonoBehaviour
{
    public GameObject square3_Prefab;
    public float numbers;
    public Rigidbody2D rb;
    public bool glue;

    // Start is called before the first frame update

    public void SpawnBox3()
    {
        GameObject square3_Obj = Instantiate(square3_Prefab);
        square3_Obj.name = "building";
        Vector3 temp = transform.position;
        temp.z = 0f;
        square3_Obj.transform.position = transform.position;

    }

}
