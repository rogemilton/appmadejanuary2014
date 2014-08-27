using UnityEngine;
using System.Collections;

public class startButton : MonoBehaviour {


	private float xPos = Screen.width /2 - 20;
	private float yPos = 0.2805293F;
	void OnGUI()
	{

	if (GUI.Button ( new Rect (xPos, yPos,80,20), "Level 1")) {
		Application.LoadLevel ("firstscene");
	}
	
	
	GUI.EndGroup ();
	}
}
