using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box : MonoBehaviour
{
    private Rigidbody2D boxBody;
    private float min_X = -5f, max_X = 5f;
    private bool canMove;
    public float move_Speed = 4f;
    private bool gameOver;
    private bool ignoreCollision;
    private bool ignoreTrigger;
    public string Game, MobiGame;
    private Scene scene;

    private void Awake()
    {
        boxBody = GetComponent<Rigidbody2D>();
        boxBody.gravityScale = 0f;
    }

    private void Start()
    {
        canMove = true;
        scene = SceneManager.GetActiveScene();
        Debug.Log("Name: " + scene.name);

        if (Random.Range(0, 2) > 0)
        {
            move_Speed *= -1f;
        }

        GameController.instance.currentBox = this;
    }

    private void Update()
    {
        MoveBox();
    }

    void MoveBox()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += move_Speed * Time.deltaTime;
            if(temp.x > max_X)
            {
                move_Speed *= -1f;
            }
            else if (temp.x < min_X)
            {
                move_Speed *= -1f;
            }

            transform.position = temp;
        }
    }

    public void DropBox()
    {
        canMove = false;
        boxBody.gravityScale = Random.Range(2, 4);
    }

    void Landed()
    {
        if (gameOver)
            return;

        ignoreCollision = true;
        ignoreTrigger = true;

        GameController.instance.SpawnNewBox();
        GameController.instance.MoveCamera();
        ScoreScript.instance.scoreCount();
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreCollision)
        {
            return;
        }
        if(target.gameObject.tag == "Platform")
        {
            Invoke("Landed", 1f);
            ignoreCollision = true;
        }
        if (target.gameObject.tag == "Square")
        {
            Invoke("Landed", 1f);
            ignoreCollision = true;
        }
    }

    void OnCollisionExit2D(Collision2D target)
    {
        CancelInvoke("Landed");
        gameOver = true;
        ignoreTrigger = false;
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "GameEnd")
        {
            CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Game")
            {
                SceneManager.LoadScene(2);
            }
            if (scene.name == "MobiGame")
            {
                SceneManager.LoadScene(6);
            }
        }
        if (ignoreTrigger)
        {
            return;
        }
        if (target.tag == "GameOver")
        {
            CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Game")
            {
                SceneManager.LoadScene(2);
            }
            if (scene.name == "MobiGame")
            {
                SceneManager.LoadScene(6);
            }
        }
    }
}
