using UnityEngine;
using System.Collections; 


public class WalkThatWay : MonoBehaviour {
	public GameObject background;
	public GameObject rocket;
	public GameObject projectile;

	//Start values for the accelerometer
	float start_x = 0f;
	float start_y = 0f;

	//Four rockets go out asynchriously
	float timer1 = .65f;
	float timer2 = .95F;
	float timer3 = 1.25F;
	float timer4 = 1.45F;
	float current_timescale; //Used to speed up the game as the user's points increase
	public bool lose;
	public Points points;//reference to score

	public Transform musicPrefab;
	// Use this for initialization
	//pause button
	public bool onPause;
	void Start () 
	{ 	
		//Assert lose and pause variables are set to  default
		lose = false;
		onPause = false;

		//Assert that the timescale values begin at the default value
		Time.timeScale = 1f;
		current_timescale = 1f;

		//Get start values for the accelerometer
		start_x = Input.acceleration.x;
		start_y = Input.acceleration.y;

		//If no music game object is made
		if(!GameObject.FindGameObjectWithTag("Music"))
		{
			//Make one
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
								makeItHard ();/*
								if (Input.touchCount > 0 ) {
										Time.timeScale = 0f;
										onPause = true;
										
										//System.Threading.Thread.Sleep(500);
										
										//SleepTimeout(1);
								}*/

						} else {/*
								if (Input.touchCount > 0  ) {
										Time.timeScale = 1f;
										onPause = false;
										
										//System.Threading.Thread.Sleep(500);
										
										//SleepTimeout(1);
								}
								//recalibrate input*/
								start_x = Input.acceleration.x;
								start_y = Input.acceleration.y;

						}
				}
	
	
	}
	bool pass1 = false;
	bool pass2 = false;
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
				timer4 = 1.4f;
				Rockets ();
			}
				}

		//Use these settings to adjust the difficulty
		if (GameObject.FindGameObjectWithTag ("score").GetComponent<Points> ().point > 60 && !pass1) {
			current_timescale = 1.5f;
			Time.timeScale = current_timescale;
			pass1 = true;
		}
		else if (GameObject.FindGameObjectWithTag ("score").GetComponent<Points> ().point > 25 && !pass2) {
			current_timescale = 1.2f;
			Time.timeScale = current_timescale;
			pass2 = true;
		}
	}


    void Rockets()
	{
		if(!lose)
		{   Random.seed = (int)System.DateTime.Now.Ticks;
			//make two rockets
			Vector3 instants = new Vector3 (11.0f,Random.Range(0f,7.05f),0.0f);
			Instantiate(rocket, instants,Quaternion.identity);
			//Randomly give double rockets because why not
			//Adjust the range to set the difficulty
			if(Random.Range(0,5) == 4)
			{
				instants = new Vector3 (11.0f,Random.Range(0f,7.05f),0.0f);
				Instantiate(rocket, instants,Quaternion.identity);
			}
			

		}
	}

	
	void Accelerate(float modifier)
	{
		if (!onPause) {

			//Find the direction of the acceleration
			Vector3 dir;
			dir.x = Input.acceleration.x - start_x;
			//if(start_x > 0)
			//	dir.x = - dir.x;
			dir.y = Input.acceleration.y - start_y;
			//if(start_y > 0)
			//	dir.y = -dir.y;
			dir.z = 0;

			//Normalize the direction of the acceleartion has a magnitude greater than 1
			if (dir.sqrMagnitude > 1)
				dir.Normalize();
			transform.Translate (dir);

				}
	}

	public Font f;
	void OnGUI()
	{

		if (lose) {
			//assert font is set
			if (!f) {
				Debug.LogError("No font found, assign one in the inspector.");
				return;
			}
			
			//set the font
			GUI.skin.font = f;
			
			//set font size
			GUI.skin.box.fontSize = GUI.skin.button.fontSize = 40;
			GUI.skin.box.fontSize = GUI.skin.button.fontSize = 40;

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
					
						GUI.Box (new Rect (0, 0  , Screen.width, Screen.height), "\n\nCurrent Score: " + current_score.ToString () + "\n\nBest Score: " + best_score.ToString ());
						if (GUI.Button (new Rect (Screen.width / 2 - 155 , Screen.height - 75,  150, 70), "Play Again")) {
								Application.LoadLevel ("firstscene");
								//		GUI.EndGroup ();
						}
						
						if (GUI.Button (new Rect (Screen.width/2 , Screen.height - 75, 150, 70), "Quit")) {
				
				
								Application.LoadLevel (0);
								//		GUI.EndGroup ();
						}

						Time.timeScale = 0f;
					
				}
		else{
			if(!onPause)
			{
				if (GUI.Button (new Rect (Screen.width -155 , 5,  150, 70), "Pause"))
				{
					Time.timeScale = 0f;
					onPause = true;

				}
			}
			else
			{
				if (GUI.Button (new Rect (Screen.width -155 , 5,  150, 70), "Resume"))
				{
					Time.timeScale = 1f;
					onPause = false;
				}
			}
		}
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "enemy") 
  		{

			Application.LoadLevel(0);		
		}
	}

}
