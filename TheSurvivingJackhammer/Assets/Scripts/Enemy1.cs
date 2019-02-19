using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {

	GameObject mainChar;
    DifficultyManager difficultyManager;
	float Speed;

	void Start(){
		mainChar = GameObject.Find("MainCharSpawn");
        difficultyManager = GameObject.Find("DifficultyManager").GetComponent<DifficultyManager>();
        Speed = difficultyManager.initialEnemy1Speed;
	}

	/// <summary>
    /// Move o inimigo em direção do personagem principal
    /// </summary>
    /// <param name="speed"></param>
	void move (float speed) {
		Vector3 movDir = (mainChar.transform.position - transform.position).normalized;
		transform.position += movDir* Time.deltaTime * speed;
	}
	
	void FixedUpdate () {
		move(Speed);
	}
}
