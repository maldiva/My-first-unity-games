using UnityEngine;

public class BallController : MonoBehaviour {
	public float InputForceScale =
		80.0f;
	private Rigidbody rigidBody;
	public AudioClip paddleCollision;
	private AudioSource audioSource;
	public static bool ballDir = true;
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
		//if (collision.gameObject.CompareTag ("Paddle") || collision.gameObject.CompareTag ("EnemyPaddle")) {
		// Too much sound seems annoying so I will only play it when the ball colides with my paddle
			if (collision.gameObject.CompareTag ("Paddle")) {
			audioSource.clip = paddleCollision;
			audioSource.Play ();
		}
	}

}


