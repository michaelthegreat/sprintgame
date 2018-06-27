using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setWalltoCameraBounds : MonoBehaviour {
         private List<Vector3> corners (GameObject go)
         {
             float width = go.GetComponent<Renderer> ().bounds.size.x;
             float height = go.GetComponent<Renderer> ().bounds.size.y;
 
             Vector3 topRight = go.transform.position, topLeft = go.transform.position, bottomRight = go.transform.position, bottomLeft = go.transform.position;
 
             topRight.x += width / 2;
             topRight.y += height / 2;
 
             topLeft.x -= width / 2;
             topLeft.y += height / 2;
 
             bottomRight.x += width / 2;
             bottomRight.y -= height / 2;
 
             bottomLeft.x -= width / 2;
             bottomLeft.y -= height / 2;
 
             List<Vector3> cor_temp = new List<Vector3> ();
             cor_temp.Add (topRight);
             cor_temp.Add (topLeft);
             cor_temp.Add (bottomRight);
             cor_temp.Add (bottomLeft);
     
             return cor_temp;
         }       
	// Use this for initialization
	void Start () {
        Camera mainCamera = Camera.main;
  
        float screenAspect = (float)Screen.width / (float)Screen.height;
        //float cameraHeight = mainCamera.orthographicSize * 2;
        float cameraHeight = mainCamera.orthographicSize;
        Bounds bounds = new Bounds(
            mainCamera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));


        GameObject rightWall = GameObject.Find("rightWall");
        //rightWall.GetComponent<BoxCollider2D>().bounds = bounds;
        //float rightBound = Camera.main.ViewportToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x;
        //float rightBound = mainCamera.transform.position.x  + mainCamera.orthographicSize;
        //float rightBound = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth, mainCamera.pixelHeight, 0)).x;
        Debug.Log("Orthographic size");
        Debug.Log(mainCamera.orthographicSize);
        Debug.Log("Screen Aspect");
        Debug.Log(screenAspect);
        Debug.Log("Main Camera position");
        Debug.Log(mainCamera.transform.position);
        Debug.Log("Right Bound?");
        Debug.Log(mainCamera.transform.position.x + (mainCamera.orthographicSize * screenAspect));
        float rightBound = mainCamera.transform.position.x + ( mainCamera.orthographicSize * screenAspect);// + (cameraHeight * screenAspect);
        float rightWallPosition = rightBound;
        Debug.Log(rightWallPosition);
        //float rightWallPosition = rightBound + (rightWall.GetComponent<BoxCollider2D>().size.y * rightWall.transform.lossyScale.x * 0.5f );
        rightWall.transform.position = new Vector3(-rightWallPosition,rightWall.transform.position.y,rightWall.transform.position.z);

        GameObject leftWall = GameObject.Find("leftWall");
        float leftBound = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).x;
        float leftWallPosition = leftBound;
        //float leftWallPosition = leftBound - (leftWall.GetComponent<BoxCollider2D>().size.y * leftWall.transform.lossyScale.x * 0.5f);
        rightWall.transform.position = new Vector3(leftWallPosition, leftWall.transform.position.y, leftWall.transform.position.z);

        GameObject topWall = GameObject.Find("topWall");
        float upperBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y;
        //float upperBound = mainCamera.transform.position.y + mainCamera.orthographicSize;
        float topWallPosition = upperBound + (topWall.GetComponent<BoxCollider2D>().size.y * topWall.transform.lossyScale.y * 0.5f);
        topWall.transform.position = new Vector3(topWall.transform.position.x,topWallPosition, topWall.transform.position.z);

        GameObject bottomWall = GameObject.Find("bottomWall");
        float lowerBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0, 0)).y;
        //float lowerBound= mainCamera.transform.position.y - mainCamera.orthographicSize;
        float bottomWallPosition = lowerBound - (bottomWall.GetComponent<BoxCollider2D>().size.y * bottomWall.transform.lossyScale.y  * 0.5f) ;
        bottomWall.transform.position = new Vector3(bottomWall.transform.position.x, bottomWallPosition, bottomWall.transform.position.z);
        //bottomWA.position = new Vector3(bottomWall.position.x, lowerBound, bottomWall.position.z);


        
  
         
         
    }


    // Update is called once per frame
    void Update () {
		
	}
}
