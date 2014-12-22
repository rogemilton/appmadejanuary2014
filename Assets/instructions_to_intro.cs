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

    void OnGUI()
	{
		//BUTTON POSITIONS
		float xPos = Screen.width /2 -10;
		float yPos = Screen.height - 70;
		float optxPos = Screen.width/2 - 250;
		float optyPos = Screen.height - 70;

		var instruction_string = "1.Tilt your screen to move\n" +
						"\n2.Avoid Rockets" +
						"\n\n3.Tap the Screen to Pause" +
				"\n\n4.Have Fun!";

		 GUI.Box (new Rect (0, 0, Screen.width, Screen.height-75), instruction_string);

		//START BUTTON
		if (GUI.Button ( new Rect (xPos, yPos,200,70), "START"))
		{
			Application.LoadLevel ("firstscene");
		}

		//EXIT BUTTON
		if (GUI.Button (new Rect (optxPos, optyPos, 200, 70), "EXIT")) {
			Application.LoadLevel("IntroScreen");
				}

    }
}
