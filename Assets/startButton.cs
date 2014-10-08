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
	
	string buttonText = "HELP";
	bool isDisplayed = false;
	if(GUI.Button( new Rect(optxPos, optyPos, 200,70),buttonText))
	{


			if(isDisplayed == false)
			{
				AudioListener.volume = 0.0F;
				isDisplayed = true;
				buttonText = "Exit";
				GameObject.FindGameObjectWithTag("Instructions").guiTexture.enabled = isDisplayed;
			}
			else
			{
				AudioListener.volume = 1.0F;
				isDisplayed = false;
				buttonText = "Help";
				GameObject.FindGameObjectWithTag("Instructions").guiTexture.enabled = isDisplayed;
			}
	}
	


	GUI.EndGroup ();
	}
}
