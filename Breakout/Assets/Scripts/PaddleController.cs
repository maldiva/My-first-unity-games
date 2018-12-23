using UnityEngine;

public class PaddleController : MonoBehaviour {

	public float InputForceScale =
		30.0f;
	public float ForceAppliedToBallScale =
		40.0f;
	public float InputForceScaleMouse = 50.0f;

	private Rigidbody rigidBody;

	void Start () {
		rigidBody =
			GetComponent<Rigidbody> ();
		
	}


	void FixedUpdate () {
		GameObject paddle1 = GameObject.FindWithTag ("Paddle");
		float horizontalAxis =
			Input.GetAxis ("Horizontal");

		Vector3 force1 =
			new Vector3 (0.0f, 0.0f, -horizontalAxis) *
			InputForceScale;

		rigidBody.AddForce (force1);


		float MouseHorizontalAxis = 0;

		if (Input.GetAxis ("Mouse X")!= 0) {
			MouseHorizontalAxis = -Input.GetAxis ("Mouse X");
		} 
		Vector3 force2 =
			new Vector3 (0.0f, 0.0f, MouseHorizontalAxis) *
			InputForceScaleMouse;

		rigidBody.AddForce (force2);
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


}