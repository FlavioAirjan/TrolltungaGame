using UnityEngine;
using System.Collections;

public class MyItems : MonoBehaviour {

    public int gold;
    public int windRune;
    public int freezeRune;
    public int fireRune;
	public int meat;
	public int salmon;
	public int pizza;
	public int beer;
	public int bread;
	public int cheese;

	public int pricewindRune = 20;
	public int pricefreezeRune = 20;
	public int pricefireRune = 20;
	public int pricemeat = 40;
	public int pricesalmon = 50;
	public int pricepizza = 5;
	public int pricebeer = 10;
	public int pricebread = 5;
	public int pricecheese = 5;

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

	public void buyRune(int runeType, int quantity)
    {
        switch (runeType)
        {
            case 1:
				windRune += quantity;
                break;
            case 2:
				freezeRune += quantity;
                break;
            case 3:
				fireRune += quantity;
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

    public int ganhaGold(int valor)
    {
        gold += valor;
		return gold;
    }

	public int perdeGold(int valor){
		gold -= valor;
		return gold;
	}
		
	public int updateItem(string item, int quantidade){
		switch (item) {
		case "meat":
			meat += quantidade;
			if (meat < 0)
				meat = 0;
			return meat;
		case "salmon":
			salmon += quantidade;
			if (salmon < 0)
				salmon = 0;
			return salmon;
		case "pizza":
			pizza += quantidade;
			if (pizza < 0)
				pizza = 0;
			return pizza;
		case "beer":
			beer += quantidade;
			if (beer < 0)
				beer = 0;
			return beer;
		case "bread":
			bread += quantidade;
			if (bread < 0)
				bread = 0;
			return bread;
		case "cheese":
			cheese += quantidade;
			if (cheese < 0)
				cheese = 0;
			return cheese;
		case "water":
			freezeRune += quantidade;
			if (freezeRune < 0)
				freezeRune = 0;
			return freezeRune;
		case "fire":
			fireRune += quantidade;
			if (fireRune < 0)
				fireRune = 0;
			return fireRune;
		case "wind":
			windRune += quantidade;
			if (windRune < 0)
				windRune = 0;
			return windRune;
		default:
			return -1;
		}

	}


	public int getItemPrice(string item){
		switch (item) {
		case "meat":
			return pricemeat;
		case "salmon":
			return pricesalmon;
		case "pizza":
			return pricepizza;
		case "beer":
			return pricebeer;
		case "bread":
			return pricebread;
		case "cheese":
			return pricecheese;
		case "water":
			return pricefreezeRune;
		case "fire":
			return pricefireRune;
		case "wind":
			return pricewindRune;
		default:
			return -1;
		}

	}
}
