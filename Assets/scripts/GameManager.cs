using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


    public Canvas PauseMenu;
    public Canvas ControlMenu;
	public Canvas InventoryMenu;


    // Use this for initialization
    void Start () {
        PauseMenu.enabled = false;
        PauseMenu.GetComponentInChildren<UnityEngine.UI.Slider>().enabled = false;
        Time.timeScale = 1.0f;
        GameObject.Find("Player").GetComponent<playerController>().pause = false;
    }

    public void SetVolume(float val)
    {
        GetComponent<AudioSource>().volume = val;
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && !InventoryMenu.enabled)
        {
            if (ControlMenu.enabled)
            {
                ToggleControlMenu();
            }else{
                TogglePauseMenu();
            }
        }

		if (Input.GetKeyDown (KeyCode.I) && !PauseMenu.enabled) {
			Debug.Log ("Enable Inventory");
			InventoryMenu.enabled = !InventoryMenu.enabled;
			Time.timeScale = 1.0f - Time.timeScale;
			GameObject.Find("Player").GetComponent<playerController>().pause = !GameObject.Find("Player").GetComponent<playerController>().pause;
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

	public void ToggleInventory()
	{
		if (InventoryMenu.enabled) {
			InventoryMenu.enabled = false;
		} else {
			InventoryMenu.enabled = true;
		}
	}


}
