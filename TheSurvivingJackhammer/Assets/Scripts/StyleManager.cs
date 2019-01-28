using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StyleManager : MonoBehaviour {


    public Transform MainCharSpawn;             //Store the location of the spawn point
    [Space(30)]
    [Header("0 - PixelArt; 1 - Pen; 2 - WaterColor; 3 - Creepy; 4 - Neon;")]
    public  GameObject[] MainCharStyles; 			//0 - PixelArt; 1 - Pen; 2 - WaterColor; 3 - Creepy; 4 - Neon;


    [Header("0 - PixelArt; 1 - Pen; 2 - WaterColor; 3 - Creepy; 4 - Neon;")]
    public ParticleSystem[] ParticleStyle;			//0 - PixelArt; 1 - Pen; 2 - WaterColor; 3 - Creepy; 4 - Neon;


    [Header("0 - PixelArt; 1 - Pen; 2 - WaterColor; 3 - Creepy; 4 - Neon;")]
    public ParticleSystem[] StartParticleSystem;    //0 - PixelArt; 1 - Pen; 2 - WaterColor; 3 - Creepy; 4 - Neon;


    [Header("0 - PixelArt; 1 - Pen; 2 - WaterColor; 3 - Creepy; 4 - Neon;")]
    public GameObject[] enemy1Styles;               //0 - PixelArt; 1 - Pen; 2 - WaterColor; 3 - Creepy; 4 - Neon;

    [Header("0 - PixelArt; 1 - Pen; 2 - WaterColor; 3 - Creepy; 4 - Neon;")]
    public AudioSource[] musicStyles;	            //0 - PixelArt; 1 - Pen; 2 - WaterColor; 3 - Creepy; 4 - Neon;


    GameObject ActualMainChar;		//store the last mainchar instantiated	
	GameObject ActualStartParticle;	//store the last particle instantiated
	int index = 0;					//number of the last mainchar

    [Space(30)]
    public bool gameStarted;				//define if the game started
	

	public Button startButton;	
	SpawnManager spawnScript;	
	MusicManager musicScript;	

	void Start(){
		musicScript = GameObject.Find("MusicManager").GetComponent<MusicManager>();
		spawnScript = GameObject.Find("Spawn").GetComponent<SpawnManager>();
		gameStarted = false;
		index = HighScoreManager.index;
		MainCharSpawn = GameObject.Find("MainCharSpawn").transform;


		if(ActualMainChar != null){
			Destroy(ActualMainChar);
		} else {
			musicScript.FirstSong(HighScoreManager.index);
		}

		ActualMainChar = Instantiate(MainCharStyles[index], MainCharSpawn.position, Quaternion.identity);
		ActualStartParticle = Instantiate(StartParticleSystem[HighScoreManager.index].gameObject, MainCharSpawn.position, Quaternion.identity);
	}

	public void SetGameStartedTrue(){
		if(gameStarted == false){
			spawnScript.StartGame(HighScoreManager.index);
		}
		gameStarted = true;
		
	}

	public void DestroyParticle(){
		if(ActualStartParticle != null){
			Destroy(ActualStartParticle);
		}
	}

	public void ChangeStartParticle(){
		if(ActualStartParticle != null){
			Destroy(ActualStartParticle);
		}
		ActualStartParticle = Instantiate(StartParticleSystem[HighScoreManager.index].gameObject, MainCharSpawn.position, Quaternion.identity);
	}

	void Update(){
	
		if(Input.GetKeyDown(KeyCode.Space) && gameStarted == false){
			startButton.onClick.Invoke();
			gameStarted = true;
			if(ActualStartParticle != null){
				Destroy(ActualStartParticle);
			}
		}
	}

	void setGameStartedTrue(){
		gameStarted = true;
	}

	public void InstantiateParticle(Transform enemyPosition){
		Instantiate(ParticleStyle[HighScoreManager.index], enemyPosition.position, Quaternion.identity);
	}

	public void WatercolorChars(){
		if(ActualMainChar != null){
			Destroy(ActualMainChar);
		}
		ActualMainChar = Instantiate(MainCharStyles[2], MainCharSpawn.position, Quaternion.identity);
		HighScoreManager.index = 2;
		musicScript.StartSongStyle(HighScoreManager.index);
	}

	public void PenChars(){
		if(ActualMainChar != null){
			Destroy(ActualMainChar);
		}
		ActualMainChar = Instantiate(MainCharStyles[1], MainCharSpawn.position, Quaternion.identity);
		HighScoreManager.index = 1;
		musicScript.StartSongStyle(HighScoreManager.index);
	}

	public void PixelChars()
    {
		if(ActualMainChar != null){
			Destroy(ActualMainChar);
		}
		ActualMainChar = Instantiate(MainCharStyles[0], MainCharSpawn.position, Quaternion.identity);
		HighScoreManager.index = 0;
		musicScript.StartSongStyle(HighScoreManager.index);
	}

    public void CreepyChars()
    {
        if (ActualMainChar != null)
        {
            Destroy(ActualMainChar);
        }
        ActualMainChar = Instantiate(MainCharStyles[3], MainCharSpawn.position, Quaternion.identity);
        HighScoreManager.index = 3;
        musicScript.StartSongStyle(HighScoreManager.index);
    }

    public void NeonChar()
    {
        if (ActualMainChar != null)
        {
            Destroy(ActualMainChar);
        }
        ActualMainChar = Instantiate(MainCharStyles[4], MainCharSpawn.position, Quaternion.identity);
        HighScoreManager.index = 4;
        musicScript.StartSongStyle(HighScoreManager.index);
    }
}
