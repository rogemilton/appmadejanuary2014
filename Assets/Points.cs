using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {

	public int point = 0;
	float timer = 0.0F;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if( timer <= 0 )
		{
			point += 1;
			timer = .25F;
			GetComponent<UnityEngine.UI.Text>().text = "Score: " + point; //1/2 second
		}
	}
}
