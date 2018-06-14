using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}/*
    public void Fire()
    {


        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * -5;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 5.0f);
    }*/
}
