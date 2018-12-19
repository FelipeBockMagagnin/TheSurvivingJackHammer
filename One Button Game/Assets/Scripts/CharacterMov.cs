using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMov : MonoBehaviour {

	public ParticleSystem particle;
	public Animator camAnim;
	public Text score;
	Animator playerAnim;

	void Start () {
		camAnim.SetTrigger("reload");
		playerAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + HighScoreManager.points.ToString();
		if(Input.GetKeyDown(KeyCode.Space)){
			transform.Rotate (0,0,-90);
			playerAnim.SetTrigger("move");
		}		
	}

	void OnTriggerEnter2D(Collider2D collider){		
		Instantiate(particle, collider.transform.position, Quaternion.identity);
		Destroy(collider.gameObject);
		camAnim.SetTrigger("shake");
		HighScoreManager.points++;
	}

	public void reloadLevel(){
		Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
	}
}
