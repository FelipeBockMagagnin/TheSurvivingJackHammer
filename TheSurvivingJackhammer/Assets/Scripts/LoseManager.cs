using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseManager : MonoBehaviour {

	public CharacterMov charmov;

	//restart the game on collision with enemy
	void OnTriggerEnter2D(Collider2D collider){
        GameObject.Find("ScoreUi").GetComponent<ManagerUi>().EnableEndGamePanel();
        Destroy(charmov.gameObject);
        GameObject.Find("Spawn").GetComponent<SpawnManager>().StopAllCoroutines();
    }
}
