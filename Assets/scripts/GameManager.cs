using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool GameEnd;

    public Canvas PauseMenu;
    public Canvas ControlMenu;
	public Canvas InventoryMenu;

    public GameObject FadeOut;

    // Use this for initialization
    void Start () {
        GameEnd = false;
        PauseMenu.enabled = false;
        PauseMenu.GetComponentInChildren<UnityEngine.UI.Slider>().enabled = false;
        Time.timeScale = 1.0f;
        GameObject.Find("Player").GetComponent<playerController>().pause = false;
        FadeOut = GameObject.Find("FadeOut/FadeOutImage");
    }

    IEnumerator GoToMenuMap()
    {
        GameEnd = false;
        Color transparency = FadeOut.GetComponent<Image>().color;
        while (transparency.a < 1.0f)
        {
            transparency.a += 0.1f;
            FadeOut.GetComponent<Image>().color = transparency;
            yield return new WaitForSeconds(0.1F);

        }
        
        
        
        SceneManager.LoadScene("MenuMap");
    }

    public void CheckGameEnded()
    {
        if (GameEnd)
        {
            StartCoroutine(GoToMenuMap());
        }
    }

    public void SetVolume(float val)
    {
        GetComponent<AudioSource>().volume = val;
    }

    // Update is called once per frame
    void Update () {

        CheckGameEnded();

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
