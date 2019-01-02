using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMov : MonoBehaviour {

	Animator playerAnim;
	AudioSource monsterDieSound;
	AudioSource swingSound;
	DifficultyManager difficultyScript;
	StyleManager styleScript;


	void Start(){
		styleScript = GameObject.Find("StyleManager").GetComponent<StyleManager>();
		difficultyScript = GameObject.Find("DifficultyManager").GetComponent<DifficultyManager>();
		playerAnim = this.GetComponent<Animator>();	
		monsterDieSound = GameObject.Find("MonsterDieSound").GetComponent<AudioSource>();
		swingSound = GameObject.Find("MoveSound").GetComponent<AudioSource>();
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			transform.Rotate (0,0,-90);
			playerAnim.SetTrigger("move");
			swingSound.Play();
		}		
	}

	void OnTriggerEnter2D(Collider2D collider){		
		styleScript.InstantiateParticle(collider.transform);
		Destroy(collider.gameObject);
		difficultyScript.camAnim.SetTrigger("shake");
		HighScoreManager.points++;
		monsterDieSound.Play();
	}

	public void reloadLevel(){
		Scene scene = SceneManager.GetActiveScene(); 
		SceneManager.LoadScene(scene.name);
	}
}
