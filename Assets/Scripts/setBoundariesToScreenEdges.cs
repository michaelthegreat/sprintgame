using UnityEngine;
using System.Collections;

public class setBoundariesToScreenEdges : MonoBehaviour {
	Camera cam;
	void Awake()
	{

	}

	// Use this for initialization
	void Start () {
		cam  = Camera.main;
		//if (Application.platform == RuntimePlatform.Android ||Application.platform == RuntimePlatform.IPhonePlayer)
		//{
			//     north wall (1/2, 1)
			//     south wall ( 1/2, 0)
			//     east wall (0, 1/2)
			//	   west wall (1, 1/2)
			for (int i = 0; i < this.transform.childCount ; i++) {				
				if (this.transform.GetChild(i).transform.name == "NorthWall"){
					var p = cam.ViewportToWorldPoint(new Vector3(0.5f, 1f, 0f));
					this.transform.GetChild(i).transform.position = p;  				  
				}
				if (this.transform.GetChild(i).transform.name == "SouthWall"){
					var p =cam.ViewportToWorldPoint( new Vector3(0.5f, 0f, 0f));
					this.transform.GetChild(i).transform.position = p;   
				}
				if (this.transform.GetChild(i).transform.name == "EastWall"){
					var p = cam.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f));
					this.transform.GetChild(i).transform.position = p;  
				}
				if (this.transform.GetChild(i).transform.name == "WestWall"){
					var p = cam.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0f));
					
					this.transform.GetChild(i).transform.position = p;  
				}
			}
			
		//}

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < this.transform.childCount - 1; i++) {
			//     north wall (pixelwidth/2, pixelheight)
			//     south wall ( pixelwidth/2, 0)
			//     east wall (0, pixelheight/2)
			//	   west wall (pixelwidth, pixelheight/2)
			
			
		}
	}
}
