﻿using UnityEngine;
using System.Collections;



//ALL THIS SCRIPT DOES IS LOAD THE INTRO SCREEN IF YOU PRESS EXIT AND
//START THE GAME IF YOU PRESS START
public class instructions_to_intro : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//ALL THIS SCRIPT DOES IS LOAD THE INTRO SCREEN IF YOU PRESS EXIT AND
	//START THE GAME IF YOU PRESS START

    void onGUI()
	{
		//BUTTON POSITIONS
		float xPos = Screen.width /2 -10;
		float yPos = Screen.height - 70;
		float optxPos = Screen.width/2 - 250;
		float optyPos = Screen.height - 70;

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
