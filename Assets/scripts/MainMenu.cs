using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class MainMenu : MonoBehaviour {

    public Text HighScore;

    bool muted;
    public AudioMixer mixer;
	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectWithTag("OptionsCanvas").GetComponent<Canvas>().enabled = false;
        //PlayerPrefs.SetInt("HighScore", 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void toggleMute()
    {
        if (muted)
        {
            mixer.SetFloat("masterVol", 0f);
        }
        else
        {
            mixer.SetFloat("masterVol", -80f);
        }
        muted = !muted;
    }


    public void startGame() {
        SceneManager.LoadScene("Gameplay");
    }

    public void toOptions() {
        GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("OptionsCanvas").GetComponent<Canvas>().enabled = true;

        HighScore.text = "Current Highscore\n"+PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void back() {
        GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>().enabled = true;
        GameObject.FindGameObjectWithTag("OptionsCanvas").GetComponent<Canvas>().enabled = false;
    }

}
