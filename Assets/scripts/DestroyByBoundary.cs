﻿using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "space")
		{
			return;
		}
		Destroy(other.gameObject);
		Debug.Log (other.gameObject);
	}
}
