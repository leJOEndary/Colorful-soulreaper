using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DeathMenu : MonoBehaviour {

    public Text final_score;
    public Text high_score;

    

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
    public void showDeathMenu(int score) {
        GameObject.FindGameObjectWithTag("GameUI").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<Canvas>().enabled = false;
        final_score.text = "Souls Collected \n" + score.ToString();

        int current_high = PlayerPrefs.GetInt("HighScore",0);
        if (score > current_high) {
            PlayerPrefs.SetInt("HighScore", score);
            high_score.text = "**New Highscore**\n" + score.ToString();
        }
        else
            high_score.text = "Highscore\n" + PlayerPrefs.GetInt("HighScore", 0);

        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart() {
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1;
    }

    public void ToMainMenu() {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
