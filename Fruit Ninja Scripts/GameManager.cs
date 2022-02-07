using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Score Functions")]
    public int scoreN;
    public int scoreH;
    public Text score;
    public Text highScore;
    public Button playButton;
    public Button pauseButton;
    [Header("Game Over Functions")]
    public GameObject gameOverPanel;
    [Header("Audio Functions")]
    public AudioClip[] audioClip;
    public AudioClip bombClip;
    public AudioClip startClip;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GetHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioSound()
    {
        AudioClip rand = audioClip[Random.Range(0, audioClip.Length)];
        audioSource.PlayOneShot(rand);
    }

    public void ScoreUpdate(int updateN)
    {
        scoreN += updateN;
        score.text = scoreN.ToString();

        if(scoreN > scoreH)
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

    public void OnBombHit()
    {
        Time.timeScale = 0;
        audioSource.PlayOneShot(bombClip);
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        audioSource.PlayOneShot(startClip);
        SceneManager.LoadSceneAsync(2);
    }

    public void main()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void OnPause()
    {
        Time.timeScale = 0;
        pauseButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
    }

    public void OnPlay()
    {
        Time.timeScale = 1;
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }
}
