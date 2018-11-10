using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public bool gamePaused = false;
    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void Pause()
    {
        GameObject.FindGameObjectWithTag("GameMusic").GetComponent<AudioSource>().Pause();
        GameObject.FindGameObjectWithTag("GameUI").GetComponent<Canvas>().enabled = false;
        gameObject.SetActive(true);
        Time.timeScale = 0;
        gamePaused = !gamePaused;
    }

    public void Resume() {
        GameObject.FindGameObjectWithTag("GameMusic").GetComponent<AudioSource>().UnPause();
        GameObject.FindGameObjectWithTag("GameUI").GetComponent<Canvas>().enabled = true;
        gameObject.SetActive(false);
        Time.timeScale = 1;
        gamePaused = !gamePaused;
    }


    public void Restart()
    {
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
