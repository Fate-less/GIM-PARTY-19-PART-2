using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public GameObject square2_Prefab;
    public float numbers;
    public Rigidbody2D rb;
    public bool glue;

    // Start is called before the first frame update

    public void SpawnBox2()
    {
        GameObject square2_Obj = Instantiate(square2_Prefab);
        square2_Obj.name = "building";
        Vector3 temp = transform.position;
        temp.z = 0f;
        square2_Obj.transform.position = transform.position;

    }

}
