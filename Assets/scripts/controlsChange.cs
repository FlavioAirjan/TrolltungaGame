using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class controlsChange : MonoBehaviour {

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text right, left, attack1, attack2, attack3, jump, rune1, rune2, rune3;

    private GameObject currentKey;

    private Color32 normal = new Color32(203,182,172,255);
    private Color32 selected = new Color32(182, 11, 74, 255);
    KeyCode teste;

    // Use this for initialization
    void Start () {

        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Right", "RightArrow")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "LeftArrow")));
        keys.Add("Attack1",(KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Attack1", "Z")));
        keys.Add("Attack2", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Attack2", "X")));
        keys.Add("Attack3", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Attack3", "C")));
        keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "UpArrow")));
        keys.Add("Rune1", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Rune1", "Alpha1")));
        keys.Add("Rune2", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Rune2", "Alpha2")));
        keys.Add("Rune3", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Rune3", "Alpha3")));

        right.text = keys["Right"].ToString();
        left.text = keys["Left"].ToString();
        attack1.text = keys["Attack1"].ToString();
        attack2.text = keys["Attack2"].ToString();
        attack3.text = keys["Attack3"].ToString();
        jump.text = keys["Jump"].ToString();
        rune1.text = keys["Rune1"].ToString();
        rune2.text = keys["Rune2"].ToString();
        rune3.text = keys["Rune3"].ToString();
         teste = keys["Jump"];
    }

    public KeyCode getKeyCode(string key)
    {
        
        return keys[key];
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnGUI()
    {
        if (currentKey!=null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.GetComponentInChildren<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }

    public void changeKey(GameObject clicked)
    {
        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;
    }

    public void SaveKeys()
    {
        foreach(var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
           // Debug.Log(key.Key + " "+key.Value.ToString());

        }
        
        PlayerPrefs.Save();
    }

}
