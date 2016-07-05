using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private GameObject Player;

    public bool GameEnd;

    public Canvas PauseMenu;
    public Canvas ControlMenu;
	public Canvas InventoryMenu;
    public Canvas BuyMenu;

    public GameObject FadeOut;
    private GameObject FilesManager;

    // Use this for initialization
    void Start () {

        try
        {
            FilesManager = GameObject.Find("FileManager");
           
        }
        catch
        {

        }

        GameEnd = false;
        PauseMenu.enabled = false;
        PauseMenu.GetComponentInChildren<UnityEngine.UI.Slider>().enabled = false;
        Time.timeScale = 1.0f;
        GameObject.Find("Player").GetComponent<playerController>().pause = false;
        FadeOut = GameObject.Find("FadeOut/FadeOutImage");
        Player = GameObject.Find("Player");
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
            int[] myItems = new int[10];
            myItems[0] = Player.GetComponent<MyItems>().gold;
            myItems[1] = Player.GetComponent<MyItems>().windRune;
            myItems[2] = Player.GetComponent<MyItems>().freezeRune;
            myItems[3] = Player.GetComponent<MyItems>().fireRune;
            myItems[4] = Player.GetComponent<MyItems>().salmon;
            myItems[5] = Player.GetComponent<MyItems>().meat;
            myItems[6] = Player.GetComponent<MyItems>().bread;
            myItems[7] = Player.GetComponent<MyItems>().cheese;
            myItems[8] = Player.GetComponent<MyItems>().pizza;
            myItems[9] = Player.GetComponent<MyItems>().beer;

            FilesManager.GetComponent<FileManagerScript>().writeData(myItems);


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

		if (Input.GetKeyDown(KeyCode.Escape) && !InventoryMenu.enabled && !BuyMenu.enabled)
        {
            if (ControlMenu.enabled)
            {
                ToggleControlMenu();
            }else{
                TogglePauseMenu();
            }
        }

		if (Input.GetKeyDown (KeyCode.I) && !PauseMenu.enabled && !BuyMenu.enabled) {
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
