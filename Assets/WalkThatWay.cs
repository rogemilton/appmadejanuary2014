using UnityEngine;
using System.Collections; 


public class WalkThatWay : MonoBehaviour {
	public GameObject background;
	public GameObject rocket;
	public GameObject projectile;

	float timer1 = .65f;
	float timer2 = .95F;
	float timer3 = 1.25F;
	float timer4 = 1.55F;
	float timer5 = 0.0F;
	public bool lose;
	public Points points;//reference to score

	public Transform musicPrefab;
	// Use this for initialization
	//pause button
	public bool onPause;
	void Start () 
	{ 	
		lose = false;
		onPause = false;
		Time.timeScale = 1f;
		if(!GameObject.FindGameObjectWithTag("Music"))
		{
			var mManager = Instantiate(musicPrefab, transform.position, Quaternion.identity) as Transform; 
			mManager.name = musicPrefab.name;
			DontDestroyOnLoad(mManager);
		}
		//keep the character from falling off the fucking screen
		//all the goddamn time!!
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		
	}
	
	// Update is called once per frame
	void Update() 
	{   
		if (!lose) {

						if (!onPause) {
								Accelerate (0.001f);
								//insantiate rockets according to this script
								makeItHard ();
								if (Input.touchCount > 0) {
										Time.timeScale = 0f;
										onPause = true;
								}

						} else {
								if (Input.touchCount > 0) {
										Time.timeScale = 1f;
										onPause = false;
								}

						}
				}
	
	
	}
	//as the user's points increase, 
	//I will kill him
	void makeItHard()
	{   if (GameObject.FindGameObjectWithTag ("score").GetComponent<Points> ().point > 2) {
			timer2 -= Time.deltaTime;
			timer1 -= Time.deltaTime;
			timer3 -= Time.deltaTime;
			timer4 -= Time.deltaTime;
						if (timer1 <= 0) {
								timer1 = .7f;
								Rockets ();
								
						}
						if (timer2 <= 0) {
								timer2 = 95f;
								Rockets ();
						}

			if (timer3 <= 0) {
				timer3 = 1.2f;
				Rockets ();
				
			}
			if (timer4 <= 0) {
				timer4 = 1.45f;
				Rockets ();
			}
				}
			
		/*
		if( GameObject.FindGameObjectWithTag("score").GetComponent<Points>().point > 6)
		{
			
			if( timer2 <= 0 )
			{
				timer2 = 1.45F;
				Rockets();
			}
			if( GameObject.FindGameObjectWithTag("score").GetComponent<Points>().point > 10)
			{
				timer3 -= Time.deltaTime;
				if( timer3 <= 0)
				{
					timer3 = 1.7F;
					Rockets();

				}
				
				if( GameObject.FindGameObjectWithTag("score").GetComponent<Points>().point > 15)
				{
					timer3 -= Time.deltaTime;
					if( timer3 <= 0)
					{
						timer3 = 2.3F;
						Rockets();
					}
					if( GameObject.FindGameObjectWithTag("score").GetComponent<Points>().point > 27)
					{
						timer4 -= Time.deltaTime;
						if( timer4 <= 0)
						{
							timer4 = 2.7F;
							Rockets();
							if(GameObject.FindGameObjectWithTag("score").GetComponent<Points>().point > 87)
								Rockets ();
						}
					}
					if (GameObject.FindGameObjectWithTag("score").GetComponent<Points>().point > 45)
					    {

						timer5 -= Time.deltaTime;
						if(timer5 <= 0)
						{
							timer5 = 3.0f;
							Rockets();
							if(GameObject.FindGameObjectWithTag("score").GetComponent<Points>().point > 100)
								Rockets ();

						}
					}
				}
			}
		}
*/
	}


    void Rockets()
	{
		if(!lose)
		{   Random.seed = (int)System.DateTime.Now.Ticks;
			//make two rockets
			Vector3 instants = new Vector3 (11.0f,Random.Range(0f,7.05f),0.0f);
			Instantiate(rocket, instants,Quaternion.identity);
			if(Random.Range (0,5) == 2)
			{

				instants = new Vector3 (11.0f,Random.Range(0f,7.05f),0.0f);
				Instantiate(rocket, instants,Quaternion.identity);
			
			}

		}
	}

	
	void Accelerate(float modifier)
	{
		if(!onPause)
		  transform.Translate(Input.acceleration.x,(Input.acceleration.y)+0.5f,0);
	}
	
	void OnGUI()
	{
		if (lose) {
						
						int current_score = (int)GameObject.FindGameObjectWithTag ("score").GetComponent<Points> ().point;
						var best_score = 0;
						if (PlayerPrefs.HasKey ("Score")) {
								best_score = PlayerPrefs.GetInt ("Score");

						}
						//If theres a new high score then set it
						if (current_score > best_score) {
								PlayerPrefs.SetInt ("Score", current_score);
								PlayerPrefs.Save ();

						}
						GUI.Box (new Rect (Screen.width / 2 - 75, Screen.height / 3, 150, 150), "Current Score: " + current_score.ToString () + "\n\nBest Score: " + best_score.ToString ());
						if (GUI.Button (new Rect (Screen.width / 2 - 155 , Screen.height - 75,  150, 70), "Play Again")) {

				

								Random.seed = (int)System.DateTime.Now.Ticks;
								if (Random.Range (1, 4) == 2) 
								{
									AdBuddizBinding.ShowAd();
								}
								Application.LoadLevel ("firstscene");
								//		GUI.EndGroup ();
						}

						if (GUI.Button (new Rect (Screen.width/2 , Screen.height - 75, 150, 70), "Quit")) {
				
				
								Application.LoadLevel (0);
								//		GUI.EndGroup ();
						}

						Time.timeScale = 0f;
					
				}
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "enemy") 
  		{

			Application.LoadLevel(0);		
		}
	}
	void DidHideAd() {
		AdBuddizBinding.LogNative("DidHideAd");
		Debug.Log ("Unity: DidHideAd");
		Application.LoadLevelAsync ("firstscene");
		
	}


}
