using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyUIOnStart : MonoBehaviour {

	public Button[] DestroyButton;
	public Text[] texts;

	public void DestroyButtons(){
		foreach(Button b in DestroyButton){
			Destroy(b.gameObject);
		}
		foreach(Text t in texts){
			Destroy(t.gameObject);
		}
	}
}
