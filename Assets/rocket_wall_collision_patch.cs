using UnityEngine;
using System.Collections;

public class rocket_wall_collision_patch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision other)
	{

		if(other.gameObject.name == "rocket(Clone)")
		{
			Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("right_wall").collider, other.collider);
		}

	}
}
