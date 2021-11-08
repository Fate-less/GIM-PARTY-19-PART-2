using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;
    private int scores;
    public Text scoreText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = scores.ToString();
    }
    public void scoreCount()
    {
        scores++;
    }
}
