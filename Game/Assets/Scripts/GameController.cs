using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject ballPrefab;
	public Button RestartButton;
	public Text firstPlayerScore;
	public Text secondPlayerScore;
	public Text win1;
	public Text win2;
	public Text timer;
	private float min = 10;
	private float sec = 0;
	public Button ConfirmButton;
	public Text draw;

	//public Text winText;

	private int firstPlayerScoreCounter;
	private int secondPlayerScoreCounter;


	public int maxScore = 10;


	void FixedUpdate() {
		if (sec < 0) {
			min--;
			sec = 59;
		}
		sec -= Time.deltaTime;
		timer.text = min.ToString() + ":" + sec.ToString("0");

		if (min < 0) {
			min = 0;
			sec = 0;
			timer.text = min.ToString() + ":" + sec.ToString("0");
			if (firstPlayerScoreCounter > secondPlayerScoreCounter) {
				winMessage (true);
				ConfirmButton.GetComponentInChildren<Text> ().text = "Start new game";
			} else if (secondPlayerScoreCounter > firstPlayerScoreCounter) {
				ConfirmButton.GetComponentInChildren<Text> ().text = "Start new game";
				winMessage (false);
			} else if (firstPlayerScoreCounter == secondPlayerScoreCounter) {
				ConfirmButton.GetComponentInChildren<Text> ().text = "Start new game";
				drawMessage ();
			}
		}


	}

	public void Start(){
		Button confirm = ConfirmButton.GetComponent<Button> ();
		SpawnBall ();
		Button btn = RestartButton.GetComponent<Button>();
		btn.onClick.AddListener(click);
		confirm.onClick.AddListener (confirmation);
		ConfirmButton.gameObject.SetActive(false);
		win1.gameObject.SetActive (false);
		win2.gameObject.SetActive (false);
		draw.gameObject.SetActive (false);
	}

	void OnTriggerExit(Collider other) {
		GameObject gameObject =
			other.gameObject;

		if (gameObject.CompareTag ("Ball")) {
			GameObject ball =
				gameObject;

			if (ball.transform.position.x < transform.position.x) { 
				BallController.ballDir = false;
				++firstPlayerScoreCounter;
				firstPlayerScore.text =
					firstPlayerScoreCounter.ToString();
			} else {
				BallController.ballDir = true;
				++secondPlayerScoreCounter;
				secondPlayerScore.text =
					secondPlayerScoreCounter.ToString();
			}
				
			if (firstPlayerScoreCounter > maxScore) {
				winMessage (true);
				ConfirmButton.GetComponentInChildren<Text>().text = "Start new game";
			} else if (secondPlayerScoreCounter > maxScore) {
				ConfirmButton.GetComponentInChildren<Text>().text = "Start new game";
				winMessage (false);
			} else {
				Destroy (ball);
				SpawnBall ();
			}
		}
	}

	void winMessage(bool b) {
		Time.timeScale = 0;
		if (b == false) {
			win1.gameObject.SetActive (true);
			ConfirmButton.gameObject.SetActive(true);

		} else {
			win2.gameObject.SetActive (true);
			ConfirmButton.gameObject.SetActive(true);
		}
	}

	void drawMessage() {
		Time.timeScale = 0;
		draw.gameObject.SetActive (true);
		ConfirmButton.gameObject.SetActive(true);
	}


	void SpawnBall(){
		Instantiate (ballPrefab);
	}


	public void startNewGame() {
		GameObject ball = GameObject.FindWithTag ("Ball");
		GameObject paddle1 = GameObject.FindWithTag ("Paddle");
		GameObject paddle2 = GameObject.FindWithTag ("EnemyPaddle");
		paddle1.transform.position = new Vector3 (paddle1.transform.position.x, paddle1.transform.position.y, 0);
		paddle2.transform.position = new Vector3 (paddle2.transform.position.x, paddle2.transform.position.y, 0);
		Destroy (ball);
		min = 10;
		sec = 0;
		firstPlayerScoreCounter = 0;
		secondPlayerScoreCounter = 0;
		secondPlayerScore.text =
			secondPlayerScoreCounter.ToString();
		firstPlayerScore.text =
			firstPlayerScoreCounter.ToString();

		Instantiate (ballPrefab);
	}

	void confirmation() {
		startNewGame();
		Time.timeScale = 1;
		ConfirmButton.gameObject.SetActive(false);
		win1.gameObject.SetActive (false);
		win2.gameObject.SetActive (false);
		draw.gameObject.SetActive (false);
	}


	void click() {
		win1.gameObject.SetActive (false);
		win2.gameObject.SetActive (false);
		draw.gameObject.SetActive (false);
		ConfirmButton.GetComponentInChildren<Text>().text = "Are You ready?";
		ConfirmButton.gameObject.SetActive(true);
		Time.timeScale = 0;
	}
}