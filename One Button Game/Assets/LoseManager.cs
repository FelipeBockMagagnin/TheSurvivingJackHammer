using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseManager : MonoBehaviour {

	public CharacterMov charmov;

	void OnTriggerEnter2D(Collider2D collider){
		charmov.reloadLevel();
	}
}
