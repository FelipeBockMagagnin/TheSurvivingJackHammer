using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {

	public GameObject mainChar;
	public float Speed;

	void Start(){
		mainChar = GameObject.Find("MainCharSpawn");
	}

	// Use this for initialization
	void move (float speed) {
		Vector3 movDir = (mainChar.transform.position - transform.position).normalized;
		transform.position += movDir* Time.deltaTime * speed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		move(Speed);
	}
}
