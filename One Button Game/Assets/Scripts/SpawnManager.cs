using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public Transform[] spawnPos;
	public GameObject[] enemys;
	public float waitTime;

	
	// Update is called once per frame
	void Start () {
		StartCoroutine(Wait());
	}

	IEnumerator create(GameObject enemy){
		Transform position = spawnPos[Random.Range(0,spawnPos.Length)];
		Instantiate(enemy, position.position, Quaternion.identity);
		yield return new WaitForSeconds(waitTime); 
		StartCoroutine(create(enemys[0]));
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds(0.8f); 
		StartCoroutine(create(enemys[0])); //teste inimigo 1
	}

	


}
