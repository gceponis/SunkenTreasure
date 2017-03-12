﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy1PatrolScript : MonoBehaviour {

	private bool goLeft = true;
	private float incrementValue = 0.05f;
	public float maxLeft;
	public float maxRight;
	public int enemyHealth;
	//public bool collided = false;

	void Start () {
		enemyHealth = 1;
	}
	
	void Update () {
        if (Time.timeScale != 1) {return;}
        
        if (transform.position.x >= maxLeft && goLeft ) {
        	transform.position = new Vector2(transform.position.x - incrementValue , transform.position.y);
        	if (transform.position.x <= maxLeft) {
        		goLeft = false;
        		transform.rotation = Quaternion.Euler(transform.rotation.x, 180.00f, transform.rotation.z);
        	}
        } else {
        	transform.position = new Vector2(transform.position.x + incrementValue, transform.position.y);
        	if (transform.position.x >= maxRight) {
        		goLeft = true;
        		transform.rotation = Quaternion.Euler(transform.rotation.x, 0.00f, transform.rotation.z);
        	}
        }
	}

	void OnCollisionEnter2D(Collision2D coll) 
    {
    
        if (coll.gameObject.CompareTag("Bullet"))
        {
        	coll.gameObject.SetActive(false);
        	enemyHealth--;
        	if (enemyHealth <= 0) {
        		gameObject.SetActive(false);
        	}
        	
        	
        }
    }

	// void LateUpdate() {
	// 	// collided is set to false after every frame, this is used to prevent collision event from firing twice on collision.
	// 	collided = false;
	// }
	
}
