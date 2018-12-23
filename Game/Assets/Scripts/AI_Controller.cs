using UnityEngine;

public class AI_Controller : MonoBehaviour {

	public float InputForceScale =
		3.0f;
	public float ForceAppliedToBallScale =
		4.0f;

	private Rigidbody rigidBody;
	float prevX;
	void Start () {
		rigidBody =
			GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		
		GameObject ball = GameObject.FindWithTag ("Ball");
		//float botPosition = ball.transform.position.z;
		float XPosition = ball.transform.position.x;

		//botPosition -= 1;
		/*if (botPosition > 45)
			botPosition = 45;

		if (botPosition < -42)
			botPosition = -42;*/

		if (XPosition > prevX) {
			if (ball.GetComponent<Rigidbody>().position.z > rigidBody.position.z) {
				//rigidBody.velocity = new Vector3(0, 0, 50);
				rigidBody.AddForce (0, 0, 8000);
			} 
			else if (ball.GetComponent<Rigidbody>().position.z < rigidBody.position.z) {
				
				rigidBody.AddForce (0, 0, -8000);
			}


		}
		prevX = XPosition;
	}

	void OnCollisionEnter(Collision collision) {
		GameObject gameObject =
			collision.gameObject;

		if (gameObject.CompareTag ("Ball")) {
			GameObject ball =
				gameObject;

			float shift =
				ball.transform.position.x -
				transform.position.x;

			Vector3 force =
				new Vector3 (shift, 0.0f, 0.0f) *
				ForceAppliedToBallScale;

			ball.GetComponent<Rigidbody> ().AddForce (force);

		}
	}

	/*public static void setdefault() {
		
		transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
	}*/

}