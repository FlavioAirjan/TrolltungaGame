using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class inventoryItemSelection : MonoBehaviour {
	
	public Sprite[] itemList;
	private int currentItem = 0;
	public GameObject image;
	public GameObject player;
	public GameObject itemText;
	public GameObject itemQuantidade;
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

		if (Input.GetKeyDown (KeyCode.Return)) {
			Debug.Log ("Got a " + itemList [currentItem].name);
			switch (itemList [currentItem].name) {
			case "meat":
				if (player.GetComponent<MyItems> ().meat == 0)
					break;
				player.GetComponent<MyItems> ().meat--;
				player.GetComponent<playerController> ().ganhaVida(10);
				break;
			case "salmon":
				if (player.GetComponent<MyItems> ().salmon == 0)
					break;
				player.GetComponent<MyItems> ().salmon--;
				player.GetComponent<playerController> ().ganhaVida(15);
				player.GetComponent<playerController> ().ganhaMana(10);
				break;
			case "pizza":
				if (player.GetComponent<MyItems> ().pizza == 0)
					break;
				player.GetComponent<MyItems> ().pizza--;
				player.GetComponent<playerController> ().ganhaVida(10);
				break;
			case "beer":
				if (player.GetComponent<MyItems> ().beer == 0)
					break;
				player.GetComponent<MyItems> ().beer--;
				player.GetComponent<playerController> ().ganhaMana(10);
				break;
			case "bread":
				if (player.GetComponent<MyItems> ().bread == 0)
					break;
				player.GetComponent<MyItems> ().bread--;
				player.GetComponent<playerController> ().ganhaVida(5);
				break;
			case "cheese":
				if (player.GetComponent<MyItems> ().cheese == 0)
					break;
				player.GetComponent<MyItems> ().cheese--;
				player.GetComponent<playerController> ().ganhaVida(10);
				break;
			}
		}

		itemText.GetComponent<Text> ().text = itemList [currentItem].name;
		itemQuantidade.GetComponent<Text> ().text = player.GetComponent<MyItems> ().updateItem (itemList [currentItem].name, 0).ToString();
	}

	int mod(int x, int m){
		return (x % m + m) % m;
	}
}
