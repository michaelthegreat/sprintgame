using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour {

    public float scrollSpeed = 0.02f;
    private float TIMER1_CONST = 4f;
    float timer1;
    private Animator animator;
    public GameObject bulletPrefab;

    public Transform bulletSpawn;


    //how many seconds  until you destroy this object
    private float timeUntilDestroy = 20f;

    // Use this for initialization
    void Start () {
        //Random rnd = new Random();
        
        //string resourcePath = "Assets/animations/Enemy " + randomEnemyNumber.ToString();
        //Debug.Log(resourcePath);

        //this.animator = this.GetComponent<Animator>();
        //animator = Resources.Load("animations/Enemy " + randomEnemyNumber.ToString()) as Animator;*/
        //this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load(resourcePath) as RuntimeAnimatorController;
        animator = this.GetComponent<Animator>();
        //Debug.Log(this.animator);
        //
        timer1 = Random.Range(0.5f,9f);
        Destroy(gameObject,90.0f);
    }

 
    // Update is called once per frame
    void Update () {
        Vector3 position = this.transform.position;
        position.x -= this.scrollSpeed;
        this.transform.position = position;
        timeUntilDestroy -= Time.deltaTime;
        timer1 -= Time.deltaTime;
        if (GameObject.FindGameObjectWithTag("score").GetComponent<Points>().point > 2)
        {
//            timer1 -= Time.deltaTime;

            if (timer1 <= 0)
            {
                timer1 = Random.Range(0.5f, 9f); ;
                this.animator.SetTrigger("shooting");

            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if(collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
            animator.SetTrigger("dying");
            Destroy(GetComponent<PolygonCollider2D>());
            //Destroy(gameObject,3.0f);
        }
    }


}
