using UnityEngine;
using System.Collections;

public class MyItems : MonoBehaviour {

    public int gold;
    public int windRune;
    public int freezeRune;
    public int fireRune;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool runeAvailable(int runeType)
    {
        bool isAvailable;
        switch (runeType)
        {
            case 1:
                isAvailable = windRune > 0 ? true : false;
                break;
            case 2:
                isAvailable =  freezeRune > 0 ? true : false;
                break;
            case 3:
                isAvailable = fireRune > 0 ? true : false;
                break;
            default:
                isAvailable = false;
                break;

        }
        return isAvailable;
    }

    public void buyRune(int runeType)
    {
        switch (runeType)
        {
            case 1:
                windRune++;
                break;
            case 2:
                freezeRune++;
                break;
            case 3:
                fireRune++;
                break;
            default:
                break;
                
        }
    }

    public void useRune(int runeType)
    {
        switch (runeType)
        {
            case 1:
                windRune--;
                break;
            case 2:
                freezeRune--;
                break;
            case 3:
                fireRune--;
                break;
            default:
                break;

        }
    }

    public void ganhaGold(int valor)
    {
        gold += valor;
    }
}
