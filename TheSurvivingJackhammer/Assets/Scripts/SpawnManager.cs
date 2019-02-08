using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public Transform[] spawnPos;
    StyleManager styleManager;
	public float waitTime;
    public float stopWaitTime;


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
        int thisindex = index;
        Transform position = spawnPos[Random.Range(0, spawnPos.Length)];
        if (thisindex == 4)
        {
            //neon enemys
            Instantiate(styleManager.neonEnemys[Random.Range(0,3)], position.position, Quaternion.identity);
        }
        else
        {
            Instantiate(styleManager.enemy1Styles[index], position.position, Quaternion.identity);
        }        
		yield return new WaitForSeconds(waitTime); 
		StartCoroutine(create(index));
	}

	IEnumerator StartSpawning(int index){
		yield return new WaitForSeconds(0.8f); 
		StartCoroutine(create(index));
	}

    public void StopSpawning()
    {
        this.StopAllCoroutines();
        GameObject.Find("DifficultyManager").GetComponent<DifficultyManager>().StopAllCoroutines();
    }
    
    public void ContinueSpawn()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("enemy"))
        {
            Destroy(item);
        }
        StartCoroutine(StartSpawning(HighScoreManager.index));
        StartCoroutine(GameObject.Find("DifficultyManager").GetComponent<DifficultyManager>().increaseDifficulty());
    }

}
