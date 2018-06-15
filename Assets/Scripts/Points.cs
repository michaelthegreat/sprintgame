using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {

	public int point = 0;
	float timer = 0.0F;
    private MasterScript masterScript;
    // Use this for initialization
    void Start () {
        GameObject masterGameObject = GameObject.Find("MasterGameObject");
        this.masterScript = masterGameObject.GetComponent<MasterScript>();
    }
	
	// Update is called once per frame
	void Update () {

        if (!this.masterScript.lose)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                point += 1;
                timer = .25F;
                GetComponent<GUIText>().text = "Score: " + point; //1/2 second
            }
        }
	}
}
