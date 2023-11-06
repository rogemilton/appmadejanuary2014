using UnityEngine; 
using System.Collections;

public class startButton : MonoBehaviour {



	void Awake() { Screen.orientation = ScreenOrientation.LandscapeLeft }

    public Transform musicPrefab;
	public Transform adPrefab;
    void Start()
	{
		//If we havent made the music manager yet then make it
		//And don't destroy it when we switch scenes
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
		GUI.skin.box.fontSize = GUI.skin.button.fontSize = 60;
		//button position variables
		float xPos = Screen.width /2 + 100;
      	float yPos = Screen.height - 80;
		float optxPos = Screen.width/2 - 300;
		float optyPos = Screen.height - 80;
		float musicxPos = Screen.width / 2 - 100;
		float musicyPos = Screen.height - 80;
		//Button rectangles
		Rect musicRect = new Rect (musicxPos, musicyPos, 175, 75);

        //Buttons
	    if (GUI.Button ( new Rect (xPos, yPos,175,75), "Start"))
	    {
		      Application.LoadLevel ("firstscene");
	    }
	
	    string buttonText = "Help";
	
	    if(GUI.Button( new Rect(optxPos, optyPos, 175,75),buttonText))
	    {
		    Application.LoadLevel("Instructions");
	    }
	    if((GUI.Button (musicRect, "MUSIC"))) {
		
		    if (GameObject.FindGameObjectWithTag ("Music")) {
			    if(GameObject.FindGameObjectWithTag ("Music").GetComponent<AudioSource>().isPlaying)
			    {
				    GameObject.FindGameObjectWithTag ("Music").GetComponent<AudioSource>().Pause ();
			    }
			    else
			    {
				    GameObject.FindGameObjectWithTag ("Music").GetComponent<AudioSource>().Play ();
			    }
		    }
	    }
    }
}
