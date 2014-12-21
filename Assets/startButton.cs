using UnityEngine; 
using System.Collections;

public class startButton : MonoBehaviour {



	void Awake() { 


		Screen.orientation = ScreenOrientation.LandscapeLeft;

		

	}
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
		if (!GameObject.FindGameObjectWithTag ("_Ad")) {
						var adManager = Instantiate (adPrefab, transform.position, Quaternion.identity) as Transform;
						

				
						//Ad scripts and shit
						AdBuddizBinding.SetLogLevel (AdBuddizBinding.ABLogLevel.Info);         // log level
						AdBuddizBinding.SetAndroidPublisherKey ("TEST_PUBLISHER_KEY_ANDROID"); // replace with your Android app publisher key
						AdBuddizBinding.SetIOSPublisherKey ("TEST_PUBLISHER_KEY_IOS");         // replace with your iOS app publisher key
						AdBuddizBinding.SetTestModeActive ();                                  // to delete before submitting to store
						AdBuddizBinding.CacheAds ();  
	
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

    //Buttons
	//GUI.BeginGroup (new Rect(0,0,Screen.width,Screen.height));
	if (GUI.Button ( new Rect (xPos, yPos,150,70), "START"))
	{
		Random.seed = (int)System.DateTime.Now.Ticks;
		if (Random.Range (1, 3) == 2) 
		{
			AdBuddizBinding.ShowAd();
		}
		else
		  Application.LoadLevel ("firstscene");
		//	GUI.EndGroup ();
	}
	
	string buttonText = "HELP";
	
	if(GUI.Button( new Rect(optxPos, optyPos, 150,70),buttonText))
	{


			Application.LoadLevel("Instructions");
	//		GUI.EndGroup ();
	}
	

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

	void OnEnable()
	{
		// Listen to AdBuddiz events
		AdBuddizManager.didFailToShowAd += DidFailToShowAd;
		AdBuddizManager.didCacheAd += DidCacheAd;
		AdBuddizManager.didShowAd += DidShowAd;
		AdBuddizManager.didClick += DidClick;
		AdBuddizManager.didHideAd += DidHideAd;
	}
	
	void OnDisable()
	{
		// Remove all event handlers
		AdBuddizManager.didFailToShowAd -= DidFailToShowAd;
		AdBuddizManager.didCacheAd -= DidCacheAd;
		AdBuddizManager.didShowAd -= DidShowAd;
		AdBuddizManager.didClick -= DidClick;
		AdBuddizManager.didHideAd -= DidHideAd;

	}
	
	void DidFailToShowAd(string adBuddizError) {
		AdBuddizBinding.LogNative("DidFailToShowAd: " + adBuddizError);
		Debug.Log ("Unity: DidFailToShowAd: " + adBuddizError);
	}
	
	void DidCacheAd() {
		AdBuddizBinding.LogNative("DidCacheAd");
		Debug.Log ("Unity: DidCacheAd");

	}
	
	void DidShowAd() {
		AdBuddizBinding.LogNative("DidShowAd");
		Debug.Log ("Unity: DidShowAd");
	}
	
	void DidClick() {
		AdBuddizBinding.LogNative("DidClick");
		Debug.Log ("Unity: DidClick");
	}
	
	void DidHideAd() {
		AdBuddizBinding.LogNative("DidHideAd");
		Debug.Log ("Unity: DidHideAd");
		Application.LoadLevelAsync ("firstscene");

	}
	/*
}*/

}
