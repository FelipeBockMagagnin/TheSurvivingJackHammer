using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseManager : MonoBehaviour {

	public CharacterMov charmov;

	//restart the game on collision with enemy
	void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("enemy"))
        {
            Destroy(charmov.gameObject);
            GameObject.Find("ScoreUi").GetComponent<ManagerUi>().EnableEndGamePanel();
            GameObject.Find("Spawn").GetComponent<SpawnManager>().StopSpawning();
        }
    }
}
