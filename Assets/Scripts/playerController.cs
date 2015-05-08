﻿using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{
	private Animator animator;
	public float speed = 10.0f;
	//Start values for the accelerometer
	float start_x = 0f;
	float start_y = 0f;

	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
		//Get start values for the accelerometer
		start_x = Input.acceleration.x;
		start_y = Input.acceleration.y;
	}
	
	// Update is called once per frame
	void Update()
	{
		//A NOTE ON ANIMATION TRANSITIONS.
		//THE CHARACTER HAS THREE ANIMATION STATES: 
		//Running, Shooting and Dead
		//Make the character shoot by setting Shooting to 1
		//Revert the character back to normal by setting Shooting to 0
		//Kill the character by setting Dead to 1
		//ex: animator.SetInteger("Shooting", 1);
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Vector3 position = this.transform.position;
			position.x--;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			Vector3 position = this.transform.position;
			position.x++;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			Vector3 position = this.transform.position;
			position.y++;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			Vector3 position = this.transform.position;
			position.y--;
			this.transform.position = position;
		}
		if (Input.GetKeyDown ("space")) 
		{
			animator.SetInteger("Shooting", 1);
			
		}

		//Move player with the accelerometer for now
		Accelerate (0.001f);
		
	}

	float speed_limit = 5f;
	void Accelerate(float modifier)
	{

			
			//Find the direction of the acceleration
			Vector3 dir;
			dir.x = Input.acceleration.x - start_x;
			
			//if(start_x > 0)
			//	dir.x = - dir.x;
			dir.y = Input.acceleration.y - start_y;
			//if(start_y > 0)
			//	dir.y = -dir.y;
			
			//Enforce the speed limit for x so the
			//character cannot fall off the boundary
			if(dir.x > speed_limit)
			{
				dir.x = speed_limit;
			}
			else if(dir.x < -1f *  speed_limit)
			{
				dir.x = -1f * speed_limit;
			}
			//Enforce the speed limit for y so the character
			//Cannot fall off the boundary
			if(dir.y > speed_limit)
			{
				dir.y = speed_limit;
			}
			else if(dir.y < -1f * speed_limit)
			{
				dir.y = -1f * speed_limit;
			}
			dir.z = 0;
			
			
			transform.Translate (dir);
			

	}
}