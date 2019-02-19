using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	
	AudioSource ActualMusicPlaying;


    static MusicManager instance;

	int lastSongIndex = 0;
    public int musicIndex;

    [Header("0 - PixelArt; 1 - Pen; 2 - WaterColor; 3 - Creepy; 4 - Neon;")]
    public AudioSource[] musicStyles;               //0 - PixelArt; 1 - Pen; 2 - WaterColor; 3 - Creepy; 4 - Neon;

    void Awake(){
        ActualMusicPlaying = musicStyles[musicIndex];
        lastSongIndex = musicIndex;
        musicStyles[musicIndex].Play();
        if (instance == null){
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		} else {
			Destroy(gameObject);
		}
	}

    private void Start()
    {
        musicIndex = 0;
        ActualMusicPlaying = musicStyles[0];
        lastSongIndex = 0;
        musicStyles[0].Play();        
    }

    /// <summary>
    /// Troca a musica
    /// </summary>
    /// <param name="index"></param>
    public void ChangeMusic(int index)
    {
       musicIndex = index;
       StartSongStyle(musicIndex);
    }

    /// <summary>
    /// Inicia a musica sem repetir
    /// </summary>
    /// <param name="index"></param>
	public void StartSongStyle(int index){
		if(ActualMusicPlaying != null && index != lastSongIndex){
			ActualMusicPlaying.Stop();
		}

		if(index != lastSongIndex){
            musicIndex = index;
			ActualMusicPlaying = musicStyles[index];
			lastSongIndex = index;
            musicStyles[index].Play();
		}
	}
}
