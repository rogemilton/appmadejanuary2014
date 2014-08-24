using UnityEngine;
using System.Collections;

public class WalkThatWay : MonoBehaviour {
	public GameObject background;
	public GameObject rocket;
	public GameObject projectile;
	private int frame = 0;
	public bool lose = false;

	// Use this for initialization
	void Start () 
	{ 
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Accelerate(0.1f);
		if(frame % 100 == 0)
			Rockets();
		frame++;
	}
	
	void Rockets()
	{
		if(!lose)
		{
			Vector3 instants = new Vector3 (11,Random.Range(2,7),0);
			Instantiate(rocket, instants,Quaternion.identity);
		}
	}

	void Accelerate(float modifier)
	{
		transform.Translate(Input.acceleration.x,(Input.acceleration.y)+0.5f,0);
		//background.transform.Translate(Input.acceleration.x,0,0);
	}
	
	void OnGUI()
	{
		if(lose)
		{
			if(GUI.Button(new Rect(0,0,Screen.width,Screen.width), "YOU LOSE!)@! TRY AGAIN"))
			{
				Application.LoadLevel(0);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D danger)
	{
		if(danger.gameObject.name == "rocket(Clone)")
		{
			lose = true;
		}

	}


	
}
