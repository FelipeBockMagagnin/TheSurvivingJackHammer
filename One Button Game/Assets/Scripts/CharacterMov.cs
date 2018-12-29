using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMov : MonoBehaviour {

	public ParticleSystem particle;
	Animator playerAnim;

	AudioSource monsterDieSound;
	AudioSource swingSound;

	DifficultyManager difficultyScript;


	void Start(){
		difficultyScript = GameObject.Find("DifficultyManager").GetComponent<DifficultyManager>();
		playerAnim = this.GetComponent<Animator>();	
		monsterDieSound = GameObject.Find("MonsterDieSound").GetComponent<AudioSource>();
		swingSound = GameObject.Find("MoveSound").GetComponent<AudioSource>();
		//camAnim.SetTrigger("reload");
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			transform.Rotate (0,0,-90);
			playerAnim.SetTrigger("move");
			swingSound.Play();
		}		
	}

	void OnTriggerEnter2D(Collider2D collider){		
		Instantiate(particle, collider.transform.position, Quaternion.identity);
		Destroy(collider.gameObject);
		difficultyScript.camAnim.SetTrigger("shake");
		HighScoreManager.points++;
		monsterDieSound.Play();
	}

	public void reloadLevel(){
		Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
	}
}
