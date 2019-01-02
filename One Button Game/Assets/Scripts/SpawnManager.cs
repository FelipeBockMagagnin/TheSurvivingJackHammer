using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public Transform[] spawnPos;
	public GameObject[] enemys;
	public GameObject[] enemy1Styles;
	public float waitTime;

	public void StartGame (int index) {
		StartCoroutine(StartSpawning(index));
	}

	IEnumerator create(int index){
		Transform position = spawnPos[Random.Range(0,spawnPos.Length)];
		Instantiate(enemy1Styles[index], position.position, Quaternion.identity);
		yield return new WaitForSeconds(waitTime); 
		StartCoroutine(create(index));
	}

	IEnumerator StartSpawning(int index){
		yield return new WaitForSeconds(0.8f); 
		StartCoroutine(create(index)); //teste inimigo 1
	}

	


}
