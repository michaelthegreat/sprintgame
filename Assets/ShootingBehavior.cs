using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehavior : StateMachineBehaviour {
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public bool isPlayer = false;
    private int speed = 10;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       /* GameObject player = GameObject.Find("Player");
        
        Debug.Log(this);
        playerController playerControllerScript = (playerController)player.GetComponent(typeof(playerController));
        playerControllerScript.Fire();*/
        this.Fire(animator);
    }

    private void Fire(Animator animator)
    {
        //var position = this.bulletSpawn.transform.position;
        //var position = animator.rootPosition;
        //var position = animator.gameObject.transform.position;
        Vector3 position = new Vector3();
        Transform t = animator.gameObject.transform;
        foreach (Transform tr in t)
        {
            if (tr.tag == "bulletSpawn")
            {
                position = tr.position;
            }
        }
       

        var rotation = this.bulletSpawn.transform.rotation;
        var bullet = (GameObject)Instantiate(bulletPrefab, position, rotation);

        if (this.isPlayer)
        {
            Debug.Log(animator.rootPosition);
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * this.speed;
        }
        else
        {
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * this.speed * -1;
        }
        // Add velocity to the bullet
        

        // Destroy the bullet after 2 seconds
        
        Destroy(bullet, 5.0f);
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
