using UnityEngine;
using System.Collections;

public class high_score : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var best_score = 0;
		if (PlayerPrefs.HasKey ("Score")) {
			best_score = PlayerPrefs.GetInt ("Score");
			
		}
		guiText.text = "BEST: " + best_score; //1/2 second
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
