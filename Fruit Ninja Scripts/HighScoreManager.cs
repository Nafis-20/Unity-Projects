using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{
    public int scoreN;
    public int scoreH;
    public Text score;
    public Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void main()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void ScoreUpdate(int updateN)
    {
        scoreN += updateN;
        score.text = scoreN.ToString();

        if (scoreN > scoreH)
        {
            PlayerPrefs.SetInt("HighScore", scoreN);
            highScore.text = "Highest: " + scoreN.ToString();
        }
    }

    public void GetHighScore()
    {
        scoreH = PlayerPrefs.GetInt("HighScore");
        highScore.text = "Highest: " + scoreH.ToString();
    }
}
