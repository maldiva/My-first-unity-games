using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {


	public GameObject ballPrefab;
	public GameObject cube;
	public Text score;
	public static int cubes =0;
	public Button restart;
	public static int lives = 3;
	public Image life1;
	public Image life2;
	public Image life3;
	public GameObject heart;
	public int pcubes = 150;
	public Text win;
	public Text lose;



	void FixedUpdate() {
		
		score.text = cubes.ToString();
		if (lives == 3) {
			life1.gameObject.SetActive (true);
			life2.gameObject.SetActive (true);
			life3.gameObject.SetActive (true);
		} else if (lives == 2) {
			life1.gameObject.SetActive (false);
			life2.gameObject.SetActive (true);
			life3.gameObject.SetActive (true);
		} else if (lives == 1) {
			life1.gameObject.SetActive (false);
			life2.gameObject.SetActive (false);
			life3.gameObject.SetActive (true);
		} else if (lives == 0) {
			life1.gameObject.SetActive (false);
			life2.gameObject.SetActive (false);
			life3.gameObject.SetActive (false);
		}

		if (lives == 0) {
			lostGame();
		} else if(cubes == 0) {
			winGame();
			}
		if (cubes < pcubes) {
			int chance = Random.Range (0, 10);

			if (chance < 2) {
				spawnExtraLife ();
			}
		}
		pcubes = cubes;

	}

	public void Start(){
		win.gameObject.SetActive (false);
		lose.gameObject.SetActive (false);
		Button restartButton = restart.GetComponent<Button> ();
		restartButton.onClick.AddListener(restartGame);
		startNewGame();
	}

	void OnTriggerExit(Collider other) {
		GameObject gameObject =
			other.gameObject;

		if (gameObject.CompareTag ("Ball")) {
			GameObject ball =
				gameObject;
				lives--;
				Destroy(ball);
				SpawnBall ();
		}
	}

	void SpawnBall(){
		Instantiate (ballPrefab);
	}

	void SpawnCubes() {
		float x = 80.0f; 
		float z = 87.0f;
		for (int i = 0; i > -30;--i) {
			for (int j = 0; j > -5; --j) {
				Instantiate (cube, new Vector3 (x+ (7.0f*j) , 2.5f, z+ (6.2f*i)), Quaternion.identity);
				cubes++;
			   }
	      }
	}


	public void startNewGame() {
		SpawnBall ();
		SpawnCubes ();
	}

	void clearField() {
		GameObject ball = GameObject.FindGameObjectWithTag ("Ball");
		Destroy (ball);
		for (int i = 0; i < 150; ++i) {
			GameObject cube = GameObject.FindGameObjectWithTag ("Cube");
			Destroy (cube);
		}
	}

	void restartGame() {
		Time.timeScale = 1.0f;
		win.gameObject.SetActive (false);
		lose.gameObject.SetActive (false);
			GameObject[] tbd;
			tbd = GameObject.FindGameObjectsWithTag ("Heart");
			for (int i = 0; i < tbd.Length; ++i) {
				Destroy (tbd [i]);
			}

			GameObject[] tbd2;
			tbd2 = GameObject.FindGameObjectsWithTag ("Cube");
			for (int i = 0; i < tbd2.Length; ++i) {
				Destroy (tbd2 [i]);
			}
		cubes = 0;
		clearField();
		startNewGame();
		GameObject paddle = GameObject.FindGameObjectWithTag ("Paddle");
		paddle.transform.position = new Vector3 (paddle.transform.position.x, paddle.transform.position.y, 0);
		lives = 3;
	}


	void lostGame() {
		GameObject tbd = GameObject.FindGameObjectWithTag ("Ball");
		Destroy (tbd);
		Time.timeScale = 0.0f;
		lose.gameObject.SetActive (true);
	}


	void winGame() {
		GameObject tbd = GameObject.FindGameObjectWithTag ("Ball");
		Destroy (tbd);
		Time.timeScale = 0.0f;
		win.gameObject.SetActive (true);
	}
	void spawnExtraLife() {
		
			float x = Random.Range (-60.0f, 30.0f);
			float y = heart.transform.position.y;
			float z = Random.Range (-100.0f, 100.0f);
			Instantiate (heart, new Vector3 (x, y, z), heart.transform.rotation);
		}


}