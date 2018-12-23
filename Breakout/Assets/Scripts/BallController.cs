using UnityEngine;

public class BallController : MonoBehaviour {
	public float InputForceScale =
		80.0f;
	private Rigidbody rigidBody;
	public AudioClip paddleCollision;
	private AudioSource audioSource;
	public static bool ballDir = false;
	void Start() {
		audioSource = GetComponent<AudioSource>();
		rigidBody =
			GetComponent<Rigidbody> ();
		if (ballDir) {
			Vector3 force =
				Quaternion.Euler (0.0f, Random.Range (200, 340), 0.0f) *
				Vector3.forward * InputForceScale;
			    rigidBody.AddForce(force);
		} else {
			Vector3 force =
				Quaternion.Euler (0.0f,Random.Range(20,160), 0.0f) *
				Vector3.forward * InputForceScale;
			    rigidBody.AddForce(force);
		}


	}
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.CompareTag ("Paddle")) {
			audioSource.clip = paddleCollision;
			audioSource.Play ();
		} 
		if (collision.gameObject.CompareTag ("Cube")) {
			Destroy (collision.gameObject);
			GameController.cubes-=1;
		} 
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Heart")) {
			Destroy (other.gameObject);
			if (GameController.lives < 3) {
				GameController.lives++;
			}

		}
	}




}

 
