using System.Collections;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary boundary;
	private Rigidbody rb;
	//public GameObject shot;
	//public Transform ShotSpawn;
	private AudioSource ad;

	private float nextFire;
	//public float FireRate;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}



   public void FixedUpdate()
    {
            float moveHorizontal = Input.GetAxis("Horizontal");
    Vector3 movement = new Vector3 (Input.acceleration.x, 0.0f, 0.0f);
		rb.velocity = movement * 2.0f *  speed;
		boundary.zMax += .5f;

		rb.position = new Vector3 
			(
				Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
				3.0f,
				Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}