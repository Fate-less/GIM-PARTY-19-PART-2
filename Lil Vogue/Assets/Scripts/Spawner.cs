using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject square_Prefab;

    // Start is called before the first frame update

    public void SpawnBox()
    {
        GameObject square_Obj = Instantiate(square_Prefab);
        Vector3 temp = transform.position;
        temp.z = 0f;
        square_Obj.transform.position = transform.position;
    }
}
