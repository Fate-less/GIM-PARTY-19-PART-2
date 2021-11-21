using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController2 : MonoBehaviour
{
    public static GameController2 instance;
    public Spawner2 box_Spawner2;
    public CameraScript cameraScript;
    private int moveCount;
    [HideInInspector]
    public Box2 currentBox2;
    public float cameraFollow;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        box_Spawner2.SpawnBox2();
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput2();
    }

    void DetectInput2()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentBox2.DropBox2();
        }
    }

    public void SpawnNewBox2()
    {
        Invoke("NewBox2", 1f);
    }

    public void NewBox2()
    {
        box_Spawner2.SpawnBox2();
    }

    public void MoveCamera2()
    {
        moveCount++;
        if (moveCount == 2)
        {
            moveCount = 0;
            cameraScript.targetPos.y += cameraFollow;
        }
    }
}
