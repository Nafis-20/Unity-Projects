using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public AudioClip start;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        Time.timeScale = 1;
        GetComponent<AudioSource>().PlayOneShot(start);
        SceneManager.LoadScene(2);
    }

    public void high()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void exit()
    {
        Application.Quit();
    }
}
