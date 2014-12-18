using UnityEngine;
using System.Collections;


public class Rocket : MonoBehaviour {
	// Use this for initialization
	public int life = 1450;
	//public float speed = (Time.timeSinceLevelLoad * 0.05f) + 0.05f; -Roger: I'll explain this later!
	void Start () {
		life = 1450;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-0.05f,0,0);
		life--;
		if(life == 1) { Destroy(gameObject); }
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "mainChar") 
		{
			//GameObject.FindGameObjectWithTag("score").GetComponent<Points>();
			Application.LoadLevel(0);

		}
	}
}
