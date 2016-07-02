using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class inventoryItemSelection : MonoBehaviour {
	
	public Sprite[] itemList;
	private int currentItem = 0;
	public GameObject image;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			Debug.Log ("InvLeft " + currentItem.ToString ());
			currentItem -= 1;
			currentItem = mod(currentItem, itemList.Length);
			image.GetComponent<Image>().sprite = itemList[currentItem];

		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			Debug.Log ("InvRight " + currentItem.ToString ());
			currentItem += 1;
			currentItem = mod(currentItem, itemList.Length);
			image.GetComponent<Image>().sprite = itemList[currentItem];
		}
	}

	int mod(int x, int m){
		return (x % m + m) % m;
	}
}
