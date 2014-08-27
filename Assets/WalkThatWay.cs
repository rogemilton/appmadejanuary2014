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
        if (frame % 100 == 0)
        {
            Rockets();
        }
        else if (frame % 50 == 0)
        {
            Rockets();
        }
		frame++;
		/*
		//Moves Forward and back along z axis                           //Up/Down
		transform.Translate(Vector2.up * Time.deltaTime * Input.GetAxis("Vertical")* 4);
		//Moves Left and right along x Axis                               //Left/Right
		transform.Translate(Vector2.right * Time.deltaTime * Input.GetAxis("Horizontal")* 4);  
		*/

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
            GameObject.Find("Score").GetComponent<Points>().enabled = false;
            Application.LoadLevel(0);
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
