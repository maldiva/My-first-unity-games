using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitButtonScript : MonoBehaviour {

	public Button button;


	void Start () {
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(click);
	}
	


	void click() {
			Application.Quit();
}


}