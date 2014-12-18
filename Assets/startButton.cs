using UnityEngine; 
using System.Collections;

public class startButton : MonoBehaviour {

	void Awake() { 


		Screen.orientation = ScreenOrientation.LandscapeLeft;

		

	}
    public Transform musicPrefab;
    void Start()
	{
		if(!GameObject.FindGameObjectWithTag("Music"))
		{
			var mManager = Instantiate(musicPrefab, transform.position, Quaternion.identity) as Transform; 
			mManager.name = musicPrefab.name;
			DontDestroyOnLoad(mManager);
		}
	}
	void Update()
	{
		OnGUI ();
	}

	void OnGUI()
	{
		//button position variables
		float xPos = Screen.width /2 + 100;
      	float yPos = Screen.height - 70;
		float optxPos = Screen.width/2 - 300;
		float optyPos = Screen.height - 70;
		float musicxPos = Screen.width / 2 - 100;
		float musicyPos = Screen.height - 70;
		//Button rectangles
		Rect musicRect = new Rect (musicxPos, musicyPos, 150, 70);
	//GUI.BeginGroup (new Rect(0,0,Screen.width,Screen.height));
	if (GUI.Button ( new Rect (xPos, yPos,150,70), "START"))
	{
		Application.LoadLevel ("firstscene");
	//	GUI.EndGroup ();
	}
	
	string buttonText = "HELP";
	
	if(GUI.Button( new Rect(optxPos, optyPos, 150,70),buttonText))
	{


			Application.LoadLevel("Instructions");
	//		GUI.EndGroup ();
	}
		bool music_enabled = true;

		if((GUI.Button (musicRect, "Toggle Music")))
		   {
		
			if (!GameObject.FindGameObjectWithTag ("Music")) {
				;
			}
			else {
				if(GameObject.FindGameObjectWithTag ("Music").audio.isPlaying)
				{
					GameObject.FindGameObjectWithTag ("Music").audio.Pause ();
				}
				else
				{
					GameObject.FindGameObjectWithTag ("Music").audio.Play ();
				}

				//DestroyObject(button);
				//button = (GUI.Button (new Rect (musicxPos, musicyPos, 150, 70), "Toggle Music"));
			}
		}


	
	}
}
