using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {
	// Use this for initialization
	public int life = 100;
	void Start () {
		life = 100;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-1,0,0);
		life--;
		if(life == 1) { Destroy(gameObject); }
	}

	
}
