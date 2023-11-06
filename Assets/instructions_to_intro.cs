using UnityEngine;
using System.Collections;



//ALL THIS SCRIPT DOES IS LOAD THE INTRO SCREEN IF YOU PRESS EXIT AND
//START THE GAME IF YOU PRESS START
public class instructions_to_intro : MonoBehaviour {


	// Use this for initialization
	public Transform musicPrefab;
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		if(!GameObject.FindGameObjectWithTag("Music"))
		{
			var mManager = Instantiate(musicPrefab, transform.position, Quaternion.identity) as Transform; 
			mManager.name = musicPrefab.name;
			DontDestroyOnLoad(mManager);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//ALL THIS SCRIPT DOES IS LOAD THE INTRO SCREEN IF YOU PRESS EXIT AND
	//START THE GAME IF YOU PRESS START

	public Font f;
    void OnGUI()
	{	
		//assert font is set
		if (!f) {
			Debug.LogError("No font found, assign one in the inspector.");
			return;
		}

		//set the font
		GUI.skin.font = f;

		//set font size
	    GUI.skin.button.fontSize = 60;
        GUI.skin.box.fontSize = 60;

        //BUTTON POSITIONS
        float xPos = Screen.width /2 -10;
		float yPos = Screen.height - 80;
		float optxPos = Screen.width/2 - 250;
		float optyPos = Screen.height - 80;

		var instruction_string = "You are a lucky fish sitting on his rocket chair" +
            "\nFlying through the mountain air" +
            "\n1.Hold your phone with screen facing up." +
			"\nTilt your screen to move\n" +
						"\n2.Avoid Rockets" +
						"\n\n3.Press pause to pause " +
				"\n(This also calibrates the accelerometer)"+ 
				"\n\n4.Have Fun!\nHasta la victoria siempre.";

		 GUI.Box (new Rect (0, 0, Screen.width, Screen.height), instruction_string);

		//START BUTTON
		if (GUI.Button ( new Rect (xPos, yPos,200,75), "Start"))
		{
		    Application.LoadLevel ("firstscene");
		}

		//EXIT BUTTON
		if (GUI.Button (new Rect (optxPos, optyPos, 200, 75), "Exit")) {
			Application.LoadLevel("IntroScreen");
		}

    }
}
