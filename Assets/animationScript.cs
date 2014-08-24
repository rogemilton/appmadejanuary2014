using UnityEngine;
using System.Collections;

public class animationScript : MonoBehaviour {
	public Sprite [] pictures;
	int currentPicture;
	float timer;
	
	public void Update()
	{
		timer -= Time.deltaTime;
		if( timer <= 0 )
		{
			currentPicture = (currentPicture+1)%pictures.Length;
			timer = .25F; //1/2 second
		}
		//maybe this is inefficient but idgaf
		gameObject.GetComponent<SpriteRenderer> ().sprite = pictures[currentPicture];
		
	}
	
}
