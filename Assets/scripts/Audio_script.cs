using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_script : MonoBehaviour {

    public AudioSource Matching_Source;
    public AudioSource Non_Matching_Source;
    public AudioSource Color_Change_Source;
    

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playMatchingHit() {
        Matching_Source.Play();
    }
    public void playNonMatchingHit() {
        Non_Matching_Source.Play();
    }
    public void playColorChange() {
        Color_Change_Source.Play();
    }

    public void MuteFX(){
        Matching_Source.volume = 0;
        Non_Matching_Source.volume = 0;
        Color_Change_Source.volume = 0;
    }
}
