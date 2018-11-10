using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class player_color : MonoBehaviour {

    
    Material m_Material;
    string color_tag;
    player_movement movement_script;
    Audio_script audio_script;

    public DeathMenu deathMenu;
    public PauseMenu pauseMenu;

    
	// Use this for initialization
	void Start () {
        //Fetch the Material from the Renderer of the GameObject
        m_Material = GetComponent<Renderer>().material;
        m_Material.color = Color.red;
        color_tag = "Red";
        movement_script = GetComponent<player_movement>();
        audio_script = GetComponent<Audio_script>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.gamePaused)
                pauseMenu.Resume();       
            else
                pauseMenu.Pause();
            
        }
	}

    void OnTriggerExit(Collider Area)
    {
        if (Area.gameObject.CompareTag("BlueArea")) {
            m_Material.color = Color.blue;
            color_tag = "Blue";
            audio_script.playColorChange();
        }
        else if (Area.gameObject.CompareTag("GreenArea")){
            m_Material.color = Color.green;
            color_tag = "Green";
            audio_script.playColorChange();
        }
        else if (Area.gameObject.CompareTag("RedArea"))
        {
            m_Material.color = Color.red;
            color_tag = "Red";
            audio_script.playColorChange();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        string collided_with_tag = col.gameObject.tag;
        if (collided_with_tag == "Red" || collided_with_tag == "Blue" || collided_with_tag == "Green")
        {
            Destroy(col.gameObject);

            if (col.gameObject.CompareTag(color_tag))
            {
                movement_script.score_acc += 10;
                movement_script.Absolute_score += 1;
                audio_script.playMatchingHit();
            }
            else if (movement_script.score_acc > 1)
                {
                    movement_script.score_acc = movement_script.score_acc / 2;
                    audio_script.playNonMatchingHit();
                }
                else {
                    audio_script.MuteFX();
                    GameObject.FindGameObjectWithTag("GameMusic").GetComponent<AudioSource>().Stop();
                    deathMenu.showDeathMenu(movement_script.Absolute_score);
                    this.enabled = false;
                }
            

            
        }
    }
}
