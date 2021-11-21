using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box2 : MonoBehaviour
{
    private Rigidbody2D boxBody2;
    private float min_X = -5f, max_X = 5f;
    private bool canMove2;
    public float move_Speed = 4f;
    private bool gameOver2;
    private bool ignoreCollision2;
    private bool ignoreTrigger2;
    public bool isFrozen = false;
    public string Game, MobiGame;
    private Scene scene2;

    private void Awake()
    {
        boxBody2 = GetComponent<Rigidbody2D>();
        boxBody2.gravityScale = 0f;
    }

    private void Start()
    {
        canMove2 = true;
        scene2 = SceneManager.GetActiveScene();
        Debug.Log("Name: " + scene2.name);

        if (Random.Range(0, 2) > 0)
        {
            move_Speed *= -1f;
        }

        GameController2.instance.currentBox2 = this;
    }

    private void Update()
    {
        MoveBox2();
    }

    void MoveBox2()
    {
        if (canMove2)
        {
            Vector3 temp = transform.position;
            temp.x += move_Speed * Time.deltaTime;
            if (temp.x > max_X)
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

    public void DropBox2()
    {
        canMove2 = false;
        boxBody2.gravityScale = Random.Range(2, 4);
    }

    void Landed2()
    {
        if (gameOver2)
            return;

        ignoreCollision2 = true;
        ignoreTrigger2 = true;

        GameController2.instance.SpawnNewBox2();
        GameController2.instance.MoveCamera2();
        ScoreScript.instance.scoreCount();
    }

    void LandedFreeze2()
    {
        if (gameOver2)
            return;

        ignoreCollision2 = true;
        ignoreTrigger2 = true;

        GameController2.instance.SpawnNewBox2();
        GameController2.instance.MoveCamera2();
        ScoreScript.instance.scoreCount();
        frozen();
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreCollision2)
        {
            return;
        }
        if (target.gameObject.tag == "Square" && isFrozen)
        {
            Invoke("LandedFreeze2", 1f);
            ignoreCollision2 = true;
            Debug.Log("frozen box");
        }
        if (target.gameObject.tag == "Square" && !isFrozen)
        {
            Invoke("Landed2", 1f);
            ignoreCollision2 = true;
            Debug.Log("normal box");
        }
    }

    void OnCollisionExit2D(Collision2D target)
    {
        CancelInvoke("Landed2");
        gameOver2 = true;
        ignoreTrigger2 = false;
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "GameEnd")
        {
            CancelInvoke("Landed2");
            gameOver2 = true;
            ignoreTrigger2 = true;
            Scene scene2 = SceneManager.GetActiveScene();
            if (scene2.name == "Game")
            {
                SceneManager.LoadScene(2);
            }
            if (scene2.name == "MobiGame")
            {
                SceneManager.LoadScene(6);
            }
        }
        if (ignoreTrigger2)
        {
            return;
        }
        if (target.tag == "GameOver")
        {
            CancelInvoke("Landed2");
            gameOver2 = true;
            ignoreTrigger2 = true;
            Scene scene2 = SceneManager.GetActiveScene();
            if (scene2.name == "Game")
            {
                isFrozen = false;
                SceneManager.LoadScene(2);
            }
            if (scene2.name == "MobiGame")
            {
                isFrozen = false;
                SceneManager.LoadScene(6);
            }
        }

    }
    public void frozen()
    {
        boxBody2.gravityScale = 0f;
        GetComponent<Rigidbody2D>().constraints =
        RigidbodyConstraints2D.FreezeAll;
        Debug.Log("iceiceice");
    }

    //public void melt()
    //{
    //    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    //}
}
