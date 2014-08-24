using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {
	// Use this for initialization
	public int life = 100;
	//public float speed = (Time.timeSinceLevelLoad * 0.05f) + 0.05f; -Roger: I'll explain this later!
	void Start () {
		life = 100;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-0.5f,0,0);
		life--;
		if(life == 1) { Destroy(gameObject); }
	}

	
}
