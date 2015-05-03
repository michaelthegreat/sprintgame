using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{
	private Animator animator;
	public float speed = 10.0f;
	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
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
		
	}
}
