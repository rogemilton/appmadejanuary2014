using UnityEngine;
using System.Collections;

public class rocket_wall_collision_patch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		var rockets = GameObject.FindGameObjectsWithTag("enemy");
		int len = rockets.Length;
		for(int i = 0; i < len; i++)
			Physics.IgnoreCollision (GameObject.FindGameObjectWithTag ("right_wall").GetComponent<Collider>(), rockets[i].GetComponent<Collider>());
	}
	void OnCollisionEnter(Collision other)
	{

		if (other.gameObject.name == "rocket(Clone)") {
						Physics.IgnoreCollision (GameObject.FindGameObjectWithTag ("right_wall").GetComponent<Collider>(), other.collider);
				} 

	}
}
