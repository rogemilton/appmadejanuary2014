﻿using UnityEngine;
using System.Collections;


public class Rocket : MonoBehaviour {
	// Use this for initialization
	public int life;
	//public float speed = (Time.timeSinceLevelLoad * 0.05f) + 0.05f; -Roger: I'll explain this later!
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		bool lost = GameObject.FindGameObjectWithTag ("Player").GetComponent<WalkThatWay> ().lose;
		bool paused = GameObject.FindGameObjectWithTag ("Player").GetComponent<WalkThatWay> ().onPause;
		if (!lost && !paused) {
			transform.Translate (-0.05f, 0, 0);
			life--;
			if (life == 1) {
					Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<WalkThatWay>().lose = true;
		}
	}
}
