using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public Transform[] spawnPos;
    StyleManager styleManager;
	public float waitTime;


    private void Start()
    {
        styleManager = GameObject.Find("StyleManager").GetComponent<StyleManager>();
    }

    public void StartGame () {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("enemy"))
        {
            Destroy(item);
        }
		StartCoroutine(StartSpawning(HighScoreManager.index));
	}

	IEnumerator create(int index){
		Transform position = spawnPos[Random.Range(0,spawnPos.Length)];
        Instantiate(styleManager.enemy1Styles[index], position.position, Quaternion.identity);
		yield return new WaitForSeconds(waitTime); 
		StartCoroutine(create(index));
	}

	IEnumerator StartSpawning(int index){
		yield return new WaitForSeconds(0.8f); 
		StartCoroutine(create(index));
	}
}
