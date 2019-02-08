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
	ChangeBackgroundColor changeScript;
    CoinManager coinManager;

    public BoxCollider2D boxcollider;

	void Start(){
		changeScript = GameObject.Find("MainCamera").GetComponent<ChangeBackgroundColor>();
		styleScript = GameObject.Find("StyleManager").GetComponent<StyleManager>();
		difficultyScript = GameObject.Find("DifficultyManager").GetComponent<DifficultyManager>();
		monsterDieSound = GameObject.Find("MonsterDieSound").GetComponent<AudioSource>();
		swingSound = GameObject.Find("MoveSound").GetComponent<AudioSource>();
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
        playerAnim = this.GetComponent<Animator>();
        boxcollider = this.GetComponent<BoxCollider2D>();
        changeScript.ChangeBackGroundIndex();
    }

	void Update () {
		
		if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began && styleScript.gameStarted == true){
				transform.Rotate (0,0,-90);
				playerAnim.SetTrigger("move");
				swingSound.Play();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
        if (this.boxcollider.IsTouching(collider))
        {
            styleScript.InstantiateParticle(collider.transform);
            Destroy(collider.gameObject);
            difficultyScript.camAnim.SetTrigger("shake");
            HighScoreManager.points++;
            monsterDieSound.Play();
            changeScript.ChangeBackGroundIndex();
            coinManager.IncreaseEarnedCoins();
            for (int i = 0; i < CoinManager.coinMultiplicator; i++)
            {
                coinManager.InstantiateCoinParticle(collider.transform);
            }
        } else
        {
            styleScript.InstantiateParticle(collider.transform);
            Destroy(collider.gameObject);
            difficultyScript.camAnim.SetTrigger("shake");
            monsterDieSound.Play();
        }
       
       
    }

	
}
