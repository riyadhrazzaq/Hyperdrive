using UnityEngine;
using System.Collections;

public class PlayerMoveForward : MonoBehaviour {

	public float goti;

	void Update () {
		transform.Translate (0, 0, Time.deltaTime * goti);
	}
}


