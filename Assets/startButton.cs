using UnityEngine; 
using System.Collections;

public class startButton : MonoBehaviour {

	void Awake() { 


		Screen.orientation = ScreenOrientation.LandscapeLeft;

		

	}

	void OnGUI()
	{
		float xPos = Screen.width /2 -10;
      	float yPos = Screen.height - 70;
		float optxPos = Screen.width/2 - 250;
		float optyPos = Screen.height - 70;

	if (GUI.Button ( new Rect (xPos, yPos,200,70), "START"))
	{
		Application.LoadLevel ("firstscene");
	}

	if(GUI.Button( new Rect(optxPos, optyPos, 200,70), "HELP"))
	{
			GameObject.FindGameObjectWithTag("Instructions").guiTexture.enabled = true;
	}


	GUI.EndGroup ();
	}
}
