using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Switch : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject TopCamera;

    bool main_active = true;
	// Use this for initialization
	void Start () {
        MainCamera.SetActive(main_active);
        TopCamera.SetActive(false);
        TopCamera.GetComponent<AudioListener>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.C)) {
            toggleCamera(); 
        }

        MainCamera.SetActive(main_active);
        TopCamera.SetActive(!main_active);
	}

    public void  toggleCamera(){
        main_active = !main_active;
    }
}
