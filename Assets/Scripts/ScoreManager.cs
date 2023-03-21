using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    public float scoreCount;
    public float highScoreCount;

    public float pointPerSec;

    public bool scoreIncreasing;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Highscore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("Highscore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointPerSec * Time.deltaTime;
        }
        if(scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("Highscore", highScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round (scoreCount);
        highScoreText.text = "Highscore: " + Mathf.Round (highScoreCount);
    }

    public void AddScore (int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }

}