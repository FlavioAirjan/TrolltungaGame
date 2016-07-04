using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuScript : MonoBehaviour
{

    public Canvas quitMenu;
    public Button startText;
    public Button exitText;
    private GameObject FilesManager;


    // Use this for initialization
    void Start()
    {
        FilesManager = GameObject.Find("FileManager");
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
    }


    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;

    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

   

}
