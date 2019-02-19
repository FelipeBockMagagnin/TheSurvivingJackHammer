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


    public GameObject[] neonEnemys;     //0 - rosa ; 1 - azul; 2 - amarelo


    GameObject ActualMainChar;		//store the last mainchar instantiated	
	GameObject ActualStartParticle;	//store the last particle instantiated
	int index = 0;					//number of the last mainchar

    [Space(30)]
    public bool gameStarted;				//define if the game started
	

	public Button startButton;	
	SpawnManager spawnScript;	
	MusicManager musicScript;
    public ManagerUi managerUI;

    GameObject StylePanel;

    /// <summary>
    /// Ativa o painel de estilo
    /// </summary>
    public void activeStylePanel()
    {
        StylePanel.GetComponent<Animator>().SetBool("active", true);
    }

    /// <summary>
    /// Desativa o painel de estilo
    /// </summary>
    public void disableStylePanel()
    {
        StylePanel.GetComponent<Animator>().SetBool("active", false);
    }

	void Start(){
        StylePanel = GameObject.Find("StylePanel");
		musicScript = GameObject.Find("MusicManager").GetComponent<MusicManager>();
		spawnScript = GameObject.Find("Spawn").GetComponent<SpawnManager>();
		gameStarted = false;
		index = HighScoreManager.index;
		MainCharSpawn = GameObject.Find("MainCharSpawn").transform;


		if(ActualMainChar != null){
			Destroy(ActualMainChar);
		} else {
            // musicScript.FirstSong(HighScoreManager.index);
		}

		ActualMainChar = Instantiate(MainCharStyles[index], MainCharSpawn.position, Quaternion.identity);
		ActualStartParticle = Instantiate(StartParticleSystem[HighScoreManager.index].gameObject, MainCharSpawn.position, Quaternion.identity);
	}

    /// <summary>
    /// Restarta o atributo dessa classe
    /// </summary>
    public void retartGame()
    {
        if (ActualMainChar != null)
        {
            Destroy(ActualMainChar);
        }
        else
        {
            musicScript.StartSongStyle(musicScript.musicIndex);
        }

        ActualMainChar = Instantiate(MainCharStyles[HighScoreManager.index], MainCharSpawn.position, Quaternion.identity);
    }

    /// <summary>
    /// Define o jogo como iniciado
    /// </summary>
	public void SetGameStartedTrue(){
        StylePanel.GetComponent<Animator>().SetBool("active", false);
        if (gameStarted == false){
			spawnScript.StartGame();
		}
		gameStarted = true;
		
	}

    /// <summary>
    /// Destroy a particula do inicio
    /// </summary>
	public void DestroyParticle(){
		if(ActualStartParticle != null){
			Destroy(ActualStartParticle);
		}
	}

    /// <summary>
    /// Troca a particula do inicio
    /// </summary>
	public void ChangeStartParticle(){
		if(ActualStartParticle != null){
			Destroy(ActualStartParticle);
		}
		ActualStartParticle = Instantiate(StartParticleSystem[HighScoreManager.index].gameObject, MainCharSpawn.position, Quaternion.identity);
	}

    /// <summary>
    /// Começa o jogo em si
    /// </summary>
    public void StartGame()
    {
        startButton.onClick.Invoke();
        gameStarted = true;
        if (ActualStartParticle != null)
        {
            Destroy(ActualStartParticle);
        }
        
    }

    /// <summary>
    /// Starta o jogo 
    /// </summary>
	void setGameStartedTrue(){
		gameStarted = true;
	}

    /// <summary>
    /// Inicia a particula do inicio
    /// </summary>
    /// <param name="enemyPosition"></param>
	public void InstantiateParticle(Transform enemyPosition){
		Instantiate(ParticleStyle[HighScoreManager.index], enemyPosition.position, Quaternion.identity);
	}

	public void WatercolorChars(){
		if(ActualMainChar != null){
			Destroy(ActualMainChar);
		}
		ActualMainChar = Instantiate(MainCharStyles[2], MainCharSpawn.position, Quaternion.identity);
		HighScoreManager.index = 2;
		//musicScript.StartSongStyle(HighScoreManager.index);
	}

	public void PenChars(){
		if(ActualMainChar != null){
			Destroy(ActualMainChar);
		}
		ActualMainChar = Instantiate(MainCharStyles[1], MainCharSpawn.position, Quaternion.identity);
		HighScoreManager.index = 1;
		//musicScript.StartSongStyle(HighScoreManager.index);
	}

	public void PixelChars()
    {
		if(ActualMainChar != null){
			Destroy(ActualMainChar);
		}
		ActualMainChar = Instantiate(MainCharStyles[0], MainCharSpawn.position, Quaternion.identity);
		HighScoreManager.index = 0;
		//musicScript.StartSongStyle(HighScoreManager.index);
	}

    public void CreepyChars()
    {
        if (ActualMainChar != null)
        {
            Destroy(ActualMainChar);
        }
        ActualMainChar = Instantiate(MainCharStyles[3], MainCharSpawn.position, Quaternion.identity);
        HighScoreManager.index = 3;
        //musicScript.StartSongStyle(HighScoreManager.index);
    }

    public void NeonChar()
    {
        if (ActualMainChar != null)
        {
            Destroy(ActualMainChar);
        }
        ActualMainChar = Instantiate(MainCharStyles[4], MainCharSpawn.position, Quaternion.identity);
        HighScoreManager.index = 4;
        //musicScript.StartSongStyle(HighScoreManager.index);
    }

    /// <summary>
    /// Continua jogando
    /// </summary>
    public void ContinuePlaying()
    {
        spawnScript.ContinueSpawn();
        ActualMainChar = Instantiate(MainCharStyles[HighScoreManager.index], MainCharSpawn.position, Quaternion.identity);
        managerUI.DisableEngGamePanel();
    }

    /// <summary>
    /// Inicia a musica
    /// </summary>
    /// <param name="index"></param>
    public void StartSongStyle(int index)
    {
        musicScript.StartSongStyle(index);
    }
}
