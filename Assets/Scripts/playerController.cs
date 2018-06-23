using UnityEngine;
using System.Collections;

using UnityStandardAssets.CrossPlatformInput;
public class playerController : MonoBehaviour
{
	private Animator animator;
	public float speed = 10.0f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public GameObject masterGameObject;
    private MasterScript masterScript;

    // Use this for initialization
    void Start()
	{
		animator = this.GetComponent<Animator>();
        GameObject masterGameObject = GameObject.Find("MasterGameObject");
        this.masterScript = masterGameObject.GetComponent<MasterScript>();
	}
	
	// Update is called once per frame
	void Update()
	{

        if (!this.masterScript.lose)
        {
            float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            float v = CrossPlatformInputManager.GetAxisRaw("Vertical");
            Vector3 position = this.transform.position + (Vector3.right * h) + (Vector3.up * v);
            this.transform.position = position;

            if (CrossPlatformInputManager.GetButton("FireButton"))
            {
                animator.SetTrigger("Shooting");
            }
            //Debug.Log("Lost");
            /*
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Vector3 position = this.transform.position;
                position.x--;
                this.transform.position = position;
                //this.bulletSpawn.position = position;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Vector3 position = this.transform.position;
                position.x++;
                this.transform.position = position;
                //this.bulletSpawn.position = position;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Vector3 position = this.transform.position;
                position.y++;
                this.transform.position = position;
                //this.bulletSpawn.position = position;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Vector3 position = this.transform.position;
                position.y--;
                this.transform.position = position;
                //this.bulletSpawn.position = position;
            }
            if (Input.GetKeyDown("space"))
            {
                animator.SetTrigger("Shooting");
            }*/

        }
        else
        {
            

        }
        //A NOTE ON ANIMATION TRANSITIONS.
        //THE CHARACTER HAS THREE ANIMATION STATES: 
        //Running, Shooting and Dead
        //Make the character shoot by setting Shooting to 1
        //Revert the character back to normal by setting Shooting to 0
        //Kill the character by setting Dead to 1
        //ex: animator.SetInteger("Shooting", 1);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("player collision");
        if (collision.gameObject.tag == "enemyBullet")
        {
            animator.SetTrigger("dying");
            Destroy(collision.gameObject);
            Destroy(GetComponent<PolygonCollider2D>());
            this.masterScript.lose = true;
            //Destroy(gameObject,3.0f);
        }
    }
}
