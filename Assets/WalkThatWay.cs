using UnityEngine;
using System.Collections; 


public class WalkThatWay : MonoBehaviour {
	public GameObject background;
	public GameObject rocket;
	public GameObject projectile;

	float timer1 = 0.0F;
	float timer2 = 0.0F;
	float timer3 = 0.0F;
	float timer4 = 0.0F;
	bool lose = false;
	public Points points;//reference to score

	public Transform musicPrefab;
	// Use this for initialization
	void Start () 
	{ 	
		if(!GameObject.FindGameObjectWithTag("Music"))
		{
			var mManager = Instantiate(musicPrefab, transform.position, Quaternion.identity) as Transform; 
			mManager.name = musicPrefab.name;
			DontDestroyOnLoad(mManager);
		}
		//keep the character from falling off the fucking screen
		//all the goddamn time!!
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		
	}
	
	// Update is called once per frame
	void Update() 
	{   
		bool debugFrontCollider = false;
		if(!debugFrontCollider)
		{
		Accelerate(0.001f);
		//insantiate rockets according to this script
		makeItHard();
		}
		else
		{
		//Moves Forward and back along z axis                           //Up/Down
		transform.Translate(Vector2.up * Time.deltaTime * Input.GetAxis("Vertical")* 4);
		//Moves Left and right along x Axis                               //Left/Right
		transform.Translate(Vector2.right * Time.deltaTime * Input.GetAxis("Horizontal")* 4); 
			makeItHard();
		}

	}
	//as the user's points increase, 
	//I will kill him
	void makeItHard()
	{
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

	}


    void Rockets()
	{
		if(!lose)
		{   Random.seed = (int)System.DateTime.Now.Ticks;
			Vector3 instants = new Vector3 (11.0f,Random.Range(1.0f,8.2f),0.0f);
			Instantiate(rocket, instants,Quaternion.identity);
		}
	}

	
	void Accelerate(float modifier)
	{
	  transform.Translate(Input.acceleration.x,(Input.acceleration.y)+0.5f,0);
	}
	
	void OnGUI()
	{
		if(lose)
		{
			//GameObject.FindGameObjectWithTag("score").GetComponent<Points>();
            Application.LoadLevel(0);

		}
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "enemy") 
  		{
			bool lose = false;
			lose = true;		
		}
	}


}
