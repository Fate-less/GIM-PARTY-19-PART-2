using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController3 : MonoBehaviour
{
    public static GameController3 instance;
    public Spawner3 box_Spawner3;
    public CameraScript cameraScript;
    private int moveCount;
    [HideInInspector]
    public Box3 currentBox3;
    public float cameraFollow;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        box_Spawner3.SpawnBox3();
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput3();
    }

    void DetectInput3()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentBox3.DropBox3();
        }
    }

    public void SpawnNewBox3()
    {
        Invoke("NewBox3", 1f);
    }

    public void NewBox3()
    {
        box_Spawner3.SpawnBox3();
    }

    public void MoveCamera3()
    {
        moveCount++;
        if (moveCount == 2)
        {
            moveCount = 0;
            cameraScript.targetPos.y += cameraFollow;
        }
    }
}
