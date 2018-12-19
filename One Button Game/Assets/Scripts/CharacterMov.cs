using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMov : MonoBehaviour {

	public ParticleSystem particle;
	public Animator camAnim;
	int points = 0;
	public Text score;

	void Start () {
		camAnim.SetTrigger("reload");
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + points.ToString();
		if(Input.GetKeyDown(KeyCode.Space)){
			transform.Rotate (0,0,-90);
		}		
	}


	void OnTriggerEnter2D(Collider2D collider){		
		Instantiate(particle, collider.transform.position, Quaternion.identity);
		Destroy(collider.gameObject);
		camAnim.SetTrigger("shake");
		points++;
	}

	public void reloadLevel(){
		points = 0;
		Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
	}

	

}
