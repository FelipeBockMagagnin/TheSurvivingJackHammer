using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StyleManager : MonoBehaviour {

	public  GameObject[] MainCharStyles; //0 - PixelArt; 1 - Pen; 2 - WaterColor
	public  Transform MainCharSpawn;

	public  GameObject ActualMainChar;
	public  int index = 0;

	public bool gameStarted;

	public Button startButton;

	void Start(){
		gameStarted = false;
		index = HighScoreManager.index;
		MainCharSpawn = GameObject.Find("MainCharSpawn").transform;
		if(ActualMainChar != null){
			Destroy(ActualMainChar);
		}
		ActualMainChar = Instantiate(MainCharStyles[index], MainCharSpawn.position, Quaternion.identity);
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Space) && gameStarted == false){
			startButton.onClick.Invoke();
			gameStarted = true;
		}
	}

	void setGameStartedTrue(){
		gameStarted = true;
	}

	public void WatercolorChars(){
		if(ActualMainChar != null){
			Destroy(ActualMainChar);
		}
		ActualMainChar = Instantiate(MainCharStyles[2], MainCharSpawn.position, Quaternion.identity);
		HighScoreManager.index = 2;
	}

	public void PenChars(){
		if(ActualMainChar != null){
			Destroy(ActualMainChar);
		}
		ActualMainChar = Instantiate(MainCharStyles[1], MainCharSpawn.position, Quaternion.identity);
		HighScoreManager.index = 1;
	}

	public void PixelChars(){
		if(ActualMainChar != null){
			Destroy(ActualMainChar);
		}
		ActualMainChar = Instantiate(MainCharStyles[0], MainCharSpawn.position, Quaternion.identity);
		HighScoreManager.index = 0;
	}
}
