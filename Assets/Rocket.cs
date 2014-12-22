using UnityEngine;
using System.Collections;


public class Rocket : MonoBehaviour {
	// Use this for initialization
	public int life;
	//public float speed = (Time.timeSinceLevelLoad * 0.05f) + 0.05f; -Roger: I'll explain this later!
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-0.05f,0,0);
		life--;
		if(life == 1) { Destroy(gameObject); }
	}

	void OnTriggerEnter2D(Collider2D other)
	{
				if (other.gameObject.tag == "Player") {
						//Application.LoadLevel (0);
			other.gameObject.GetComponent<WalkThatWay> ().lose = true;/*
			int current_score = (int) GameObject.FindGameObjectWithTag("score").GetComponent<Points>().point;
			var best_score = 0;
			if(PlayerPrefs.HasKey("Score"))
			{
				best_score = PlayerPrefs.GetInt("Score");
				
			}
			//If theres a new high score then set it
			if(current_score > best_score)
			{
				PlayerPrefs.SetInt("Score",current_score);
				PlayerPrefs.Save();
				
			}
			GUI.Box(new Rect(Screen.width /3 , Screen.height/3 , 150, 150), "Current Score: " + current_score.ToString() + "\n\nBest Score: " +best_score.ToString());
			if(GUI.Button( new Rect(Screen.width/2 - 75, Screen.height, 150,70),"Play Again"))
			{
				
				
				Application.LoadLevel("firstscene");
				//		GUI.EndGroup ();
			}
			
			if(GUI.Button( new Rect(Screen.width, Screen.height, 150,70),"Quit"))
			{
				
				
				Application.LoadLevel(0);
				//		GUI.EndGroup ();
			}
*/
				

				}
		}
		

				


}
