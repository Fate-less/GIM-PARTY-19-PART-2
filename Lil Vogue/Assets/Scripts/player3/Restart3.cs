using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart3 : MonoBehaviour
{
    private Scene scene;
    public void restartGame()
    {
        SceneManager.LoadScene(8);
    }
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        Debug.Log("Name: " + scene.name);
    }
}
