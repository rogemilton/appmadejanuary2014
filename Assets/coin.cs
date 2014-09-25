using UnityEngine;
using System.Collections;

public class coin : MonoBehaviour {

	// Use this for initialization
	public int life = 150;
	//public float speed = (Time.timeSinceLevelLoad * 0.05f) + 0.05f; -Roger: I'll explain this later!
	void Start () {
		life = 100;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-0.1f,0,0);
		life--;
		if(life == 1) { Destroy(gameObject); }
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.name == "mainChar")
		{
			
			GameObject.FindGameObjectWithTag("score").GetComponent<Points>().point += 10;
			Destroy(gameObject);
			
		}
	}
	

}
