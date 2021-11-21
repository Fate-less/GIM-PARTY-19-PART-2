using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box3 : MonoBehaviour
{
    private Rigidbody2D boxBody3;
    private float min_X = -5f, max_X = 5f;
    private bool canMove3;
    public float move_Speed = 4f;
    private bool gameOver3;
    private bool ignoreCollision3;
    private bool ignoreTrigger3;
    public bool isFrozen = false;
    public string Game, MobiGame;
    private Scene scene3;

    private void Awake()
    {
        boxBody3 = GetComponent<Rigidbody2D>();
        boxBody3.gravityScale = 0f;
    }

    private void Start()
    {
        canMove3 = true;
        scene3 = SceneManager.GetActiveScene();
        Debug.Log("Name: " + scene3.name);

        if (Random.Range(0, 2) > 0)
        {
            move_Speed *= -1f;
        }

        GameController3.instance.currentBox3 = this;
    }

    private void Update()
    {
        MoveBox3();
    }

    void MoveBox3()
    {
        if (canMove3)
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

    public void DropBox3()
    {
        canMove3 = false;
        boxBody3.gravityScale = Random.Range(2, 4);
    }

    void Landed3()
    {
        if (gameOver3)
            return;

        ignoreCollision3 = true;
        ignoreTrigger3 = true;

        GameController3.instance.SpawnNewBox3();
        GameController3.instance.MoveCamera3();
        ScoreScript.instance.scoreCount();
    }

    void LandedFreeze3()
    {
        if (gameOver3)
            return;

        ignoreCollision3 = true;
        ignoreTrigger3 = true;

        GameController3.instance.SpawnNewBox3();
        GameController3.instance.MoveCamera3();
        ScoreScript.instance.scoreCount();
        frozen();
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreCollision3)
        {
            return;
        }
        if (target.gameObject.tag == "Square" && isFrozen)
        {
            Invoke("LandedFreeze3", 1f);
            ignoreCollision3 = true;
            Debug.Log("frozen box");
        }
        if (target.gameObject.tag == "Square" && !isFrozen)
        {
            Invoke("Landed3", 1f);
            ignoreCollision3 = true;
            Debug.Log("normal box");
        }
    }

    void OnCollisionExit2D(Collision2D target)
    {
        CancelInvoke("Landed3");
        gameOver3 = true;
        ignoreTrigger3 = false;
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "GameEnd")
        {
            CancelInvoke("Landed3");
            gameOver3 = true;
            ignoreTrigger3 = true;
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
        if (ignoreTrigger3)
        {
            return;
        }
        if (target.tag == "GameOver")
        {
            Debug.Log("GameOver");
            CancelInvoke("Landed3");
            gameOver3 = true;
            ignoreTrigger3 = true;
            Scene scene3 = SceneManager.GetActiveScene();
            if (scene3.name == "Game")
            {
                isFrozen = false;
                SceneManager.LoadScene(2);
            }
            if (scene3.name == "MobiGame")
            {
                isFrozen = false;
                SceneManager.LoadScene(6);
            }
            if (scene3.name == "PaimonGame")
            {
                isFrozen = false;
                SceneManager.LoadScene(9);
            }
        }

    }
    public void frozen()
    {
        boxBody3.gravityScale = 0f;
        GetComponent<Rigidbody2D>().constraints =
        RigidbodyConstraints2D.FreezeAll;
        Debug.Log("iceiceice");
    }

    //public void melt()
    //{
    //    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    //}
}
