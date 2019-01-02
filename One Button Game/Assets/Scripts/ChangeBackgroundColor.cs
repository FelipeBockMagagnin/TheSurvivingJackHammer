using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgroundColor : MonoBehaviour {

	int index;

	public Camera cam;

	public void Start(){
		StartCoroutine(count());
	}

	public void Update(){
		cam.backgroundColor = Color.HSVToRGB(index,60,47,true);
		
	}

	IEnumerator count(){
		if(index >= 359){
			index = 0;
		} else {
			index++;
		}
		yield return new WaitForSeconds(1); 
		StartCoroutine(count());
	}
}
