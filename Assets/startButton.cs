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
	
	if(GUI.Button( new Rect(optxPos, optyPos, 200,70),buttonText))
	{


			Application.LoadLevel("Instructions");
	}
	


	GUI.EndGroup ();
	}
}
