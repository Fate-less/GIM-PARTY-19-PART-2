using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Spawner box_Spawner;
    public CameraScript cameraScript;
    private int moveCount;
    [HideInInspector]
    public Box currentBox;
    public float cameraFollow;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        box_Spawner.SpawnBox();
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput();
    }

    void DetectInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentBox.DropBox();
        }
    }
    
    public void SpawnNewBox()
    {
        Invoke("NewBox", 1f);
    }

    public void NewBox()
    {
        box_Spawner.SpawnBox();
    }

    public void MoveCamera()
    {
        moveCount++;
        if(moveCount == 2)
        {
            moveCount = 0;
            cameraScript.targetPos.y += cameraFollow;
        }
    }
}
