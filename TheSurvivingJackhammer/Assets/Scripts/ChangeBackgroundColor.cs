using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgroundColor : MonoBehaviour {

	int index;

	public Camera cam;
	public Color[] colors;

	public void changeBackGround(){
		cam.backgroundColor = colors[index];
		if(index == (colors.Length-1)){
			index = 0;
		} else {
			index++;
		}
	}

	public void FirstColor(){
		index = Random.Range(0,colors.Length);
		cam.backgroundColor = colors[index];
		if(index == (colors.Length-1)){
			index = 0;
		} else {
			index++;
		}
	}
}
