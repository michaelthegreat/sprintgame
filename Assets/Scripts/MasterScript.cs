using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour {

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject player;
    public GameObject lossText;
    public bool pause;
    public bool lose;
    private bool loseFirstUpdatePass= true;
    public float bottomYPosition;
    public float topYPosition;
    //Four rockets go out asynchriously
    
    public float TIMER1_CONST = 8f;
    private float timer1;
    float timer2 = .95F;
    float timer3 = 1.25F;
    float timer4 = 1.45F;
    float current_timescale;
    // Use this for initialization
    public void PlayAgain()
    {
        Debug.Log("Play Again");

        Application.LoadLevel(Application.loadedLevel);
        this.lose = false;
    }
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    void Start () {
        
        Vector3 instants = new Vector3(-8.479f, 2.103f, 0.0f);

        Instantiate(player, instants, Quaternion.identity);
        timer1 = TIMER1_CONST;

    }
	
	// Update is called once per frame
	void Update () {
        if (!lose)
        {

            if (!pause)
            {
                //Accelerate(0.001f);
                //insantiate rockets according to this script
                //makeItHard();
                this.generate();
            }
            else
            {
								//recalibrate input*/
                //start_x = Input.acceleration.x;
                //start_y = Input.acceleration.y;

            }
        }
        else
        {
            if (loseFirstUpdatePass)
            {
                Instantiate(lossText);
                loseFirstUpdatePass = false;

            }
        }
    }

    bool pass1 = false;
    bool pass2 = false;
    void generate()
    {
        if (GameObject.FindGameObjectWithTag("score").GetComponent<Points>().point > 2)
        {
            timer1 -= Time.deltaTime;
            //timer2 -= Time.deltaTime;
            //timer3 -= Time.deltaTime;
            //timer4 -= Time.deltaTime;
            if (timer1 <= 0)
            {
                timer1 = TIMER1_CONST;
                generateEnemy();

            }/*
            if (timer2 <= 0)
            {
                timer2 = 95f;
                generateEnemy();
            }

            if (timer3 <= 0)
            {
                timer3 = 1.2f;
                generateEnemy();

            }
            if (timer4 <= 0)
            {
                timer4 = 1.4f;
                generateEnemy();
            }*/
        }
        /*
        //Use these settings to adjust the difficulty
        if (GameObject.FindGameObjectWithTag("score").GetComponent<Points>().point > 60 && !pass1)
        {
            current_timescale = 1.5f;
            Time.timeScale = current_timescale;
            pass1 = true;
        }
        else if (GameObject.FindGameObjectWithTag("score").GetComponent<Points>().point > 25 && !pass2)
        {
            current_timescale = 1.2f;
            Time.timeScale = current_timescale;
            pass2 = true;
        }*/
    }

    void generateEnemy()
    {
        if (!lose)
        {
            Random.seed = (int)System.DateTime.Now.Ticks;
            int randomEnemyNumber = Random.Range(1, 4);
            Vector3 instants = new Vector3(11.0f, Random.Range(bottomYPosition, topYPosition), 0.0f);
            //Debug.Log(randomEnemyNumber);
            switch (randomEnemyNumber)
            {
                case 1: Instantiate(enemy1, instants, Quaternion.identity); break;
                case 2: Instantiate(enemy2, instants, Quaternion.identity); break;
                case 3: Instantiate(enemy3, instants, Quaternion.identity); break;
                default: Instantiate(enemy1, instants, Quaternion.identity); break;

            }
            
            //Randomly give double enemies because why not
            //Adjust the range to set the difficulty
            /*if (Random.Range(0, 5) == 4)
            {
                instants = new Vector3(11.0f, Random.Range(0f, 7.05f), 0.0f);
                Instantiate(enemy, instants, Quaternion.identity);
            }*/


        }
    }

}
