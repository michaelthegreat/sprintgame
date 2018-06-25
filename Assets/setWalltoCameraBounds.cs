using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setWalltoCameraBounds : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Camera mainCamera = Camera.main;
        GameObject rightWall = GameObject.Find("rightWall");
        GameObject leftWall = GameObject.Find("leftWall");
        GameObject bottomWall = GameObject.Find("bottomWall");
        GameObject topWall = GameObject.Find("topWall");
        
        float lowerBound= mainCamera.transform.position.y - mainCamera.orthographicSize;
        Debug.Log(lowerBound);

        //bottomWA.position = new Vector3(bottomWall.position.x, lowerBound, bottomWall.position.z);
    
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
