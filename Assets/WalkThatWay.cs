using UnityEngine;
using System.Collections;

public class WalkThatWay : MonoBehaviour {
	public GameObject background;
	public GameObject rocket;
	public GameObject projectile;
	public bool lose;
	private int frame = 0;
	float timer1 = 0.0F;
	float timer2 = 0.0F;
	float timer3 = 0.0F;
	float timer4 = 0.0F;
	public Points points;//reference to score

	// Use this for initialization
	void Start () 
	{ 	
		Screen.orientation = ScreenOrientation.LandscapeLeft;


	}
	
	// Update is called once per frame
	void Update () 
	{   
		Accelerate(0.001f);
		//every .3 seconds or so, insantiate a rocket
		timer1 -= Time.deltaTime;
		if( timer1 <= 0 )
		{
			timer1 = 1F;
			Rockets();
		}
		if( GameObject.FindGameObjectWithTag("score").GetComponent<Points>().point > 50)
		{

		  if( timer2 <= 0 )
		  {
			    timer2 = .9F;
				Rockets();
		  }
		  if( GameObject.FindGameObjectWithTag("score").GetComponent<Points>().point > 80)
		  {
			timer3 -= Time.deltaTime;
		    if( timer3 <= 0)
			 {
			   timer3 = .8F;
			   Rockets();
			  }
		  
		     if( GameObject.FindGameObjectWithTag("score").GetComponent<Points>().point > 150)
			    {
				   timer3 -= Time.deltaTime;
				   if( timer3 <= 0)
				   {
				    	timer3 = 1.2F;
					    Rockets();
				   }
				if( GameObject.FindGameObjectWithTag("score").GetComponent<Points>().point > 250)
				{
					timer4 -= Time.deltaTime;
					if( timer4 <= 0)
					{
					  timer4 = 1.4F;
					  Rockets();
				    }
			    }
				}
			}
		}
		//Moves Forward and back along z axis                           //Up/Down
		transform.Translate(Vector2.up * Time.deltaTime * Input.GetAxis("Vertical")* 4);
		//Moves Left and right along x Axis                               //Left/Right
		transform.Translate(Vector2.right * Time.deltaTime * Input.GetAxis("Horizontal")* 4);  


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
		//transform.Translate(Input.acceleration.x,(Input.acceleration.y)+0.5f,0);
		background.transform.Translate(Input.acceleration.x,0,0);
	}
	
	void OnGUI()
	{
		if(lose)
		{
			GameObject.FindGameObjectWithTag("score").GetComponent<Points>();
            Application.LoadLevel(0);

		}
	
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.name == "rocket(Clone)")
		{
			lose = true;
		}
		//why does this not increment the score and destroy the game object?

	}



}
