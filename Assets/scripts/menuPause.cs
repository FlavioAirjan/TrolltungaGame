using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuPause : MonoBehaviour {

    
    public Button continueGameButton;
    public Button exitButton;
    public Slider vol;


    // Use this for initialization
    void Start()
    {

        continueGameButton = continueGameButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
      
    }


    public void ContinuePress()
    {
        continueGameButton.enabled = true;
        exitButton.enabled = false;

    }

    public void ExitPress()
    {
        exitButton.enabled = true;
        continueGameButton.enabled = false;
    }

    public void ContinueGame()
    {
        //SceneManager.LoadScene("scene01");
        GetComponentInChildren<GameManager>().TogglePauseMenu();

    }

    public void volume()
    {
        GetComponentInChildren<GameManager>().SetVolume(vol.value);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
       // SceneManager.SetActiveScene(SceneManager.GetActiveScene());
    }
}
