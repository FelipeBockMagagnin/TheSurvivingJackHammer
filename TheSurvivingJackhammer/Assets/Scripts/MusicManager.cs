using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	
	AudioSource ActualMusicPlaying;
    StyleManager styleManager;


    static MusicManager instance;

	int lastSongIndex = 0;
	bool firstsong = true;

	void Awake(){
        styleManager = GameObject.Find("StyleManager").GetComponent<StyleManager>();
        if (instance == null){
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		} else {
			Destroy(gameObject);
		}
	}	

	public void FirstSong(int index){
		if(firstsong == true){
            ActualMusicPlaying = styleManager.musicStyles[index];
			lastSongIndex = index;
            styleManager.musicStyles[index].Play();
			firstsong = false;
		}
	}

	public void StartSongStyle(int index){
		if(ActualMusicPlaying != null && index != lastSongIndex){
			ActualMusicPlaying.Stop();
		}

		if(index != lastSongIndex){
			ActualMusicPlaying = styleManager.musicStyles[index];
			lastSongIndex = index;
            styleManager.musicStyles[index].Play();
		}
	}
}
