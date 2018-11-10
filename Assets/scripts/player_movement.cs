using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour {

    public int score_acc;
    public int Absolute_score;

    int forward_speed;
    float x_pos;
    int horizontal_speed;
    float speed_multiplier;

	// Use this for initialization
	void Start () {
        forward_speed = 10;
        speed_multiplier = 1;
        score_acc = 0;
        Absolute_score = 0;
        x_pos = 0;
        horizontal_speed = 9;
	}
	
	// Update is called once per frame
	void Update () {

        if (Absolute_score % 10 == 0 && Absolute_score != 0) {
            speed_multiplier += 0.15f;
            score_acc += 1;
            Absolute_score += 1;
        }

        Move();

	}

    void Move() {

        float horizontal = Input.GetAxis("Horizontal") + 3.5f*Input.acceleration.x;
        float z_trans = speed_multiplier * forward_speed * Time.deltaTime;
        float x_trans = speed_multiplier * horizontal_speed * horizontal * Time.deltaTime;

        if ((x_pos + x_trans < 2.5) && (x_pos + x_trans > -2.5))
        {
            transform.Translate(x_trans, 0f, 0f);
            x_pos += x_trans;
        }

        transform.Translate(0f, 0f, z_trans,Space.World);
    }

}
