using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


    public Canvas PauseMenu;
    public Canvas ControlMenu;

    // Use this for initialization
    void Start () {
	
	}

    public void SetVolume(float val)
    {
        GetComponent<AudioSource>().volume = val;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ControlMenu.enabled)
            {
                ToggleControlMenu();
            }else{
                TogglePauseMenu();
            }
        }
    }



    public void TogglePauseMenu()
    {
        if (PauseMenu.enabled)
        {
            PauseMenu.enabled = false;
            PauseMenu.GetComponentInChildren<UnityEngine.UI.Slider>().enabled = false;
            Time.timeScale = 1.0f;
            GameObject.Find("Player").GetComponent<playerController>().pause = false;
        }
        else
        {
            PauseMenu.enabled = true;
            PauseMenu.GetComponentInChildren<UnityEngine.UI.Slider>().enabled = true;
            GameObject.Find("Player").GetComponent<playerController>().pause = true;
            Time.timeScale = 0f;
        }

      
    }

    public void ToggleControlMenu()
    {
        if (ControlMenu.enabled)
        {
            ControlMenu.enabled = false;
        }
        else
        {
            ControlMenu.enabled = true;
        }
    }


}
