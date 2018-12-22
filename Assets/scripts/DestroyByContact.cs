using UnityEngine;
using System.Collections;


public class DestroyByContact : MonoBehaviour
{
	//public GameObject explosion;
	private GameController gameController;


	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameControllerObject == null) {

			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			Destroy(gameObject);        
		}
		if (other.tag == "Player") {
			//    Instantiate(explosion, transform.position, transform.rotation);


			Destroy(other.gameObject);
			Destroy(gameObject);
			gameController.GameOver ();
		}


	}
} 
