using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioSource[] musicStyles;	//0 - pixel; 1 - pen; 2 - watercolor
	public AudioSource ActualMusicPlaying;

	public static MusicManager instance;

	int lastSongIndex = 0;

	bool firstsong = true;

	void Awake(){
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		} else {
			Destroy(gameObject);
		}
	}	

	public void FirstSong(int index){
		if(firstsong == true){
			ActualMusicPlaying = musicStyles[index];
			lastSongIndex = index;
			musicStyles[index].Play();
			firstsong = false;
		}
	}

	public void StartSongStyle(int index){
		if(ActualMusicPlaying != null && index != lastSongIndex){
			ActualMusicPlaying.Stop();
		}

		if(index != lastSongIndex){
			ActualMusicPlaying = musicStyles[index];
			lastSongIndex = index;
			musicStyles[index].Play();
		}
	}
}
