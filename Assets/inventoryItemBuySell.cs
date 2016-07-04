using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class inventoryItemBuySell : MonoBehaviour {
	
	public Sprite[] itemList;
	private int currentItem = 0;
	public GameObject image;
	public GameObject player;
	public GameObject itemText;
	public GameObject itemQuantidade;
	public GameObject itemPrice;
	private int quatidade;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			//Debug.Log ("InvLeft " + currentItem.ToString ());
			currentItem -= 1;
			currentItem = mod(currentItem, itemList.Length);
			image.GetComponent<Image>().sprite = itemList[currentItem];
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			//Debug.Log ("InvRight " + currentItem.ToString ());
			currentItem += 1;
			currentItem = mod(currentItem, itemList.Length);
			image.GetComponent<Image>().sprite = itemList[currentItem];
		}
			
		//sell
		if (Input.GetKeyDown (KeyCode.S)) {
			Debug.Log ("Got a " + itemList [currentItem].name);
			switch (itemList [currentItem].name) {
			case "meat":
				if (player.GetComponent<MyItems> ().meat == 0)
					break;
				player.GetComponent<MyItems> ().meat--;
				player.GetComponent<MyItems> ().ganhaGold (player.GetComponent<MyItems> ().pricemeat);
				break;
			case "salmon":
				if (player.GetComponent<MyItems> ().salmon == 0)
					break;
				player.GetComponent<MyItems> ().salmon--;
				player.GetComponent<MyItems> ().ganhaGold (player.GetComponent<MyItems> ().pricesalmon);
				break;
			case "pizza":
				if (player.GetComponent<MyItems> ().pizza == 0)
					break;
				player.GetComponent<MyItems> ().pizza--;
				player.GetComponent<MyItems> ().ganhaGold (player.GetComponent<MyItems> ().pricepizza);
				break;
			case "beer":
				if (player.GetComponent<MyItems> ().beer == 0)
					break;
				player.GetComponent<MyItems> ().beer--;
				player.GetComponent<MyItems> ().ganhaGold (player.GetComponent<MyItems> ().pricebeer);
				break;
			case "bread":
				if (player.GetComponent<MyItems> ().bread == 0)
					break;
				player.GetComponent<MyItems> ().bread--;
				player.GetComponent<MyItems> ().ganhaGold (player.GetComponent<MyItems> ().pricebread);
				break;
			case "cheese":
				if (player.GetComponent<MyItems> ().cheese == 0)
					break;
				player.GetComponent<MyItems> ().cheese--;
				player.GetComponent<MyItems> ().ganhaGold (player.GetComponent<MyItems> ().pricecheese);
				break;
			case "fire":
				if (player.GetComponent<MyItems> ().fireRune == 0)
					break;
				player.GetComponent<MyItems> ().fireRune--;
				player.GetComponent<MyItems> ().ganhaGold (player.GetComponent<MyItems> ().pricefireRune);
				break;
			case "water":
				if (player.GetComponent<MyItems> ().freezeRune == 0)
					break;
				player.GetComponent<MyItems> ().freezeRune--;
				player.GetComponent<MyItems> ().ganhaGold (player.GetComponent<MyItems> ().pricefreezeRune);
				break;
			case "wind":
				if (player.GetComponent<MyItems> ().windRune == 0)
					break;
				player.GetComponent<MyItems> ().windRune--;
				player.GetComponent<MyItems> ().ganhaGold (player.GetComponent<MyItems> ().pricewindRune);
				break;
			}
		}

		//buy
		if (Input.GetKeyDown (KeyCode.B)) {
			Debug.Log ("Got a " + itemList [currentItem].name);
			switch (itemList [currentItem].name) {
			case "meat":
				if (player.GetComponent<MyItems> ().gold - player.GetComponent<MyItems> ().pricemeat < 0)
					break;
				player.GetComponent<MyItems> ().meat++;
				player.GetComponent<MyItems> ().perdeGold (player.GetComponent<MyItems> ().pricemeat);
				break;
			case "salmon":
				if (player.GetComponent<MyItems> ().gold - player.GetComponent<MyItems> ().pricesalmon < 0)
					break;
				player.GetComponent<MyItems> ().salmon++;
				player.GetComponent<MyItems> ().perdeGold (player.GetComponent<MyItems> ().pricesalmon);
				break;
			case "pizza":
				if (player.GetComponent<MyItems> ().gold - player.GetComponent<MyItems> ().pricepizza < 0)
					break;
				player.GetComponent<MyItems> ().pizza++;
				player.GetComponent<MyItems> ().perdeGold (player.GetComponent<MyItems> ().pricepizza);
				break;
			case "beer":
				if (player.GetComponent<MyItems> ().gold - player.GetComponent<MyItems> ().pricebeer < 0)
					break;
				player.GetComponent<MyItems> ().beer++;
				player.GetComponent<MyItems> ().perdeGold (player.GetComponent<MyItems> ().pricebeer);
				break;
			case "bread":
				if (player.GetComponent<MyItems> ().gold - player.GetComponent<MyItems> ().pricebread < 0)
					break;
				player.GetComponent<MyItems> ().bread++;
				player.GetComponent<MyItems> ().perdeGold (player.GetComponent<MyItems> ().pricebread);
				break;
			case "cheese":
				if (player.GetComponent<MyItems> ().gold - player.GetComponent<MyItems> ().pricecheese < 0)
					break;
				player.GetComponent<MyItems> ().cheese++;
				player.GetComponent<MyItems> ().perdeGold (player.GetComponent<MyItems> ().pricecheese);
				break;
			case "fire":
				if (player.GetComponent<MyItems> ().gold - player.GetComponent<MyItems> ().pricefireRune < 0)
					break;
				player.GetComponent<MyItems> ().fireRune++;
				player.GetComponent<MyItems> ().perdeGold (player.GetComponent<MyItems> ().pricefireRune);
				break;
			case "water":
				if (player.GetComponent<MyItems> ().gold - player.GetComponent<MyItems> ().pricefreezeRune < 0)
					break;
				player.GetComponent<MyItems> ().freezeRune++;
				player.GetComponent<MyItems> ().perdeGold (player.GetComponent<MyItems> ().pricefreezeRune);
				break;
			case "wind":
				if (player.GetComponent<MyItems> ().gold - player.GetComponent<MyItems> ().pricewindRune < 0)
					break;
				player.GetComponent<MyItems> ().windRune++;
				player.GetComponent<MyItems> ().perdeGold (player.GetComponent<MyItems> ().pricewindRune);
				break;
			}
		}

		itemText.GetComponent<Text> ().text = itemList [currentItem].name;
		itemQuantidade.GetComponent<Text> ().text = player.GetComponent<MyItems> ().updateItem (itemList [currentItem].name, 0).ToString();
		itemPrice.GetComponent<Text> ().text = player.GetComponent<MyItems> ().getItemPrice (itemList [currentItem].name).ToString() + "¢";
	}

	int mod(int x, int m){
		return (x % m + m) % m;
	}
}
