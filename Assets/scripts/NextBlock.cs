using UnityEngine;
using System.Collections;

public class NextBlock : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			GameManager.mGameManager.Instantiate (); //Calls the Instantiate function from the Game Manger to Place the Next Block
		}		
	
		return;
			
	} 
}
