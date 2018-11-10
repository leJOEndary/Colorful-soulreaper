using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Taxt_manager : MonoBehaviour {

    private player_movement movement_script;
    public Text score;
    public Text Health;

	// Use this for initialization
	void Start () {
        movement_script = GetComponent<player_movement>();    
	}
	
	// Update is called once per frame
	void Update () {
        updateScore();
	}

    void updateScore() {
        score.text = "Souls: " + movement_script.Absolute_score.ToString();
        Health.text = "HP: " + movement_script.score_acc.ToString();
    }
}
