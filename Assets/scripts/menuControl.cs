using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuControl : MonoBehaviour {
	public GameObject start;
	public GameObject quit;
	public bool onStart = true;

	public Sprite start_selected;
	public Sprite start_unselected;
	public Sprite quit_selected;
	public Sprite quit_unselected;

	public AudioClip menu_selection;
	private AudioSource source;
    private GameObject FilesManager;

    // Use this for initialization
    void Awake () {
		source = GetComponent<AudioSource> ();
	}
    void Start()
    {
        FilesManager = GameObject.Find("FileManager");
    }
		

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)){
			source.PlayOneShot (menu_selection, 1);
			if (onStart){
				StartGame();
			}
			else {
				ExitGame();
			}
		}

		if (Input.GetKeyDown ("up")) {
			onStart = true;
			source.PlayOneShot (menu_selection, 1);
			start.GetComponent<SpriteRenderer> ().sprite = start_selected;
			quit.GetComponent<SpriteRenderer> ().sprite = quit_unselected;
		}

		if (Input.GetKeyDown ("down")) {
			onStart = false;
			source.PlayOneShot (menu_selection, 1);
			start.GetComponent<SpriteRenderer> ().sprite = start_unselected;
			quit.GetComponent<SpriteRenderer> ().sprite = quit_selected;
		}
	}

    public void StartGame()
    {
        FilesManager.GetComponent<FileManagerScript>().createNewFiles();
        SceneManager.LoadScene("Intro DialogBox");
    }

    public void ContinueGame()
    {
        FilesManager.GetComponent<FileManagerScript>().checkFiles();
        SceneManager.LoadScene("MenuMap");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

