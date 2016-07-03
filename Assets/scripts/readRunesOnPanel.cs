using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class readRunesOnPanel : MonoBehaviour {

    private GameObject WindRunePanelObject;
    private GameObject FreezeRunePanelObject;
    private GameObject FireRunePanelObject;
    private GameObject Player;

    // Use this for initialization
    void Start () {
        WindRunePanelObject = gameObject.transform.FindChild("WindRune").gameObject;
        FreezeRunePanelObject = gameObject.transform.FindChild("FreezeRune").gameObject;
        FireRunePanelObject = gameObject.transform.FindChild("FireRune").gameObject;
        Player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        WindRunePanelObject.GetComponentInChildren<Text>().text = Player.GetComponent<MyItems>().windRune.ToString();
        FreezeRunePanelObject.GetComponentInChildren<Text>().text = Player.GetComponent<MyItems>().freezeRune.ToString();
        FireRunePanelObject.GetComponentInChildren<Text>().text = Player.GetComponent<MyItems>().fireRune.ToString();
        //FireRunePanelObject.GetComponent<Text>().text = Player.GetComponent<MyItems>().fireRune.ToString();
        runeInUse(Player.GetComponent<playerController>().activedAttack);
        
    }

    void runeInUse(int runeType)
    {

        Color currentColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        switch (runeType)
        {
            case 1:
               
                currentColor.a = 1.0f;
                WindRunePanelObject.GetComponentInChildren<Image>().color = currentColor;
                currentColor.a = 0.5f;
                FreezeRunePanelObject.GetComponentInChildren<Image>().color = currentColor;
                FireRunePanelObject.GetComponentInChildren<Image>().color = currentColor;


                break;
            case 2:
                currentColor.a = 1.0f;
                FreezeRunePanelObject.GetComponentInChildren<Image>().color = currentColor;
                currentColor.a = 0.5f;
                WindRunePanelObject.GetComponentInChildren<Image>().color = currentColor;
                FireRunePanelObject.GetComponentInChildren<Image>().color = currentColor;
                
                break;
            case 3:
                currentColor.a = 1.0f;
                FireRunePanelObject.GetComponentInChildren<Image>().color = currentColor;
                currentColor.a = 0.5f;
                WindRunePanelObject.GetComponentInChildren<Image>().color = currentColor;
                FreezeRunePanelObject.GetComponentInChildren<Image>().color = currentColor;

                break;
            default:
                currentColor.a = 0.5f;
                FireRunePanelObject.GetComponentInChildren<Image>().color = currentColor;
                WindRunePanelObject.GetComponentInChildren<Image>().color = currentColor;
                FreezeRunePanelObject.GetComponentInChildren<Image>().color = currentColor;
                break;
        }
    }
}
