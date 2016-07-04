using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class mapStateControl : MonoBehaviour {

	public GameObject panel;
	public Sprite[] mapList;
	public int status;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (status > mapList.Length) {
			Debug.Log ("This map don't exist. Out of Range!");	
		} else {
			panel.GetComponent<Image> ().sprite = mapList [status];
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			Debug.Log ("Go to the next state");
			switch (status) {
			case 0:
				SceneManager.LoadScene ("scene01");
				break;
			case 1:
				SceneManager.LoadScene ("scene02");
				break;
			case 2:
				SceneManager.LoadScene ("scene03");
				break;
			}
		
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log ("Return to the main menu");
			SceneManager.LoadScene ("MainMenu");
		}

	}
}
